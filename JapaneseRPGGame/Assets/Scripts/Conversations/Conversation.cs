using System;
using System.Collections.Generic;

namespace Data
{
    public class Conversation
    {
        public List<ConversationItem> ConversationItems { get; set; }

        public string GrammarHelp { get; set; }

        public string ExitText { get; set; }

        public Conversation GenerateTestConversation()
        {
            return new Conversation
            {
                ConversationItems = new List<ConversationItem>
                {
                    new ConversationItem
                    {
                        NpcText = "Hi, what is your name?",
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
            };
        }
    }

    public class ConversationItem
    {
        public string NpcText { get; set; }

        public List<string> Replies { get; set; }

        public string CorrectReply { get; set; }
    }

}