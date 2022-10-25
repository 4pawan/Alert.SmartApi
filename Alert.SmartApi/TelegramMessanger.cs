using Telegram.Bot;
using Telegram.Bot.Types;

namespace Alert.SmartApi
{
    public class TelegramMessanger
    {
        //https://api.telegram.org/bot12345678:ADAFEWQDLKDS*&^SD%FEWRRr/getUpdates  migrate_to_chat_id
        // https://stackoverflow.com/questions/31271355/how-to-use-telegram-api-in-c-sharp-to-send-a-message
        // https://stackoverflow.com/questions/32423837/telegram-bot-how-to-get-a-group-chat-id
        static ChatId Id = new ChatId(Constant.Telegram_chatId);
        static ITelegramBotClient botClient = new TelegramBotClient(Constant.Telegram_token);

        public static async void sendMessageAsync(string message)
        {
            await botClient.SendTextMessageAsync(Id, message,Telegram.Bot.Types.Enums.ParseMode.Html);
        }
    }
}
