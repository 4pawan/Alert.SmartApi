﻿using Alert.SmartApi.Abstract;
using AngelBroking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alert.SmartApi.Symbol
{
    public class _467 : IUnusualChanges
    {
        public const double VolumeThreshold = 663393;
        public string ReportUnusualChanges(AngelBroking.SmartApi connect, DateTime date)
        {
            //date = new DateTime(2022, 09, 01, 13, 00, 34); // "01-dd/09-mm/2022 06:20:18 PM ;
            //Get Candle Data
            CandleRequest cdreq = new CandleRequest();
            cdreq.exchange = Constants.EXCHANGE_NSE;
            cdreq.symboltoken = "467";
            cdreq.interval = Constants.INTERVAL_THIRTY_MINUTE;
            DateTime dt = date.AddMinutes(-1);
            cdreq.fromdate = dt.AddMinutes(-30).ToString(Configuration.dateFormat); //2022-08-16 11:45
            cdreq.todate = dt.ToString(Configuration.dateFormat);  // 2022-08-16 12:15

            var obj = connect.GetCandleData(cdreq);
            CandleDataResponse cd = obj.GetCandleDataResponse;

            if (cd == null)
                return null;

            if (cd.data == null)
                return cd.status ? Message.SucessNoData : string.Format(Message.ErrorNoData, cd.message);

            var data = cd.data.FirstOrDefault();
            if (cd.status && data != null)
            {
                var unusualChanges = IdentityUnusualChanges(data);
                if (unusualChanges != null)
                {
                    var time = Convert.ToDateTime(data[0]).ToIstDateTime().ToString(Configuration.timeFormat);
                    string volume = ((long)data[5]) > VolumeThreshold ? $"<b>{data[5]}</b>" : $"{data[5]}";
                    string summary = unusualChanges != Message.Normal ? $"<b>{unusualChanges}</b> ," : "";
                    string message = $"{summary} time: {time},Open: {data[1]}, high:{data[2]},low: {data[3]},close: {data[4]}," +
                        $"volume: {volume}";
                    return message;
                }
            }
            return null;
        }

        private string IdentityUnusualChanges(List<object> data)
        {
            if (data == null)
                return null;

            double open = (double)data[1];
            double high = (double)data[2];
            double low = (double)data[3];
            double close = (double)data[4];
            long vol = (long)data[5];

            double lowToHigh = high - low;
            //green candle
            if (lowToHigh > 0)
            {
                var percenthigh = (lowToHigh / low) * 100;
                if (percenthigh > 0.9)
                {
                    return string.Format(Message.HighPercent, Math.Round(percenthigh, 2));
                }
            }

            //red candle
            if (lowToHigh <= 0)
            {
                var percentlow = (Math.Abs(lowToHigh) / low) * 100;
                if (percentlow > 0.9)
                {
                    return string.Format(Message.LowPercent, Math.Round(percentlow, 2));
                }
            }

            //high volume
            if (vol > VolumeThreshold)
            {
                return string.Format(Message.HighVolume, vol);
            }

            return Message.Normal;
        }
    }
}