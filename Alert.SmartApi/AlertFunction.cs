using System;
using Alert.SmartApi.Symbol;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Alert.SmartApi
{
    public class AlertFunction
    {
        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 16/15 4-10 * * 1-5")] TimerInfo myTimer, ILogger log)
        {
            // 0 16/30 4-10 * * 1-5                                   
           
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            string JWTToken = "";  // optional
            string RefreshToken = ""; // optional
            DateTime utcdate = DateTime.UtcNow;
            var istdate = utcdate.ToIstDateTime();
            var connect = new AngelBroking.SmartApi(Constant.api_key, JWTToken, RefreshToken);
            connect.GenerateSession(Constant.client_code, Constant.pin, connect.GetTotp());
            connect.GenerateToken();
            var nxtGetNextOccurrence = myTimer.Schedule.GetNextOccurrence(utcdate);
            string msg = $"nxt:{nxtGetNextOccurrence.ToString(Configuration.dateFormat)}.." +
                         $"..validating at {istdate.ToString(Configuration.dateFormat)}..";
            //NotifyUser.sendMessage(msg);
            string _467data = new _467().ReportUnusualChanges(connect, istdate);
            NotifyUser.sendMessage(_467data);

            log.LogInformation("===================");
            connect.LogOut(Constant.client_code);
        }
    }
}
