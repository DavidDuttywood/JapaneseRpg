using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using static GameProgress;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string sceneName;
    public Button interactButton;

    public Player player;
    public string conversationPartner;
    public Vector3 conversationPartnerPosition;

    public PlayerLocation playerLocation;
    public ObjectiveProgress objectiveProgress;

    public GameMenu menu;
    private NotificationMessageManager nmm;

    public GameProgress gp;

    private void Awake()
    {     
        gp = GameObject.Find("persistantGameStuff").GetComponentInChildren<GameProgress>();

        instance = this;
        if(interactButton != null)
        {
            interactButton.interactable = true;
            interactButton.onClick.AddListener(delegate { InteractButtonClick(); });
        }
                if(interactButton != null)

        nmm = FindObjectOfType<NotificationMessageManager>();

        if (nmm != null)
        {
            nmm.ShowNotifcation(sceneName);
        }
        //Load();
    }

    public void InteractButtonClick()
    {
        if (player.colliding && player.coll != null)
        {
            player.coll.SendMessage("Interact");
        }
    }

    public void SetPlayerLocation()
    {
        string json = JsonUtility.ToJson(playerLocation);
        File.WriteAllText(Application.persistentDataPath + "playerLocation.txt", json);
    }
    public void SaveConversationPartner()
    {
        ConversationPartner conversationPartnerDetails = new ConversationPartner()
        {
            conversationPartner = conversationPartner,
            conversationPartnerPositionX = conversationPartnerPosition.x,
            conversationPartnerPositionY = conversationPartnerPosition.y,
        };

        string json = JsonUtility.ToJson(conversationPartner);
        File.WriteAllText(Application.persistentDataPath + "conversationPartnerCache.txt", json);
    }

    public void LoadPlayerLocation()
    {
        if (File.Exists(Application.persistentDataPath + "playerLocation.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "playerLocation.txt");
            playerLocation = JsonUtility.FromJson<PlayerLocation>(saveString);

            //set the player to correct position;
            player.transform.position = new Vector3(playerLocation.playerPositionX, playerLocation.playerPositionY);
            //conversationPartner = playerLocation.conversationPartner;
            conversationPartnerPosition = new Vector3(conversationPartnerPosition.x, conversationPartnerPosition.y);
        }
        else
        {
            playerLocation = new PlayerLocation();
        }
    }

    public void BeginNewObjective(int objectiveId)
    {
        if (gp.objectiveProgress.ObjectivesInProgress.Contains(objectiveId))
        {
            gp.objectiveProgress.ObjectivesInProgress.Add(objectiveId);
            string json = JsonUtility.ToJson(objectiveProgress);
            File.WriteAllText(Application.persistentDataPath + "objectiveProgress.txt", json);
            menu.AddObjectiveToList(objectiveId);
        }
    }

    public void MarkObjectiveAsCompleted(int objectiveId)
    {
        if (gp.objectiveProgress.ObjectivesInProgress.Contains(objectiveId))
        {
            gp.objectiveProgress.ObjectivesInProgress.Remove(objectiveId);
            gp.objectiveProgress.ObjectivesCompleted.Add(objectiveId);
        }
        
        string json = JsonUtility.ToJson(objectiveProgress);
        File.WriteAllText(Application.persistentDataPath + "objectiveProgress.txt", json);
    }

    public void Load()
    {
        LoadPlayerLocation();
    }

    public void ClearSaveLogs()
    {
        File.Delete(Application.persistentDataPath + "objectiveProgress.txt");
        File.Delete(Application.persistentDataPath + "conversationPartnerCache.txt");
        File.Delete(Application.persistentDataPath + "playerLocation.txt");
    }

}