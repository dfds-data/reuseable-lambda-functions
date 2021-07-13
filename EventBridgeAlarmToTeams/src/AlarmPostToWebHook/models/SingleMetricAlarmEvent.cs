using System;
using System.Text.Json.Serialization;

namespace AlarmPostToWebHook.models
{
    public class SingleMetricAlarmEvent
    {
        [JsonPropertyName("time")] public DateTime Time { get; set; }
        [JsonPropertyName("detail")] public Detail Detail { get; set; }
    }
}