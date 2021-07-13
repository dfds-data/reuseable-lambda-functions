using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AlarmPostToWebHook.models;

namespace AlarmPostToWebHook
{
    public class AlertForwarderService
    {
        private readonly HttpClient _client;

        public AlertForwarderService()
        {
            _client = new HttpClient();
        }

        public AlertForwarderService(HttpClient client)
        {
            this._client = client;
        }

        public async Task PostEventToWebHook(SingleMetricAlarmEvent alarmEvent)
        {
            var requestUri = System.Environment.GetEnvironmentVariable("WEBHOOK_URI");
            if (requestUri == null)
            {
                throw new InvalidOperationException("Environmental variable WEBHOOK_URI must be set!");
            }

            Message message = alarmEvent;
            var httpResponseMessage =
                await _client.PostAsync(requestUri,
                    new StringContent(JsonSerializer.Serialize(message), Encoding.UTF8));
        }
    }
}