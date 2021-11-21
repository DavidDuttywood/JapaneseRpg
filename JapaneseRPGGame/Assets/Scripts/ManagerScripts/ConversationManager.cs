using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BigData.TestData;

public class ConversationManager : MonoBehaviour
{
    private SceneTransitionManager stm;


    public UITextTypeWriter npcText;

    private int currentDialogueItem;

    private Conversation conversation;

    public GameObject menu;
    public GameObject helpText;
    public GameObject replyOptions;
    public GameObject backButton;

    private Button[] replyButtons;


    void Start()
    {
        stm = FindObjectOfType<SceneTransitionManager>();

        conversation = new Conversation();
        conversation = GenerateTestConversation();
        replyButtons = replyOptions.GetComponentsInChildren<Button>();

        foreach (Button b in replyButtons)
        {
            if (b.name.Contains("Option"))
            {
                b.onClick.AddListener(delegate { ChooseReply(b); });
            }
        }

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

    public void ChooseReply(Button b)
    {
        if(b.GetComponentInChildren<Text>().text == conversation.ConversationItems[currentDialogueItem].CorrectReply)
        {
            currentDialogueItem++;
            if (currentDialogueItem < conversation.ConversationItems.Count)
            {
                npcText.Type(conversation.ConversationItems[currentDialogueItem].NpcText);
                MapQuestionsToButtons(currentDialogueItem);
            }
            else
            {
                GameManager.instance.MarkObjectiveAsCompleted(conversation.ObjectiveId);
                ReturnToMainMenu();
                npcText.Type(conversation.ExitText);
                StartCoroutine("TransitionBackToGame");
            }
        }
        else
        {
            Debug.Log("No, thats not it");
        }
        return;
    }

    IEnumerator TransitionBackToGame()
    {
        yield return new WaitForSeconds(3.0f);
        stm.LoadLevel("BaseMechanicsSandbox");
    }

    public void RepeatText()
    {
        npcText.Type(conversation.ConversationItems[currentDialogueItem].NpcText);
    }

    public void ShowHelpText()
    {
        menu.SetActive(false);
        backButton.SetActive(true);
        helpText.SetActive(true);
    }

    public void OpenReplyMenu()
    {
        menu.SetActive(false);
        backButton.SetActive(true);
        replyOptions.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        backButton.SetActive(false);
        helpText.SetActive(false);
        replyOptions.SetActive(false);
        menu.SetActive(true);
    }
}
