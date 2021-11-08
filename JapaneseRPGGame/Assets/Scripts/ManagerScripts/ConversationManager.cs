using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    public UITextTypeWriter npcText;

    // Start is called before the first frame update
    void Start()
    {
        npcText.Type("Well hello there, how do you do?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
