using Azure;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
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
            string precDayClose = ReadPrevDayClose();
            //todo:            
            // 2. call api and compare
            return precDayClose;
        }
        public static string ReadPrevDayClose()
        {
            Response<QueueMessage> msg = QueueUtil.ReadMesage();
            QueueMessage val = msg.Value;
            var content = Encoding.ASCII.GetString(val.Body);
            QueueData data = JsonConvert.DeserializeObject<QueueData>(content);

            //todo: call api
            //var data = new QueueData { Code = 2, PrevDayClose = 17512 };
            //QueueUtil.SendMesage(val.Body);
            return content + " : " + data.Code;
        }
    }
}
