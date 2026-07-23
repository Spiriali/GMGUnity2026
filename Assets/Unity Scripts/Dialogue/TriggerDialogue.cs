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
    private HealthSystemAttribute healthSystem;
    private Move movement;
    private Inventory inventory;
    private Animator anim;
    private bool triggered = false;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystemAttribute>();
        movement = GetComponent<Move>();
        inventory = GetComponent<Inventory>(); 
        dialogueRunner = dialogueSystem.GetComponent<DialogueRunner>();
        anim = GetComponent<Animator>();
        Invoke(nameof(DialogueOnStart), 0.2f);
    }

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
        if (collision.CompareTag("InstantDialogue") && !triggered)
        {
            dialogueNode = collision.gameObject.GetComponent<NPCDialogue>().dialogueNode;
            StartDialogue();
            triggered = true;
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && inDialogue && dialogueNode!=null && !dialogueRunner.IsDialogueRunning)
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        dialogueRunner.StartDialogue(dialogueNode);
        healthSystem.enabled = false;
        movement.enabled = false;
        inventory.enabled = false;
        healthSystem.inDialogue = true;
        anim.SetBool("isWalking", false);
    }

    [YarnCommand("dialogueend")]
    public void EndDialogue()
    {
        healthSystem.enabled = true;
        movement.enabled = true;
        inventory.enabled = true;
        healthSystem.inDialogue = false;
    }

    private void DialogueOnStart(){
        if(dialogueRunner.IsDialogueRunning)
        {
            healthSystem.inDialogue=true;
            healthSystem.enabled = false;
            movement.enabled = false;
            inventory.enabled = false;
            anim.SetBool("isWalking", false);
        }
    }
}

