using System.Text.Json.Serialization;

namespace AlarmPostToWebHook.models
{
    public class State
    {
        [JsonPropertyName("reason")] public string Reason { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }
    }
}