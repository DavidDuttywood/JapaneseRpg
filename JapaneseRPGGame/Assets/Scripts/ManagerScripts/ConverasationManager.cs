using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverasationManager : MonoBehaviour
{
    private SceneTransitionManager stm;
    public GameObject conversationStartPanel;
    public bool conversationTerminated;

    void Start()
    {
        conversationStartPanel.SetActive(false);
        conversationTerminated = false;
        stm = FindObjectOfType<SceneTransitionManager>();
    }

    public void PromptConversation() {
        conversationStartPanel.SetActive(true);
    }

    public void CommenceConversation() {
        //handover player and npc position to game manager if possible
        GameManager.instance.playerLocation = GameManager.instance.player.transform;
        stm.LoadLevel("ConversationScreen");
    }

    public void CancelConversation() {
        conversationStartPanel.SetActive(false);
        conversationTerminated = true;
    }
}
