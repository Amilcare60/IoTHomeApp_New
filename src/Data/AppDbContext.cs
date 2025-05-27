using Microsoft.EntityFrameworkCore;
using AppIoTHome.Models;

namespace AppIoTHome.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DeviceStatus> Devices { get; set; } // 🔹 Rappresenta la tabella `Devices`
    }
}
