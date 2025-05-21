using UnityEngine;
using UnityEngine.Events; 
public class ScoreController : MonoBehaviour
{   
    public UnityEvent OnScoreChanged; // Unity event to notify when the score changes

    public int Score { get; private set; } // Property to hold the score value

    public void AddScore(int amount)
    {
        Score += amount; // Increment the score by the specified amount
        Debug.Log("Score increased to: " + Score);
        OnScoreChanged?.Invoke(); // Invoke the OnScoreChanged event to notify listeners
    }











}