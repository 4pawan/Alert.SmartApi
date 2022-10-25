using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Alert.SmartApi
{
    public class NotifyUser
    {
        public static void sendMessage(string message)
        {            
            Task.Run(() => TelegramMessanger.sendMessageAsync(message));
        }
    }
}
