using Azure.Messaging.ServiceBus;
using nipts_pts_API_tests.Configuration;

namespace nipts_pts_API_tests.Application
{
    public class ServiceBusConnection
    {
        static string connectionString = ServiceBusConnectionData.Configuration.ServiceBusConnString;
        static string queueName = ServiceBusConnectionData.Configuration.ServiceBusQueueName;

        public static async Task SendMessageToQueue(string ApplicationId, string Status)
        {
            // Create a ServiceBusClient to connect to the Service Bus namespace
            ServiceBusClient client = new ServiceBusClient(connectionString);

            // Create a ServiceBusSender for the queue
            ServiceBusSender sender = client.CreateSender(queueName);

            try
            {
                // Create a unique DynamicId for each message
                string dynamicId = Guid.NewGuid().ToString();

                // Create a message to send to the queue
                string messageBody = $"{{ \"Application.Id \": \"{ApplicationId}\", \"Application.DynamicId\": \"{dynamicId}\", \"Application.StatusId\": \"{Status}\", \"Application.DateAuthorised\": \"2024-11-14\" }}";
                ServiceBusMessage message = new ServiceBusMessage(messageBody);

                // Send the message to the queue
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Message sent: {messageBody}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                // Dispose of the sender and client
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
