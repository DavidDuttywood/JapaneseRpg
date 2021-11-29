using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialougeBox;
    public Player player;
    public Text dialougeText;
    public UITextTypeWriter uitt;

    public string dialogueLine;

    public void Start()
    {
        //dialougeBox.SetActive(false);
        player = FindObjectOfType<Player>();
        dialougeBox.SetActive(false);
    }

    public void Update()
    {
        GameManager.instance.interactButton.interactable = !uitt.isTyping;
    }

    public void ShowDialogue()
    {
        //player.canMove = false;
        dialougeBox.SetActive(true);
        uitt.Type(dialogueLine);
    }

    public void CloseDialogue()
    {
         //player.canMove = true;
        dialougeBox.SetActive(false);
    }
}