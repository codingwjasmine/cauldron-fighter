using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("cutscene"); // Load the game scene
    }

    public void Exit()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Exit"); // Log exit message to console
    }
}
