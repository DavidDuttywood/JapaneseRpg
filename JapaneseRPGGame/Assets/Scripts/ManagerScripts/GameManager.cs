using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using static GameProgress;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string sceneName;

    public Player player;
    public PlayerLocation playerLocation;

    public string conversationPartner;
    public Vector3 conversationPartnerPosition;

    public ObjectiveProgress objectiveProgress;

    public GameMenu menu;
    public NotificationMessageManager nmm;
    public AudioSource music;
    public VideoClip conversationBackground;


    private void Awake()
    {
        instance = this;
    }

    public void SetPlayerLocationAndScene()
    {
        string json = JsonUtility.ToJson(playerLocation);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "playerLocation.txt"), json);

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
        //File.WriteAllText(Application.persistentDataPath + "conversationPartnerCache.txt", json);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "conversationPartnerCache.txt"), json);

    }

    public void LoadPlayerLocation()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "/playerLocation.txt"))) //DW - HERE, filepath fooked
        {
            string saveString = File.ReadAllText(Application.persistentDataPath + "/playerLocation.txt");
            playerLocation = JsonUtility.FromJson<PlayerLocation>(saveString);

            //set the player to correct position;
            player.transform.position = new Vector3(playerLocation.playerPositionX, playerLocation.playerPositionY);
            //conversationPartner = playerLocation.conversationPartner;
            conversationPartnerPosition = new Vector3(conversationPartnerPosition.x, conversationPartnerPosition.y);
            sceneName = playerLocation.sceneName;
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
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "objectiveProgress.txt"), json);

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
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "objectiveProgress.txt"), json);

        }
    }

    public void InitObjectiveProgress()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "objectiveProgress.txt")))
        {
            string saveString = File.ReadAllText(Path.Combine(Application.persistentDataPath, "objectiveProgress.txt"));
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
        File.Delete(Path.Combine(Application.persistentDataPath, "objectiveProgress.txt"));
        File.Delete(Path.Combine(Application.persistentDataPath, "conversationPartnerCache.txt"));
        File.Delete(Path.Combine(Application.persistentDataPath,"playerLocation.txt"));
    }

    public void ChangeMusic(AudioClip newClip)
    {
        music.Stop();
        music.clip = newClip;
        music.Play();
    }
}