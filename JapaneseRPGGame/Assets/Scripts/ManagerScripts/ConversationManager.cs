using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class ConversationManager : MonoBehaviour
{
    private SceneTransitionManager stm;

    public UITextTypeWriter npcText;
    private int currentDialogueItem;
    private Conversation conversation;
    public GameObject menu;
    public GameObject replyOptions;

    private Button[] replyButtons;


    void Start()
    {
        stm = FindObjectOfType<SceneTransitionManager>();

        conversation = new Conversation();
        conversation = conversation.GenerateTestConversation();
        replyButtons = replyOptions.GetComponentsInChildren<Button>();

        //foreach (Button b in replyButtons)
        //{
        //    if (b.name.Contains("Option"))
        //    {
        //        b.onClick.AddListener(ChooseReply()); //this!!!!!!
        //    }
        //}

        npcText.Type(conversation.ConversationItems[currentDialogueItem].NpcText); //this could be expanded to multi lines with subroutine
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
                replyText.text = conversation.ConversationItems[currentDialogueItem].Replies[counter];

            }
            counter++;
        }
    }

    public void ChooseReply()
    {
        if(this.GetComponentInChildren<Text>().text == conversation.ConversationItems[currentDialogueItem].CorrectReply)
        {
            currentDialogueItem++;
            if (currentDialogueItem < conversation.ConversationItems.Count)
            {
                npcText.Type(conversation.ConversationItems[currentDialogueItem].NpcText);
                MapQuestionsToButtons(currentDialogueItem);
            }
            else
            {
                CloseReplyMenuOpenMainMenu();
                npcText.Type(conversation.ExitText);
                stm.LoadLevel("BaseMechanicsSandbox");
            }

        }
        else
        {
            Debug.Log("No, thats not it");
        }
        return;
    }

    public void RepeatText()
    {
        npcText.Type(conversation.ConversationItems[currentDialogueItem].NpcText);
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
