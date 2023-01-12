using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.SmartApi
{
    public class Configuration
    {
        public const string dateFormat = "yyyy-MM-dd HH:mm";
        public const string timeFormat = "hh:mm tt";
    }

    public class Message
    {
        public const string SucessNoData = "no_data";
        public const string ErrorNoData = "error {0}";
        public const string HighVolume = "{0} highVol";
        public const string HighPercent = "{0}% high";
        public const string LowPercent = "{0}% low";
        public const string Normal = "normal";
    }
}