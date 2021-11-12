using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class ConversationManager : MonoBehaviour
{
    public UITextTypeWriter npcText;
    private int currentDialogueItem;
    private Conversation conversation;
    public GameObject menu;
    public GameObject replyOptions;

    private Button[] replyButtons;


    void Start()
    {
        conversation = new Conversation();
        conversation = conversation.GenerateTestConversation(); //this is shit
        replyButtons = replyOptions.GetComponentsInChildren<Button>();

        npcText.Type(conversation.ConversationItem[currentDialogueItem].NpcText); //this could be expanded to multi lines with subroutine
        MapQuestionsToButtons(currentDialogueItem);
    }

    public void MapQuestionsToButtons(int currentDialogueItem)
    {
        int counter = 0;

        foreach(Button b in replyButtons)
        {
            if (b.name.Contains("Option"))
            {
                Text replyText = b.GetComponentInChildren<Text>();
                replyText.text = conversation.ConversationItem[currentDialogueItem].Replies[counter];
                b.onClick.AddListener(delegate { ChooseReply(replyText.text); });

            }
            counter++;
        }
    }

    public void ChooseReply(string reply)
    {
        if(reply == conversation.ConversationItem[currentDialogueItem].CorrectReply)
        {
            currentDialogueItem++;
            npcText.Type(conversation.ConversationItem[currentDialogueItem].NpcText);
            MapQuestionsToButtons(currentDialogueItem);
        }
        else
        {
            Debug.Log("No, thats not it");
        }
        return;
    }

    public void RepeatText()
    {
        npcText.Type(conversation.ConversationItem[currentDialogueItem].NpcText);
    }

    public void ShowHelpText()
    {
        menu.SetActive(false);
    }

    public void OpenReplyMenu()
    {
        menu.SetActive(false);
        replyOptions.SetActive(true);
    }

    public void CloseReplyMenuOpenMainMenu()
    {
        replyOptions.SetActive(false);
        menu.SetActive(true);
    }


}
