# C# Data Foundations

C# language practice extended into a small streaming-metrics example for modern data and AI services.

## Current project

`src/DataStreamDemo` processes a sequence of sensor readings, maintains a rolling window, calculates mean and standard deviation, and flags unusually large deviations. It demonstrates typed records, collections, LINQ, and a transparent statistical baseline.

```bash
dotnet run --project src/DataStreamDemo
```

## Why C# belongs in a data/AI portfolio

.NET is widely used for enterprise APIs, event-driven services, Azure data platforms, and model-serving applications. This repository shows the software foundation for building typed ingestion or inference services around analytics and ML systems.

## Original practice files

`Program1`, `Comments`, `Variable`, and `WriteMethod` are preserved as the original language-learning exercises. The runnable project is the completed, modernized continuation.

## Future direction

- Consume events from Kafka or Azure Event Hubs
- Persist metrics to a time-series database
- Replace the statistical rule with an ML.NET anomaly detector
- Expose predictions through an ASP.NET API
