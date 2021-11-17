using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Button interactButton;

    public string conversationPartner;
    public Vector3 conversationPartnerPosition;

    public GameProgress gameProgress;


    private void Awake()
    {
        conversationPartnerPosition = Vector3.zero;
        instance = this;
        Load();
        gameProgress = new GameProgress();
    }

    public void Save()
    {
        Vector3 playerPosition = player.transform.position;

        gameProgress.playerPositionX = playerPosition.x;
        gameProgress.playerPositionY = playerPosition.y;

        gameProgress.conversationPartner = conversationPartner;
        gameProgress.conversationPartnerPositionX = conversationPartnerPosition.y;
        gameProgress.conversationPartnerPositionY = conversationPartnerPosition.y;

        string json = JsonUtility.ToJson(gameProgress);

        File.WriteAllText(Application.dataPath + "save.json", json);
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "save.json"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "save.json");
            gameProgress = JsonUtility.FromJson<GameProgress>(saveString);

            player.transform.position = new Vector3(gameProgress.playerPositionX, gameProgress.playerPositionY);
            conversationPartner = gameProgress.conversationPartner;
            conversationPartnerPosition = new Vector3(conversationPartnerPosition.x, conversationPartnerPosition.y);

        }
    }
}
