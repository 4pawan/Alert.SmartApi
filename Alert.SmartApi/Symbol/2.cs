using AngelBroking;
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
        public static void ReportUnusualChanges(DateTime dt, AngelBroking.SmartApi connect)
        {
            var spike = CalculateDaysSpike(dt, connect);
            NotifyUser.sendMessage(spike);
        }
        public static string CalculateDaysSpike(DateTime dt, AngelBroking.SmartApi connect)
        {
            string precDayClose = ReadPrevDayClose();
            string data = GetLatestPrice(dt, connect);
            //todo:            
            // 2. call api and compare
            return precDayClose + data;
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
            return content;
        }


        public static string GetLatestPrice(DateTime date, AngelBroking.SmartApi connect)
        {
            CandleRequest cdreq = new CandleRequest();
            cdreq.exchange = Constants.EXCHANGE_NSE;
            cdreq.symboltoken = "2";
            cdreq.interval = Constants.INTERVAL_FIVE_MINUTE;
            DateTime dt = date.AddMinutes(-1);
            cdreq.fromdate = dt.AddMinutes(-5).ToString(Configuration.dateFormat); //2022-08-16 11:45
            cdreq.todate = dt.ToString(Configuration.dateFormat);  // 2022-08-16 12:15

            var obj = connect.GetCandleData(cdreq);
            CandleDataResponse cd = obj.GetCandleDataResponse;

            if (cd == null)
                return "33--";

            if (cd.data == null)
                return cd.status ? Message.SucessNoData : string.Format(Message.ErrorNoData, cd.message);

            var data = cd.data.FirstOrDefault();
            if (cd.status && data != null)
            {
                return $"close: {data[5]}"; ;
            }
            return "null";
        }
    }
}
