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

    // Start is called before the first frame update
    public void Start()
    {
        dialougeBox.SetActive(false);
        player = FindObjectOfType<Player>();
    }

    public void Update()
    {
        player.interactButton.interactable = !uitt.isTyping;
    }

    public void ShowDialogue()
    {
        player.canMove = false;
        dialougeBox.SetActive(true);
        uitt.Type(dialogueLine);
    }

    //public void ShowDialogueCutscene(string msg)
    //{
    //    player.canMove = false;
    //    dialougeBox.SetActive(true);
    //    uitt.Type(msg);
    //}

    public void CloseDialogue()
    {
        player.canMove = true;
        dialougeBox.SetActive(false);
    }
}