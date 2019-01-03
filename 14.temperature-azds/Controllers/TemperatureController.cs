using System;
using System.Threading.Tasks;
using Temperature.Infrastructure;
using Couchbase;
using Couchbase.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Temperature.Controllers
{
    [Route("api/temperature")]
    public class TemperatureController : Controller
    {
        private readonly TemperatureHub _temperatureHub;
        private readonly IBucket _bucket;

        public TemperatureController(IOptions<CouchbaseOptions> couchbaseOptions, TemperatureHub temperatureHub)
        {
            _temperatureHub = temperatureHub;
            _bucket = ClusterHelper.GetBucket(couchbaseOptions.Value.CouchbaseBucket);
        }

        [HttpPost("report")]
        public async Task Report(double temperature)
        {
            var reading = new
            {
                Date = DateTime.Now,
                Temperature = temperature
            };

            var readingDoc = new Document<dynamic>
            {
                Id = Guid.NewGuid().ToString(),
                Content = reading
                // Expiry = DateTime.Now.AddMinutes(10)
            };

            var result = await _bucket.InsertAsync(readingDoc);

            await _temperatureHub.SendMessage(JsonConvert.SerializeObject(reading));
        }

        [HttpGet("generate")]
        public async Task Generate()
        {
            var rnd = new Random();

            for (var i = 0; i < 100; i++)
            {
                await Report(rnd.Next(18, 42));
                await Task.Delay(1000);
            }
        }
    }
}