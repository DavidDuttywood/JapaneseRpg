using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BigData.TestData;

public class InteractableNpc : MonoBehaviour
{
    public string[] dialogueLines;
    private Animator animator;
    private DialogueManager dialogueManager;
    private ConverasationPromptManager converasationPromptManager;
    private Objective objective;
    private int currentLine;

    public bool canStartConversation;

    public bool canBeginNewObjective;
    public bool canCompleteObjective;

    public void Start()
    {
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (canBeginNewObjective)
        {
            objective = transform.Find("Objective").GetComponent<Objective>();
        }

        if (canStartConversation)
        {
            converasationPromptManager = FindObjectOfType<ConverasationPromptManager>();
        }

        currentLine = 0;

        if(GameManager.instance.conversationPartner == name && GameManager.instance.conversationPartnerPosition != Vector3.zero)
        {
            transform.position = GameManager.instance.conversationPartnerPosition;
        }
    }

    public void Interact()
    {
        if (currentLine == 0)
        {
            switch (GameManager.instance.player.GetComponent<SpriteRenderer>().sprite.name)
            {
                case "playerWalkingRight":
                case "playerIdleRight":
                    animator.SetFloat("LastHorizontal", -1f);
                    animator.SetFloat("LastVertical", 0f);
                    break;
                case "playerWalkingLeft":
                case "playerIdleLeft":
                    animator.SetFloat("LastHorizontal", 1f);
                    animator.SetFloat("LastVertical", 0f);
                    break;
                case "playerWalkingUp":
                case "playerIdleUp":
                    animator.SetFloat("LastHorizontal", 0f);
                    animator.SetFloat("LastVertical", -1f);
                    break;
                case "playerWalkingDown":
                case "playerIdleDown":
                    animator.SetFloat("LastHorizontal", 0f);
                    animator.SetFloat("LastVertical", 1f);
                    break;
            };

            dialogueManager.dialogueLine = dialogueLines[currentLine];
            dialogueManager.ShowDialogue();
            currentLine++;
        }
        else if (currentLine > 0 && currentLine < dialogueLines.Length)
        {
            dialogueManager.dialogueLine = dialogueLines[currentLine];
            dialogueManager.ShowDialogue();
            currentLine++;
        }
        else if (currentLine == dialogueLines.Length)
        {
            dialogueManager.CloseDialogue();
            currentLine = 0;

            dialogueManager.dialougeBox.SetActive(false);
            if (canStartConversation)
            {
                converasationPromptManager.PromptConversation();
            }

            if (canBeginNewObjective)
            {
                objective.Accept();
            }
        }
    }
}
