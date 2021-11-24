using System;
using System.Collections.Generic;

namespace BigData {

    public class TestData
    {
        public class ObjectiveItem
        {
            public int Id { get; set; }
            public string ObjectiveName { get; set; }
            public string ObjectiveHelpText { get; set; }
        }

        public static List<ObjectiveItem> GenerateObjectives()
        {
            return new List<ObjectiveItem>()
            {
                new ObjectiveItem()
                {
                    Id = 1,
                    ObjectiveName = "Talk to the Maid",
                    ObjectiveHelpText = "Practice <i>introductions</i>",
                },
                new ObjectiveItem()
                {
                    Id = 2,
                    ObjectiveName = "Go to the red building",
                    ObjectiveHelpText = "whats in it?!",
                },
                new ObjectiveItem()
                {
                    Id = 3,
                    ObjectiveName = "Talk to your Boss",
                    ObjectiveHelpText = "Hi Boss!",
                },
            };
        }

        public class Conversation
        {
            public List<ConversationItem> ConversationItems { get; set; }

            public string GrammarHelp { get; set; }

            public string ExitText { get; set; }

            public int ObjectiveId { get; set; } //do this for interactable objects too in future.
        }

        public class ConversationItem
        {
            public string NpcText { get; set; }

            public List<string> Replies { get; set; }

            public string CorrectReply { get; set; }
        }

        public static Conversation GenerateTestConversation()
        {
            return new Conversation
            {
                ConversationItems = new List<ConversationItem>
                {
                    new ConversationItem
                    {
                        NpcText = "Hi, <i>what</i> is your name?",
                        Replies = new List<string>()
                        {
                            "David",
                            "Yusuke",
                            "Bob",
                            "Jerry",
                        },
                        CorrectReply = "David"
                    },
                    new ConversationItem
                    {
                        NpcText = "Cool, Where are you from?",
                        Replies = new List<string>()
                        {
                            "England",
                            "China",
                            "Here, Actually",
                            "Canada",
                        },
                        CorrectReply = "England",
                    }
                },
                GrammarHelp = "This is just a placeholder for an explanation of some grammar",
                ExitText = "I really feel like we know each other better now!",
                ObjectiveId = 1,
            };
        }
    }
}
