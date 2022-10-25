using Azure.Storage.Queues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Alert.SmartApi
{

    public class QueueData
    {
        public int Code { get; set; }
        public double PrevDayClose { get; set; }
    }


    public class QueueUtil
    {
        string connectionString = "<connection_string>";
        static string queueName = "myqueue";

        public static void SendMesage()
        {
            string storageConnString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            QueueClient queue = new QueueClient(storageConnString, queueName);
            string message = JsonConvert.SerializeObject(new QueueData { Code = 2, PrevDayClose = 2345 });
            queue.SendMessage(message);
        }

        public void ReadMesage()
        {
            QueueClient queue = new QueueClient(connectionString, queueName);
            // Send a message to our queue
            var message = queue.ReceiveMessage();
        }

    }
}
