# Final_Working_SensorSimulation
**A .NET Console Application for Simulating, Validating, Logging, and Analysing Sensor Data**

---

## 📌 Project Overview 
This project simulates a virtual temperature sensor used in a data centre environment.  
The system generates temperature readings, validates them, detects anomalies, logs the data, and stores historical readings for smoothing and analysis.

The application is structured to support **multiple sensors**, with configuration loaded securely from an external JSON file.

---

##  Features Implemented 

### ✔ 1. Sensor Initialization  
- Sensor configuration is loaded from `sensorConfig.json`.  
- JSON is sanitised to prevent unsafe content.  
- Validation ensures:
  - Name is present  
  - MinValue < MaxValue  
  - All required fields exist  

### ✔ 2. Temperature Simulation  
Each sensor generates new temperature readings every second using:  
- Random number generation  
- Small noise factor  
- Automatic range constraints  

### ✔ 3. Data Validation  
Method: `ValidateData()`  
- Checks if a reading is within the sensor’s configured range  
- Returns **true** (valid) or **false** (invalid)

### ✔ 4. Data Logging  
Method: `Logger.LogData()`  
Logs each reading to:


Includes:  
- Timestamp  
- Sensor Name  
- Temperature  
- Status (VALID / INVALID)

### ✔ 5. Data History Storage  
Method: `StoreData()`  
- Saves recent readings into an in-memory list  
- Maintains history for smoothing + anomaly detection  
- Automatically trims history if needed

### ✔ 6. Smoothing (Moving Average)  
Method: `SmoothData()`  
- Computes average of the most recent N readings (default 5)  
- Helps reduce noise and create stable trends  

### ✔ 7. Anomaly Detection  
Method: `DetectAnomaly()`  
Flags unusual readings:
- Value significantly outside range  
- Helps identify faults or sudden spikes  

### ✔ 8. Multi-Sensor Support  
- JSON file can contain multiple sensor configurations  
- Each sensor generates independent readings  
- Program loops through all sensors each second

---

## 📁 File Structure


---

## ⚙ How to Run the Program

### **Using Visual Studio**
1. Open solution in Visual Studio  
2. Ensure `sensorConfig.json` has:
   - **Build Action = Content**  
   - **Copy to Output Directory = Copy always**
3. Click **Start (▶)** or press **F5**

### **Using Terminal**

1. cd ".../"
2. dotnet run 

---

## 📝 sensorConfig.json Example  
Supports multiple sensors:

```json
[
  {
    "Name": "ServerRoomSensor01",
    "Location": "Data Centre Room A",
    "MinValue": 22,
    "MaxValue": 24
  },
  {
    "Name": "ServerRoomSensor02",
    "Location": "Data Centre Room B",
    "MinValue": 18,
    "MaxValue": 26
  }
]

12:00:01 | ServerRoomSensor01 | 22.5°C | Valid: True | Smooth: 22.4 | Anomaly: False
12:00:01 | ServerRoomSensor02 | 25.8°C | Valid: True | Smooth: 25.6 | Anomaly: False





