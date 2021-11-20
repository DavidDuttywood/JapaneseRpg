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
    private BeginNewObjective beginNewObjective;
    private int currentLine;

    public bool canStartConversation;
    public bool canBeginNewObjective;


    void Awake()
    {
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        if (canBeginNewObjective)
        {
            beginNewObjective = transform.Find("Objective").GetComponent<BeginNewObjective>();
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

    void Interact()
    {
        if (currentLine == 0)
        {

            // looks at which way the player is facing then sets the npc to look at them
            var playerHorizontal = GameManager.instance.player.animator.GetFloat("LastHorizontal");
            var playerVertical = GameManager.instance.player.animator.GetFloat("LastVertical");
            animator.SetFloat("LastHorizontal", playerHorizontal * -1);
            animator.SetFloat("LastVertical", playerVertical * -1);

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
                beginNewObjective.Accept();
            }
        }
    }
}
