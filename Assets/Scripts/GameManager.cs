using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    
    [SerializeField] GameObject gameOver;
    private float _timeToWaitBeforeExit = 2f; // Time to wait before exiting the game
    
    public void Start()
    {
        EnemyDestroy.TotalKills = 0; // Reset kill count when game starts
    }
    public void OnplayerDied()
    {
        gameOver.SetActive(true); // Activate the Game Over UI
        Invoke(nameof(EndGame), _timeToWaitBeforeExit); // Call EndGame after a delay

    }

    private void EndGame()
    {
        SceneManager.LoadScene("Menu"); // Load the menu scene
    }


}
