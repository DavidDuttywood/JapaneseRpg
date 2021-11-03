using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNpc : Interactable
{
    public string[] dialogueLines;
    private Animator animator;
    private Wanderer wanderer;
    private DialogueManager dialogueManager;
    private bool dialogueInProcess;
    private int currentLine;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        wanderer = GetComponent<Wanderer>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        currentLine = 0;
        dialogueInProcess = false;
    }


    protected override void Interact()
    {
        if (dialogueInProcess == false) { 
            wanderer.canMove = false;

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
        else
        {
            dialogueInProcess = false;
            wanderer.canMove = true;
            dialogueManager.CloseDialogue();
            currentLine = 0;
        }
    }
}
