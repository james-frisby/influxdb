using InfluxDB.Client;
using InfluxDB.Client.Core;
using InfluxDB.Client.Writes;

namespace RandomWalk;

class Program
{
    private static readonly string TokenFilePath = ".influx-token";
    private static readonly string JamesBucket = "james-bucket";
    private static readonly string HelloRecordBucket = "helloRecord";
    private static readonly string Organization = "james-org";
    private static readonly string HelloMeasurement = "helloMeasurement";
    private static readonly string RandomWalkMeasurement = "RandomWalkMeasurement";
    private static WriteApi WriteApi = null;

    static async Task Main(string[] args)
    {

        var token = GetInfluxDBToken();
        using var client = new InfluxDBClient("http://localhost:8086", token);
        using var writeApi = client.GetWriteApi();
        WriteApi = writeApi;

        double val = 1000;
        while (true)
        {
            Measure(val);
            await Task.Delay(5);
            var delta = Random.Shared.NextDouble() - Random.Shared.NextDouble();
            val -= delta;
        }
    }

    static void Measure(double val)
    {
        WriteApi.WritePoint(
            PointData.Measurement(RandomWalkMeasurement)
                .Field("value", val)
                .Tag("user", "james")
                .Timestamp(DateTime.Now, InfluxDB.Client.Api.Domain.WritePrecision.Ms),
            JamesBucket,
            Organization
        );
    }

    static string GetInfluxDBToken()
    {
        return File.ReadAllText(TokenFilePath);
    }

    [Measurement("hellopoco")]
    private class HelloPoco
    {

    }
}
