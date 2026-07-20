using UnityEngine;
using Yarn;
using Yarn.Unity;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] GameObject dialogueSystem;
    private DialogueRunner dialogueRunner;
    private bool inDialogue;
    private string dialogueNode;
    public GameObject buttonPrompt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialogue"))
        {
            if (collision.gameObject.GetComponent<NPCDialogue>() != null) 
            {
                dialogueNode = collision.gameObject.GetComponent<NPCDialogue>().dialogueNode;
            }
            inDialogue = true;
            buttonPrompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dialogue"))
        {
            inDialogue = false;
            buttonPrompt.SetActive(false);
        }
    }

    private void Start()
    {
        dialogueRunner = dialogueSystem.GetComponent<DialogueRunner>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && inDialogue && dialogueNode!=null && !dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.StartDialogue(dialogueNode);
        }
    }
}
