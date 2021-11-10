using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class ConversationManager : MonoBehaviour
{
    public UITextTypeWriter npcText;
    private int currentLine;
    private Conversation conversation;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        conversation = new Conversation();
        conversation = conversation.GenerateTestConversation(); //this is shit
        npcText.Type(conversation.ConversationItem[currentLine].NpcText); //this could be expanded to multi lines with subroutine
    }

    public void RepeatText()
    {
        npcText.Type(conversation.ConversationItem[currentLine].NpcText);
    }

    public void ShowHelpText()
    {
        menu.SetActive(false);
    }

    public void OpenReplyMenu()
    {
        menu.SetActive(false);

    }

    public void OpenMainMenu()
    {
        menu.SetActive(true);
    }
}
