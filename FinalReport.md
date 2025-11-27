# Final Report — Final_Working_SensorSimulation

## Introduction
This project involved designing and implementing a virtual temperature sensor system capable of simulating readings, validating data, logging information, detecting anomalies, and maintaining historical trends for analysis. The system was built as a .NET console application in C#, with Part 2 focusing on expanding functionality, improving structure, and supporting multiple sensors. This report reflects on the development approach, use of Git for version control, testing practices, and challenges faced during the implementation.

---

## Development Process
The project was implemented incrementally, beginning with a basic sensor model and progressing toward a complete simulation system. Part 1 established the core functionality: sensor classes, reading generation, and a simple loop for simulation. Part 2 expanded on this foundation by introducing structured components such as `SensorService`, `ConfigLoader`, and `Logger`, which greatly improved maintainability and modularity.

A key early decision was to externalize sensor settings into a JSON configuration file (`sensorConfig.json`). This allowed parameters such as name, location, and temperature ranges to be modified without changing code. Error handling and sanitization were added to protect against malformed or unsafe JSON content. Later, support for multiple sensors was implemented by modifying both the JSON structure and the configuration loader to deserialize a list instead of a single object.

Functional features were developed one at a time:
- **Data Validation:** Ensured that generated readings fell within sensor-defined bounds.
- **Data Logging:** Implemented a logger that outputs entries to `/logs/sensor.log`, ensuring traceability of every reading.
- **Data History Storage:** Stored recent readings to allow further analysis.
- **Smoothing Algorithm:** Added a moving average over recent values to reduce noise.
- **Anomaly Detection:** Identified values significantly outside normal ranges.
- **Graceful Shutdown Structure:** Prepared a method to clear history or perform cleanup, though full shutdown logic remains for future expansion.

Each feature was developed with a focus on clarity and separation of concerns.

---

## Git Usage
Git was used throughout the project to track progress and maintain clean version control. After initialization, a new branch was created specifically for the virtual sensor implementation (e.g., `part2-virtual-sensor`). This prevented interference with earlier work and allowed independent development. Frequent commits documented each milestone: loading configurations, implementing validation, introducing logging, adding smoothing, and enabling multi-sensor functionality. Once the implementation was stable, the branch was pushed to GitHub for backup and assessment.

The branching model encouraged experimentation while keeping the main branch clean. GitHub also provided a safe place to revert changes if needed, and the visual history made it easy to trace issues.

---

## Testing Practices
Testing was performed iteratively throughout development. Initial tests verified that sensor configuration loaded correctly and improper JSON produced expected errors. Subsequent checks focused on validating boundaries for temperature readings. Console output served as immediate visual feedback, while log file inspection confirmed that the logger was functioning correctly.

As smoothing and anomaly detection were introduced, tests ensured correct moving average output and appropriate anomaly triggers. The history system was also checked to ensure that values were stored and truncated properly. Although formal automated unit tests will be expanded later, informal functional testing was essential in verifying correctness at each stage.

---

## Challenges Faced
Several challenges arose during development. One of the earliest was ensuring that Visual Studio properly included the JSON configuration file in the build output, requiring adjustments to “Build Action” and “Copy to Output Directory”. Implementing support for multiple sensors also required refactoring the configuration loader and simulation loop. Handling file paths, data sanitization, and log directory creation added complexity but improved robustness. Git errors occasionally occurred when attempting to create branches before repository initialization, but these were resolved with proper setup steps.

---

## Conclusion
Overall, the project successfully implemented a robust multi-sensor virtual temperature system with validation, logging, historical analysis, and anomaly detection. The development process was structured and iterative, supported by Git version control and continuous testing. This work establishes a strong foundation for future enhancements such as database integration, graphing, or remote monitoring APIs.
