using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameProgress : MonoBehaviour
{

    public ObjectiveProgress objectiveProgress;

    public void Start()
    {
        
    }

    public void LoadObjectiveProgress()
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

    public class PlayerLocation 
    {
        public float playerPositionX;
        public float playerPositionY;
    }

    public class ConversationPartner
    {
        public string conversationPartner;
        public float conversationPartnerPositionX;
        public float conversationPartnerPositionY;
    }
    
    public class ObjectiveProgress
    {
        public List<int> ObjectivesInProgress;
        public List<int> ObjectivesCompleted;

        public ObjectiveProgress()
        {
            ObjectivesInProgress = new List<int>();
            ObjectivesCompleted = new List<int>();
        }
    }

}
