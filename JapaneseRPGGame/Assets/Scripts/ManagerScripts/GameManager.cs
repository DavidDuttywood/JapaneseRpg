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
    //coll.SendMessage("ReceiveDamage", dmg);

    private void Awake()
    {
        conversationPartnerPosition = Vector3.zero;
        instance = this;
        Load();
        gameProgress = new GameProgress();
        interactButton.interactable = true;
        interactButton.onClick.AddListener(delegate { InteractButtonClick(); });
    }

    public void InteractButtonClick()
    {
        if (player.colliding && player.coll != null)
        {
            player.coll.SendMessage("Interact");
        }
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

        File.WriteAllText(Application.persistentDataPath + "save.txt", json);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "save.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "save.txt");
            gameProgress = JsonUtility.FromJson<GameProgress>(saveString);

            player.transform.position = new Vector3(gameProgress.playerPositionX, gameProgress.playerPositionY);
            conversationPartner = gameProgress.conversationPartner;
            conversationPartnerPosition = new Vector3(conversationPartnerPosition.x, conversationPartnerPosition.y);

        }
    }
}
