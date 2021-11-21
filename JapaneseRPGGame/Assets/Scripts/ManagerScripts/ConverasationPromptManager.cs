using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverasationPromptManager : MonoBehaviour
{
    private SceneTransitionManager stm;
    public GameObject conversationStartPanel;

    void Start()
    {
        conversationStartPanel.SetActive(false);
        stm = FindObjectOfType<SceneTransitionManager>();
    }

    public void PromptConversation() {
        conversationStartPanel.SetActive(true);
    }

    public void CommenceConversation() {
        GameManager.instance.playerLocation = new GameProgress.PlayerLocation()
        {
            playerPositionX = GameManager.instance.player.transform.position.x,
            playerPositionY = GameManager.instance.player.transform.position.y,
        };

        GameManager.instance.SetPlayerLocation();

        GameManager.instance.conversationPartner = name;
        GameManager.instance.conversationPartnerPosition = new Vector3(transform.position.x, transform.position.y);
        GameManager.instance.SaveConversationPartner();

        stm.LoadLevel("ConversationScreen");
    }

    public void CancelConversation() {
        conversationStartPanel.SetActive(false);
    }
}
