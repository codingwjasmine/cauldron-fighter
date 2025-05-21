using UnityEngine;
using UnityEngine.Video;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    private float _playerAwarenessDistance = 5f; // Adjust this value as needed

    private Transform _player;


    private void Awake()
    {
        var playerMovements = Object.FindFirstObjectByType<PlayerMovements>();
        if (playerMovements != null)
        {
            _player = playerMovements.transform;
        }
        else
        {
            Debug.LogError("PlayerMovements component not found in the scene.");
        }
    }

    private void Update()
    {
        if (_player == null)
        {
            AwareOfPlayer = false;
            DirectionToPlayer = Vector2.zero;
            return;
        }

        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        AwareOfPlayer = enemyToPlayerVector.sqrMagnitude <= _playerAwarenessDistance * _playerAwarenessDistance;
    }
}
