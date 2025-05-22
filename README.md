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

## # IoTHomeApp_New

Applicazione per la gestione e la comunicazione tra dispositivi domestici tramite API REST e MQTT.

## Come avviare il progetto

1. **Avvia Mosquitto**  
   Apri un terminale e lancia:
   ```sh
   mosquitto
   ```
   Lascia il terminale aperto: Mosquitto resterà in ascolto sulla porta 1883.

2. **Avvia la console app MQTT (opzionale, per testare la ricezione)**  
   Apri un nuovo terminale e spostati nella cartella della console app:
   ```sh
   cd C:\Users\paolo\Desktop\MqttDeviceListener
   dotnet run
   ```
   Vedrai:
   ```
   Connesso a Mosquitto!
   Sottoscritto al topic home/devices/update
   Premi un tasto per uscire..
   ```
   **Lascia la finestra aperta** per ricevere i messaggi MQTT.

3. **Avvia l’API**  
   Apri un altro terminale e spostati nella cartella del progetto API:
   ```sh
   cd "C:\Users\paolo\OneDrive\Desktop\IoTHomeApp_New - Copia"
   dotnet restore
   dotnet run
   ```
   L’API sarà disponibile su `http://localhost:5089/swagger`.

4. **Aggiungi dispositivi tramite Swagger**  
   - Vai su `http://localhost:5089/swagger`
   - Espandi la sezione **POST /api/iot/add**
   - Clicca su **Try it out** e inserisci un JSON come:
     ```json
     {
       "name": "NuovoDispositivo",
       "status": "Online",
       "ip": "192.168.1.100"
     }
     ```
   - Premi **Execute**  
   - Vedrai la conferma che il dispositivo è stato aggiunto.

5. **Aggiorna o visualizza dispositivi**
   - Per aggiornare un dispositivo: usa **PUT /api/iot/update**
   - Per vedere tutti i dispositivi: usa **GET /api/iot/all**

6. **Testa la comunicazione MQTT**
   - Dopo aver aggiunto o aggiornato un dispositivo, guarda il terminale della console app MQTT: dovresti vedere il messaggio ricevuto.

## Note

- Se ricevi un errore "address already in use", libera la porta con:
  ```sh
  netstat -ano | findstr :5089
  taskkill /PID <PID> /F
  ```
- Puoi anche testare la ricezione MQTT con il comando:
  ```sh
  mosquitto_sub -h localhost -t home/devices/update
  ```
- Configura il database tramite SSMS se necessario.

Aggiornare il READme
cd "C:\Users\paolo\OneDrive\Desktop\IoTHomeApp_New - Copia"
git add README.md
git commit -m "Aggiorna README con istruzioni dettagliate per Swagger e MQTT"
git push
vai in github:
Certo! Ecco i passaggi per **aggiornare il README su GitHub** e vedere subito le modifiche online:

---

### 1. **Salva il file README.md**  
Assicurati che tutte le modifiche siano salvate in  
`C:\Users\paolo\OneDrive\Desktop\IoTHomeApp_New - Copia\README.md`

---

### 2. **Apri il terminale nella cartella del progetto**  
Se non sei già lì, spostati nella cartella:
```sh
cd "C:\Users\paolo\OneDrive\Desktop\IoTHomeApp_New - Copia"
```

---

### 3. **Aggiungi, fai commit e push del README aggiornato**
```sh
git add README.md
git commit -m "Aggiorna README con istruzioni dettagliate per Swagger e MQTT"
git push
```

---

### 4. **Vai su GitHub**
Apri il tuo repository su [https://github.com/Amilcare60/IoTHomeApp_New](https://github.com/Amilcare60/IoTHomeApp_New)

---

### 5. **Aggiorna la pagina**
Premi F5 o aggiorna la pagina:  
**Vedrai il README aggiornato** nella home del repository, formattato in Markdown.

---

**Ora il tuo README sarà visibile e aggiornato anche su GitHub!**  
Se vuoi vedere l’anteprima prima del push, puoi usare `Ctrl+Shift+V` su VS Code.

---

**Autore:** Amilcare60
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