using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AlarmPostToWebHook.models;
using Moq;
using Moq.Protected;
using Xunit;

namespace AlarmPostToWebHook.Tests
{
    public class AlertForwarderServiceTest
    {
        [Fact]
        public async Task TestPostEventToWebHook()
        {
            var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handler.Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("1")
                })
                .Verifiable();
            var client = new HttpClient(handler.Object);
            var service = new AlertForwarderService(client);

            var alarmEvent = new SingleMetricAlarmEvent()
            {
                Time = new DateTime(2021, 8, 8, 8, 8, 8),
                Detail = new Detail()
                {
                    AlarmName = "Test Alarm",
                    State = new State()
                    {
                        Reason = "This is just a test",
                        Value = "ALARM"
                    }
                }
            };
            Environment.SetEnvironmentVariable("WEBHOOK_URI", "http://lol.lol/");
            await service.PostEventToWebHook(alarmEvent);
        }
    }
}