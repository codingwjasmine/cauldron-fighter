using UnityEngine;
using TMPro; 
public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject _GameWon; // Reference to the win screen UI element
    [SerializeField] private TextMeshProUGUI _score; // Reference to the score text UI element
    [SerializeField] private GameManager _gameManager; // Reference to the GameManager component
    
    private bool _hasWon = false;
    private void Update()
    {
        if (!_hasWon && EnemyDestroy.TotalKills >= 100) // Check if there are no enemies left
        {
            _hasWon = true; // Set the win condition to true
            ShowGameComplete();
        }
    }
    private void ShowGameComplete()
    {
        _GameWon.SetActive(true); // Show the win screen UI element
        _gameManager.Invoke("EndGame", 2f); // Call the EndGame method in the GameManager after a delay
    }
}










