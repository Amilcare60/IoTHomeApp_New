# IoTHomeApp_New

Applicazione per la gestione e la comunicazione tra dispositivi domestici (PC, Smart TV, ecc.) tramite tecnologie IoT.

## Tecnologie utilizzate

- **C# / .NET**
- **Visual Studio Code**
- **Swagger** (per la documentazione delle API)
- **SSMS** (SQL Server Management Studio, per la gestione del database)
- **Mosquitto** (broker MQTT per la comunicazione tra dispositivi)
- **Git & GitHub** (versionamento e collaborazione)

## Funzionalità principali

- Gestione dispositivi IoT tramite API REST
- Comunicazione tra dispositivi tramite MQTT
- Interfaccia di test API tramite Swagger

## API disponibili

### Home

- **GET** `/api/home/devices`  
  Restituisce la lista dei dispositivi IoT registrati.

### IoTDevice

- ### IoTDevice

- **GET** `/api/iot/status`  
  Restituisce lo stato attuale dei dispositivi IoT.

- **POST** `/api/iot/command`  
  Invia un comando a uno o più dispositivi IoT.

- **PUT** `/api/iot/update`  
  Aggiorna le informazioni di un dispositivo IoT esistente.  
  **Esempio di richiesta JSON:**
  ```json
  {
    "name": "SmartTV",
    "status": "Online",
    "ip": "192.168.1.3"
  }
  ```

## Come avviare il progetto

1. Clona il repository:
   ```sh
   git clone https://github.com/Amilcare60/IoTHomeApp_New.git
   ```
2. Apri la cartella in Visual Studio Code.
3. Ripristina i pacchetti NuGet e avvia il progetto.
4. Accedi a Swagger su `http://localhost:5000/swagger` (o la porta configurata).

## Note

- Assicurati che Mosquitto sia in esecuzione per la comunicazione MQTT.
- Configura il database tramite SSMS se necessario.
## Come contribuire

1. Fai un fork del repository.
2. Crea un nuovo branch per la tua modifica:
   ```sh
   git checkout -b nome-branch
   ```
3. Apporta le modifiche desiderate.
4. Fai commit e push delle modifiche:
   ```sh
   git add .
   git commit -m "Descrizione della modifica"
   git push origin nome-branch
   ```
5. Apri una Pull Request su GitHub.
---

**Autore:** Amilcare60  