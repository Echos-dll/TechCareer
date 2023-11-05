using System;
using System.Collections.Generic;
using Merge;
using UnityEngine;

public class MergeArea : MonoBehaviour
{
    [SerializeField] private Tile tile;
    
    [SerializeField] private float _spaceAmount;
    [SerializeField] private int _tileCount;
    
    private Tile[] _tiles;
    private int _currentTileIndex = 0;

    private void Awake()
    {
        _tiles = new Tile[_tileCount];
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateTiles();
    }

    private void GenerateTiles()
    {
        for (int i = 0; i < _tileCount; i++)
        {
            Tile newTile = Instantiate(tile, transform);
            _tiles[i] = newTile;
            newTile.transform.localPosition = new Vector3(i * _spaceAmount, .5f, 0);
        }
    }

    public void PlaceActor(MergeActor actor)
    {
        _tiles[_currentTileIndex]._currentActor = actor;
    }
}
