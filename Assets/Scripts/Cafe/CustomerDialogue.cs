using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomerDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMPro.TextMeshProUGUI dialogueText; 

    private int dialogueStep = 0;

    void Start()
    {
        Invoke(nameof(TriggerDialogue), 2f); // Start after 2 seconds
    }

    void TriggerDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "I heard that evil ghosts are coming to destroy your cafe and harm you!";
        dialogueStep = 1;

    }

    void Update()
    {   
        if (dialogueStep == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueText.text = "You need to kill 100 ghosts to survive!";
            dialogueStep = 2;
        }
        else if (dialogueStep == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueText.text = "Good luck!";
            dialogueStep = 3;
        }
        else if (dialogueStep == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Ghostbattle");
        }
    }
}