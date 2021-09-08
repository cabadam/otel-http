using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using OpenTelemetry;
using OpenTelemetry.Trace;

namespace otel_http
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            ////await client.PostAsync($"http://localhost/", new StringContent("dummy data")).ConfigureAwait(false);

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(Assembly.GetExecutingAssembly().GetName().Name)
                .AddHttpClientInstrumentation()
                .AddConsoleExporter()
                .Build();

            await client.PostAsync($"http://localhost/", new StringContent("dummy data")).ConfigureAwait(false);
        }
    }
}