using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{   
    [SerializeField]
        private TMP_Text _scoreText; // Reference to the TextMeshPro component
    private ScoreController _scoreController; // Reference to the ScoreController component
    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>(); // Get the TextMeshPro component
        _scoreController = FindFirstObjectByType<ScoreController>(); // Find the ScoreController in the scene
    

        if (_scoreController != null)
        {
            _scoreController.OnScoreChanged.AddListener(UpdateScore); // Subscribe to the OnScoreUpdated event
            UpdateScore(); // Update the score text initially
        }

        if (_scoreText == null)
        {
            Debug.LogError("ScoreText component not found!"); // Log an error if the TextMeshPro component is not found
        }
        else
        {
            Debug.Log("ScoreText component found!"); // Log a message if the TextMeshPro component is found
        }
    }
    public void UpdateScore()
    {   
        Debug.Log("updateScore() called!"); // Log the updated score
        _scoreText.text = "Kills: " + _scoreController.Score; // Update the score text with the current score
    }

}