using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverasationManager : MonoBehaviour
{
    public GameObject conversationStartPanel;

    void Start()
    {
        conversationStartPanel.SetActive(false);
    }

    public void PromptConversation() {
        conversationStartPanel.SetActive(true);
    }

    public void CommenceConversation() {
        Debug.Log("CHANGING SCENE");
    }

    public void CancelConversation() {
        conversationStartPanel.SetActive(false);
    }
}
