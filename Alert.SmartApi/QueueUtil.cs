using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Alert.SmartApi
{
    public class QueueUtil
    {
        static string queueName = "myqueue";
        static string storageConnString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

        public static void SendMesage(QueueData data)
        {
            QueueClient queue = new QueueClient(storageConnString, queueName);
            string message = JsonConvert.SerializeObject(data);
            queue.SendMessage(message);
        }

        public static Response<QueueMessage> ReadMesage()
        {
            QueueClient queue = new QueueClient(storageConnString, queueName);
            // Send a message to our queue
            return queue.ReceiveMessage();
        }

    }
}
