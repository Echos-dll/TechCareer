using Player;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out RunnerMovement player)) return;
        
        player.OnGameEnd();
        Debug.LogWarning("GAME END");
    }
}
