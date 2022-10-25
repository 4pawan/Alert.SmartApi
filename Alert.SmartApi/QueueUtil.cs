using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alert.SmartApi
{
    public class QueueUtil
    {
        static string queueName = "myqueue";
        static string storageConnString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        static QueueClient client = new QueueClient(storageConnString, queueName);

        public static void SendMesage(QueueData data)
        {
            string message = JsonConvert.SerializeObject(data);
            client.SendMessage(message);
        }

        public static QueueData ReadMesage()
        {
            try
            {
                Response<QueueMessage> msg = client.ReceiveMessage();
                var content = Encoding.ASCII.GetString(msg.Value.Body);
                QueueData data = JsonConvert.DeserializeObject<QueueData>(content);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static void ClearMessages()
        {
            client.ClearMessages();
        }

    }
}
