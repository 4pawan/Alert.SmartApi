using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.SmartApi.Symbol
{
    public class _2
    {
        public static void ReportUnusualChanges(DateTime dt)
        {
            var spike = CalculateDaysSpike(dt);
            NotifyUser.sendMessage(spike);
        }
        public static string CalculateDaysSpike(DateTime dt)
        {
            //todo: call api
            return "spike was found" + dt.ToShortTimeString();
        }
        public static string ReadPrevDayClose()
        {
            //todo: call api
            var data = new QueueData { Code = 2, PrevDayClose = 2345 };
            QueueUtil.SendMesage(data);
            return "PrevDayClose";
        }
    }
}
