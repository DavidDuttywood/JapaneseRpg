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

    public Player player;
    public string conversationPartner;
    public Vector3 conversationPartnerPosition;

    public PlayerLocation playerLocation;
    public ObjectiveProgress objectiveProgress;

    public GameMenu menu;
    public NotificationMessageManager nmm;
    public AudioSource music;

    private void Awake()
    {
        instance = this;
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
        if (!objectiveProgress.ObjectivesInProgress.Contains(objectiveId))
        {
            objectiveProgress.ObjectivesInProgress.Add(objectiveId);
            string json = JsonUtility.ToJson(objectiveProgress);
            File.WriteAllText(Application.persistentDataPath + "objectiveProgress.txt", json);
            menu.AddObjectiveToList(objectiveId); //opening it initialises it
        }
    }

    public void MarkObjectiveAsCompleted(int objectiveId)
    {
        if (objectiveProgress.ObjectivesInProgress.Contains(objectiveId))
        {
            objectiveProgress.ObjectivesInProgress.Remove(objectiveId);
            objectiveProgress.ObjectivesCompleted.Add(objectiveId);

            string json = JsonUtility.ToJson(objectiveProgress);
            File.WriteAllText(Application.persistentDataPath + "objectiveProgress.txt", json);
        }
    }

    public void InitObjectiveProgress()
    {
        if (File.Exists(Application.persistentDataPath + "objectiveProgress.txt"))
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "objectiveProgress.txt");
            objectiveProgress = JsonUtility.FromJson<ObjectiveProgress>(saveString);
        }
        else
        {
            objectiveProgress = new ObjectiveProgress();
        }
    }

    public void UINotification(string message)
    {
        nmm.ShowNotifcation(message);
    }

    public void Load()
    {
        LoadPlayerLocation();
        InitObjectiveProgress();
    }

    public void ClearSaveLogs()
    {
        File.Delete(Application.persistentDataPath + "objectiveProgress.txt");
        File.Delete(Application.persistentDataPath + "conversationPartnerCache.txt");
        File.Delete(Application.persistentDataPath + "playerLocation.txt");
    }

    public void ChangeMusic(AudioClip newClip)
    {
        music.Stop();
        music.clip = newClip;
        music.Play();
    }
}