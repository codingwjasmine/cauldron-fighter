using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField]
        private int _killScore;

    private ScoreController _scoreController; // Reference to the ScoreController component

    private void Awake()
    {
        _scoreController = FindFirstObjectByType<ScoreController>(); // Find the ScoreController in the scene
    }

    public void AllocateKillScore()
    {
        _scoreController.AddScore(_killScore); // Add the kill score to the ScoreController
    }
}