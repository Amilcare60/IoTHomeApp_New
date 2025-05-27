using AppIoTHome.Models;
using AppIoTHome.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.WebHost.UseUrls("http://localhost:5246"); 

// ✅ Configurazione di SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost;Database=AppIoTHomeDB;Trusted_Connection=True;Encrypt=False"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// ✅ **Endpoint `GET` - Recupera tutti i dispositivi dal database**
app.MapGet("/device-list", async (AppDbContext db) => 
{
    var devices = await db.Devices.ToListAsync();
    return Results.Ok(devices);
})
.WithName("GetDeviceList");

// ✅ **Endpoint `POST` - Aggiunge un dispositivo al database**
app.MapPost("/add-device", async (AppDbContext db, DeviceStatus newDevice) =>
{
    db.Devices.Add(newDevice);
    await db.SaveChangesAsync();
    return Results.Ok(new { message = "Dispositivo aggiunto.", devices = await db.Devices.ToListAsync() });
})
.WithName("AddDevice");

// ✅ **Endpoint `PUT` - Aggiorna lo stato di un dispositivo**
app.MapPut("/update-device", async (AppDbContext db, DeviceStatus? updatedDevice) =>
{
    if (updatedDevice is null || string.IsNullOrEmpty(updatedDevice.DeviceName))
    {
        return Results.Ok(new { message = "Lista dispositivi disponibili per aggiornamento:", devices = await db.Devices.ToListAsync() });
    }

    var device = await db.Devices.FirstOrDefaultAsync(d => d.DeviceName == updatedDevice.DeviceName);
    if (device is null)
    {
        return Results.NotFound(new { message = $"Dispositivo '{updatedDevice.DeviceName}' non trovato.", devices = await db.Devices.ToListAsync() });
    }

    device.Status = updatedDevice.Status;
    await db.SaveChangesAsync();
    
    return Results.Ok(new { message = $"Dispositivo '{updatedDevice.DeviceName}' aggiornato.", devices = await db.Devices.ToListAsync() });
})
.WithName("UpdateDevice");

// ✅ **Endpoint `DELETE` - Rimuove un dispositivo dal database**
app.MapDelete("/delete-device/{id}", async (AppDbContext db, int id) =>
{
    var device = await db.Devices.FindAsync(id);
    if (device is null)
    {
        return Results.NotFound(new { message = $"Dispositivo con ID {id} non trovato.", devices = await db.Devices.ToListAsync() });
    }

    db.Devices.Remove(device);
    await db.SaveChangesAsync();

    return Results.Ok(new { message = $"Dispositivo con ID {id} eliminato con successo.", devices = await db.Devices.ToListAsync() });
})
.WithName("DeleteDeviceById");


Console.WriteLine("🚀 API avviata! Vai su: http://localhost:5246/swagger/index.html");

app.Run();
