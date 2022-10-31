using System;
using Alert.SmartApi.Symbol;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Alert.SmartApi
{
    public class Alert5min
    {
        //[Disable("Alert5min")]
        //[FunctionName("Alert5min")]
        //public void Run([TimerTrigger("0 1/5 4-10 * * 1-5")] TimerInfo myTimer, ILogger log)
        //{
        //    DateTime dt = DateTime.UtcNow.ToIstDateTime();
        //    var connect = new AngelBroking.SmartApi(Constant.api_key, "", "");
        //    connect.GenerateSession(Constant.client_code, Constant.password, connect.GetTotp());
        //    connect.GenerateToken();

        //    _2.ReportUnusualChanges(dt, connect);
        //}
    }
}
