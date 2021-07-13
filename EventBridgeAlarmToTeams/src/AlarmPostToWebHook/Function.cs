using System.Threading.Tasks;
using AlarmPostToWebHook.models;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlarmPostToWebHook
{
    public class Function
    {
        public async Task FunctionHandler(SingleMetricAlarmEvent alarmEvent, ILambdaContext context)
        {
            var alertForwarderService = new AlertForwarderService();
            await alertForwarderService.PostEventToWebHook(alarmEvent);
        }
    }
}