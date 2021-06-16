using BettingApp.Data;
using Cronos;
using EasyCronJob.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BettingApp.Scheduler
{
    public class CronJobService: EasyCronJob.Abstractions.CronJobService
    {
        private const string URL = "https://sports.ultraplay.net/sportsxml";
        private string urlParameters = "?clientKey=b4dde172-4e11-43e4-b290-abdeb0ffd711&sportId=2357&days=7";

        public UltraPlayDbContext DbContext { get; }

        public CronJobService(ICronConfiguration<CronJobService> config, DbContextOptions<UltraPlayDbContext> dbOptions) : base(config.CronExpression, config.TimeZoneInfo)
        {
            DbContext = new UltraPlayDbContext(dbOptions);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage response = await client.GetAsync(urlParameters);  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = await response.Content.ReadAsStringAsync();

                XmlSerializer ser = new XmlSerializer(typeof(Models.XmlSports));
                using (StringReader sr = new StringReader(dataObjects))
                {
                    var test = (Models.XmlSports)ser.Deserialize(sr);

                    await DbContext.AddRangeAsync(test.Sports);
                    await DbContext.SaveChangesAsync();
                }
            }

            client.Dispose();
        }
    }
}
