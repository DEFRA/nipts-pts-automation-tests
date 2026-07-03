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
                // Do not swallow: a failed send previously looked like success and surfaced
                // later as a misleading status-check failure. Rethrow so the failure is reported
                // at the point the message could not be sent.
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
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
