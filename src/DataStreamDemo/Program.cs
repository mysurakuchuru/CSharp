record SensorReading(DateTime Timestamp, double Value);

static (double Mean, double StandardDeviation) Summarize(IEnumerable<double> values)
{
    var data = values.ToArray();
    var mean = data.Average();
    var variance = data.Select(value => Math.Pow(value - mean, 2)).Average();
    return (mean, Math.Sqrt(variance));
}

var readings = new[]
{
    21.2, 21.5, 21.1, 21.4, 21.6, 21.3, 21.5, 34.8, 21.4, 21.2
}.Select((value, index) => new SensorReading(DateTime.UtcNow.AddMinutes(index), value));

const int windowSize = 5;
var window = new Queue<double>();

Console.WriteLine("timestamp,value,rolling_mean,is_anomaly");
foreach (var reading in readings)
{
    var isAnomaly = false;
    var rollingMean = reading.Value;

    if (window.Count >= 3)
    {
        var summary = Summarize(window);
        rollingMean = summary.Mean;
        isAnomaly = summary.StandardDeviation > 0
            && Math.Abs(reading.Value - summary.Mean) > 3 * summary.StandardDeviation;
    }

    Console.WriteLine(
        $"{reading.Timestamp:O},{reading.Value:F2},{rollingMean:F2},{isAnomaly.ToString().ToLowerInvariant()}"
    );

    window.Enqueue(reading.Value);
    if (window.Count > windowSize)
    {
        window.Dequeue();
    }
}
