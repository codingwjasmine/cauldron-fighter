using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections; 
public class CutSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] _cutSceneUI; // Reference to the cutscene UI GameObject
    [SerializeField] private float displayTime;
    
    private bool _skipRequested = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _skipRequested = true; // Set skip requested to true
        }
    }
    private void Start()
    {
        StartCoroutine(PlayCutScene()); // Start the cutscene coroutine
    }

    private IEnumerator PlayCutScene()
    {
        for (int i = 0; i < _cutSceneUI.Length; i++)
        {
            ShowCutScene(i); // Show the cutscene UI element
            float time = 0f; // Initialize time variable

            while (time < displayTime && !_skipRequested) 
            {
                time += Time.deltaTime; // Increment time by delta time
                yield return null; // Wait for the next frame
            }
            _skipRequested = false; // Reset skip requested for the next cutscene
        
        }
        
        SceneManager.LoadScene("Cafescene"); // Load the menu scene after the cutscene
    }

    private void ShowCutScene(int index)
    {
        for (int i = 0; i < _cutSceneUI.Length; i++)
        {
            _cutSceneUI[i].SetActive(i == index); // Activate the current cutscene UI element and deactivate others
        }
    }
}
