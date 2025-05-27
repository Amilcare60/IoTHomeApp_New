using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IoTHomeApp_New.Controllers
{
    [ApiController]
    [Route("api/iot")]
    public class IoTDeviceController : ControllerBase
    {
        // Lista dispositivi in memoria
        private static List<IoTDevice> _devices = new List<IoTDevice>
        {
            new IoTDevice("PC", "Online", "192.168.1.2"),
            new IoTDevice("SmartTV", "Offline", "192.168.1.3"),
            new IoTDevice("SmartLight", "Online", "192.168.1.4")
        };

        [HttpGet("status")]
        public IActionResult GetDeviceStatus()
        {
            return Ok(_devices);
        }

        [HttpPost("command")]
public async Task<IActionResult> SendCommand([FromBody] DeviceCommand command)
{
    // Crea il client MQTT
    var factory = new MqttFactory();
    using var mqttClient = factory.CreateMqttClient();

    var options = new MqttClientOptionsBuilder()
        .WithTcpServer("localhost", 1883)
        .Build();

    await mqttClient.ConnectAsync(options);

    // Crea il messaggio da inviare
    var message = new MqttApplicationMessageBuilder()
        .WithTopic("home/devices/command")
        .WithPayload($"{command.Device}:{command.Action}")
        .Build();

    await mqttClient.PublishAsync(message);
    await mqttClient.DisconnectAsync();

    return Ok($"Comando '{command.Action}' inviato a {command.Device} via MQTT");
}

        [HttpPut("update")]
public IActionResult UpdateDevice([FromBody] IoTDevice device)
{
    // Cerca il dispositivo per nome e aggiorna i dati
    var existing = _devices.Find(d => d.Name == device.Name);
    if (existing != null)
    {
        existing.Status = device.Status;
        existing.IP = device.IP;
        // Qui puoi aggiungere la logica MQTT se serve
        return Ok($"Dispositivo '{device.Name}' aggiornato.");
    }
    else
    {
        return NotFound($"Dispositivo '{device.Name}' non trovato.");
    }
}

        [HttpPost("add")]
        public IActionResult AddDevice([FromBody] IoTDevice device)
        {
            _devices.Add(device);
            return Ok($"Dispositivo '{device.Name}' aggiunto.");
        }

        [HttpGet("all")]
        public IActionResult GetAllDevices()
        {
            return Ok(_devices);
        }
    }

    public record DeviceCommand(string Device, string Action);

    public class IoTDevice
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string IP { get; set; }

        public IoTDevice(string name, string status, string ip)
        {
            Name = name;
            Status = status;
            IP = ip;
        }
    }
}