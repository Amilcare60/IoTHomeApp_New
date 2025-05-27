# 🚀 AppIoTHome - Gestione dispositivi IoT con SQL Server e Entity Framework Core

## 📌 Introduzione
AppIoTHome è un'API sviluppata in **ASP.NET Core** con **Entity Framework Core** per gestire dispositivi IoT.  
I dispositivi vengono salvati in **SQL Server**, permettendo operazioni CRUD (Create, Read, Update, Delete).  

---

## 🛠️ Configurazione del progetto

### 1️⃣ **Creazione del database `AppIoTHomeDB` in SQL Server**
Esegui i seguenti comandi in **SQL Server Management Studio (SSMS)**:
```sql
CREATE DATABASE AppIoTHomeDB;
USE AppIoTHomeDB;
CREATE TABLE Devices (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DeviceName NVARCHAR(100) NOT NULL,
    Status NVARCHAR(20) NOT NULL
);
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

using Microsoft.EntityFrameworkCore;
using AppIoTHome.Models;

namespace AppIoTHome.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<DeviceStatus> Devices { get; set; }
    }
}

dotnet ef migrations add InitialCreate
dotnet ef database update

SELECT * FROM Devices;

curl -X GET http://localhost:5246/device-list

dotnet clean
dotnet build
dotnet run

apri swagger
http://localhost:5246/swagger/index.html
