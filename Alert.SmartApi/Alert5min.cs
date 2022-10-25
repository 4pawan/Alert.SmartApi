using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Alert.SmartApi
{
    public class Alert5min
    {
        [FunctionName("Alert5min")]
        public void Run([TimerTrigger("0 1/5 4-10 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            QueueUtil.SendMesage();
        }
    }
}
