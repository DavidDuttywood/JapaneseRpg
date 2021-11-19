using System;
using System.Collections.Generic;

public class GameProgress
{
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
