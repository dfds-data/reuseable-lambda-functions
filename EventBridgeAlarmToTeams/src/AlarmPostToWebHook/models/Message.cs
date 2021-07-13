using System.Text.Json.Serialization;

namespace AlarmPostToWebHook.models
{
    public class Message
    {
        [JsonPropertyName("text")] public string Text { get; }

        public Message(string text)
        {
            this.Text = text;
        }

        public static implicit operator Message(SingleMetricAlarmEvent alarmEvent)
        {
            return new Message(
                $"Alarm {alarmEvent.Detail.AlarmName} entered state \"{alarmEvent.Detail.State.Value}\"" +
                $" at {alarmEvent.Time}:\n {alarmEvent.Detail.State.Reason}");
        }
    }
}