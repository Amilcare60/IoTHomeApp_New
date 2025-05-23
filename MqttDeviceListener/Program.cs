using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace MqttDeviceListener
{
    class Program
    {
        static async Task Main()
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .Build();

            mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payload = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"Messaggio ricevuto: {payload}");
                return Task.CompletedTask;
            };

            await mqttClient.ConnectAsync(options);

            Console.WriteLine("Connesso a Mosquitto!");

            await mqttClient.SubscribeAsync("home/devices/command");
            Console.WriteLine("Sottoscritto al topic home/devices/command");

            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();

            await mqttClient.DisconnectAsync();
        }
    }
}