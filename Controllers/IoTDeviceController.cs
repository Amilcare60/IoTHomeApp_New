using Microsoft.AspNetCore.Mvc;

namespace IoTHomeApp_New.Controllers
{
    [ApiController]
    [Route("api/iot")]
    public class IoTDeviceController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetDeviceStatus()
        {
            var devices = new[]
            {
                new { Name = "PC", Status = "Online", IP = "192.168.1.2" },
                new { Name = "SmartTV", Status = "Offline", IP = "192.168.1.3" },
                new { Name = "SmartLight", Status = "Online", IP = "192.168.1.4" }
            };

            return Ok(devices);
        }

        [HttpPost("command")]
        public IActionResult SendCommand([FromBody] DeviceCommand command)
        {
            return Ok($"Comando '{command.Action}' inviato a {command.Device}");
        }
    }

    public record DeviceCommand(string Device, string Action);
}
