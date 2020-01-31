using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using System.Text;
using EventHubRestApi.Interfaces;


namespace EventHubRestApi.Classes
{
    public class EventHub : IEventHub
    {
        private static EventHubClient eventHubClient;

        private const string EventHubConnectionString = "Endpoint=sb://cloud-hackers-eventhub.servicebus.windows.net/;SharedAccessKeyName=cloudhackersSAP;SharedAccessKey=OiR+cURXNOFommsGb2q+lmuDPVoYJty/OJcCDW82HoU=;EntityPath=cloud-hackers-events";
        private const string EventHubName = "cloud-hackers-events";

        public EventHub()
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        private void StopEventhub()
        {
            if(eventHubClient != null)
                eventHubClient.CloseAsync();
        }

        private void StartEventHub()
        {            

        }

        public async Task<string> SendMessage(string message)
        {            
            try
            {

                message = string.IsNullOrEmpty(message) ? "EMPTY MESSAGE" : message;


                Console.WriteLine($"Sending message: {message}");
                await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                return "Error Occured";
            }
            Console.WriteLine($"{message} messages sent.");
            return "Message Sent";
        }
    }
}
