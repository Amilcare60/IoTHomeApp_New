namespace AppIoTHome.Models
{
    public class DeviceStatus
    {
        public int Id { get; set; } // 🔹 Chiave primaria per il database
        public string DeviceName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DeviceStatus() {} // 🔹 Costruttore vuoto necessario per EF Core
        public DeviceStatus(string deviceName, string status)
        {
            DeviceName = deviceName;
            Status = status;
        }
    }
}


