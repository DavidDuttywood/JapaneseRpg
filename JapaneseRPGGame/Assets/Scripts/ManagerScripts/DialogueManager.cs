using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialougeBox;
    public Player player;
    public Text dialougeText;

    public string dialogueLine;

    // Start is called before the first frame update
    public void Start()
    {
        dialougeBox.SetActive(false);
        player = FindObjectOfType<Player>();
    }

    public void ShowDialogue()
    {
        player.canMove = false;
        dialougeBox.SetActive(true);
        dialougeText.text = dialogueLine;
    }

    public void CloseDialogue()
    {
        player.canMove = true;
        dialougeBox.SetActive(false);
    }
}