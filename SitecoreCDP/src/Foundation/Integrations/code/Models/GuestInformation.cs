using System.Text.Json.Serialization;

namespace SitecoreCDP.Foundation.Integrations.Models
{
    public class GuestInformation
    {
        [JsonPropertyName("guestType")]
        public string GuestType { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("nationality")]
        public string Nationality { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("firstSeen")]
        public string FirstSeen { get; set; }
        [JsonPropertyName("lastSeen")]
        public string LastSeen { get; set; }
    }
}