using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Button interactButton;
    
    //when resuming gamplay after a scene change; we need to remember the positions of NPCS
    public Transform npcLocation;
    public Transform playerLocation;

    private void Awake()
    {
        instance = this;
    }
}
