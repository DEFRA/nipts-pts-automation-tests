using Azure.Messaging.ServiceBus;
using nipts_pts_API_tests.Configuration;

namespace nipts_pts_API_tests.Application
{
    public class ServiceBusConnection
    {
        static string connectionString = ServiceBusConnectionData.Configuration.ServiceBusConnString;

        public static async Task SendMessageToQueue(string messageBody,string queueName)
        {
            // Create a ServiceBusClient to connect to the Service Bus namespace
            ServiceBusClient client = new ServiceBusClient(connectionString);

            // Create a ServiceBusSender for the queue
            ServiceBusSender sender = client.CreateSender(queueName);

            try
            {
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
