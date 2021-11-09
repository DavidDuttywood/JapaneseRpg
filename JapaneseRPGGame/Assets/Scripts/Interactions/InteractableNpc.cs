using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNpc : Interactable
{
    public string[] dialogueLines;
    private Animator animator;
    private DialogueManager dialogueManager;
    private ConverasationPromptManager converasationPromptManager;
    private bool dialogueInProcess;
    private int currentLine;
    public bool canStartConversation;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (canStartConversation)
        {
            converasationPromptManager = FindObjectOfType<ConverasationPromptManager>();
        }
        currentLine = 0;
        dialogueInProcess = false;

        if(GameManager.instance.conversationPartner == name && GameManager.instance.conversationPartnerPosition != Vector3.zero)
        {
            transform.position = GameManager.instance.conversationPartnerPosition;
        }
    }

    public void Update()
    {
        if (canStartConversation)
        {
            if (converasationPromptManager.conversationTerminated)
            {
                converasationPromptManager.conversationTerminated = false;
                ResetDialogue();
            }
        }
    }

    protected override void Interact()
    {
        if (dialogueInProcess == false) {

            // looks at which way the player is facing then sets the npc to look at them
            var playerHorizontal = GameManager.instance.player.animator.GetFloat("LastHorizontal");
            var playerVertical = GameManager.instance.player.animator.GetFloat("LastVertical");
            animator.SetFloat("LastHorizontal", playerHorizontal * -1);
            animator.SetFloat("LastVertical", playerVertical * -1);

            dialogueInProcess = true;

            dialogueManager.dialogueLine = dialogueLines[currentLine];
            dialogueManager.ShowDialogue();
            currentLine++;
        }
        else if (dialogueInProcess && currentLine < dialogueLines.Length)
        {
            dialogueManager.dialogueLine = dialogueLines[currentLine];
            dialogueManager.ShowDialogue();
            currentLine++;
        }
        else if (dialogueInProcess && currentLine == dialogueLines.Length && canStartConversation)
        {
            GameManager.instance.conversationPartner = name;
            GameManager.instance.conversationPartnerPosition = new Vector3(transform.position.x, transform.position.y);
            converasationPromptManager.PromptConversation();
        }
        else
        {
            ResetDialogue();
        }
    }

    public void ResetDialogue()
    {
        dialogueInProcess = false;
        dialogueManager.CloseDialogue();
        currentLine = 0;
    }
}
