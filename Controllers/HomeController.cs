using Microsoft.AspNetCore.Mvc;

namespace IoTHomeApp_New.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet("devices")]
        public IActionResult GetDevices()
        {
            var devices = new[]
            {
                new { Name = "PC", Status = "Online", IP = "192.168.1.2" },
                new { Name = "SmartTV", Status = "Offline", IP = "192.168.1.3" },
                new { Name = "SmartLight", Status = "Online", IP = "192.168.1.4" }
            };

            return Ok(devices);
        }
    }
}
