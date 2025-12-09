namespace ChatbotIaJuridico.Domain.Models.JsonMetaModels
{
    public class audioMessageRecaivecs
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Audio
        {
            public string mime_type { get; set; }
            public string sha256 { get; set; }
            public string id { get; set; }
            public bool voice { get; set; }
        }

        public class Change
        {
            public Value value { get; set; }
            public string field { get; set; }
        }

        public class Contact
        {
            public Profile profile { get; set; }
            public string wa_id { get; set; }
        }

        public class Entry
        {
            public string id { get; set; }
            public List<Change> changes { get; set; }
        }

        public class Message
        {
            public string from { get; set; }
            public string id { get; set; }
            public string timestamp { get; set; }
            public string type { get; set; }
            public Audio audio { get; set; }
        }

        public class Metadata
        {
            public string display_phone_number { get; set; }
            public string phone_number_id { get; set; }
        }

        public class Profile
        {
            public string name { get; set; }
        }

        public class Root
        {
            public string @object { get; set; }
            public List<Entry> entry { get; set; }
        }

        public class Value
        {
            public string messaging_product { get; set; }
            public Metadata metadata { get; set; }
            public List<Contact> contacts { get; set; }
            public List<Message> messages { get; set; }
        }


    }
}
