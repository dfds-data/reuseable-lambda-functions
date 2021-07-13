using System.Text.Json.Serialization;

namespace AlarmPostToWebHook.models
{
    public class Detail
    {
        [JsonPropertyName("alarmName")] public string AlarmName { get; set; }
        [JsonPropertyName("state")] public State State { get; set; }
    }
}