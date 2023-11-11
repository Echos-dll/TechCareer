using System.Collections.Generic;
using DG.Tweening;
using Merge;
using UnityEngine;
using UnityEngine.Serialization;

public class MergeArea : MonoBehaviour
{
    [FormerlySerializedAs("tilePrefabTest")]
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private MergeLevelGenerator LevelGenerator;
    
    [SerializeField] private float _spaceAmount;
    [SerializeField] private int _tileCount;
    [SerializeField] private Transform _topPoint;
    
    private Tile[] _tiles;
    
    private int _currentTileIndex = 0;
    
    private List<Tile> _mergingTiles = new List<Tile>();

    private Sequence _placeSequence;
    
    

    private void Awake()
    {
        _tiles = new Tile[_tileCount];
    }

    private void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        float totalWidth = (_tileCount - 1) * _spaceAmount;
        Vector3 startPos = new Vector3(totalWidth / -2, 0, 0);
        
        for (int i = 0; i < _tileCount; i++)
        {
            Tile newTile = Instantiate(tilePrefab, transform);
            _tiles[i] = newTile;
            newTile.transform.localPosition = startPos + new Vector3(i * _spaceAmount, .5f, 0);
        }
    }

    public void PlaceActor(MergeActor actor)
    {
        _currentTileIndex++;
        Tile goingTile = _tiles[_currentTileIndex - 1];
        
        goingTile._currentActor = actor;
        actor.transform.parent = goingTile.transform;
        actor.TogglePhysics(false);
        
        MoveActorToTile(actor, goingTile.transform.position);
    }

    private void MoveActorToTile(MergeActor actor, Vector3 transformPosition)
    {
        _placeSequence = DOTween.Sequence();
        _placeSequence.Append(actor.transform.DOMove(_topPoint.position, .5f));
        _placeSequence.Join(actor.transform.DORotate(Vector3.zero, .5f));
        _placeSequence.Append(actor.transform.DOJump(transformPosition, 3f, 1, .5f));

        _placeSequence.OnComplete(()=>
        {
            if (CheckMerge())
            {
                CheckMerge();
            }
            else
            {
                if (_tiles[^1]._currentActor != null)
                {
                    Debug.Log("Game Over");
                }
            }
        });
    }

    private bool CheckMerge()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            int counter = 0;
            _mergingTiles.Clear();
            Tile tile1 = _tiles[i];

            if (tile1._currentActor == null) continue;
            
            for (int j = i + 1; j < _tiles.Length; j++)
            {
                Tile tile2 = _tiles[j];
                
                if (tile2._currentActor == null) continue;
                
                if (tile1._currentActor.ActorIndex == tile2._currentActor.ActorIndex)
                {
                    counter++;
                    if (!_mergingTiles.Contains(tile1))
                    {
                        _mergingTiles.Add(tile1);
                    }

                    if (!_mergingTiles.Contains(tile2))
                    {
                        _mergingTiles.Add(tile2);
                    }
                }

                if (counter == 2)
                {
                    Merge();
                    return true;
                }
            }
        }

        return false;
    }

    private void Merge()
    {
        Tile mergeAt = _mergingTiles[0];
        
        int mergedIndex = mergeAt._currentActor.ActorIndex + 1;
        
        MergeActor mergedActor = LevelGenerator.ActorPool.Get();
        mergedActor.Init(mergedIndex);
        mergedActor.transform.position = mergeAt.transform.position;
        mergedActor.transform.parent = mergeAt.transform;
        mergedActor.TogglePhysics(false);
        
        mergedActor.gameObject.SetActive(true);
        
        foreach (Tile tile in _mergingTiles)
        {
            LevelGenerator.ActorPool.Return(tile._currentActor);
            tile._currentActor.gameObject.SetActive(false);
            tile._currentActor = null;
        }

        _mergingTiles[0]._currentActor = mergedActor;

        AdjustTiles();
    }

    private void AdjustTiles()
    {
        int emptyTileIndex = -1;
        for (int i = 0; i < _tiles.Length; i++)
        {
            Tile tile = _tiles[i];
            if (tile._currentActor == null)
            {
                emptyTileIndex = i;
                break;
            }
        }

        for (int i = emptyTileIndex + 1; i < _tiles.Length; i++)
        {
            Tile tile = _tiles[i];
            if (tile._currentActor != null)
            {
                _tiles[emptyTileIndex]._currentActor = tile._currentActor;
                tile._currentActor = null;
                _tiles[emptyTileIndex]._currentActor.transform.parent = _tiles[emptyTileIndex].transform;
                _tiles[emptyTileIndex]._currentActor.transform.position = _tiles[emptyTileIndex].transform.position;
                _currentTileIndex = i;
                AdjustTiles();
            }
            else
            {
                return;
            }
        }
    }
}
