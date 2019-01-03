using System;
using System.Collections.Generic;
using System.Linq;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Temperature.Infrastructure;

namespace Temperature
{
    public static class CouchbaseStartupExtensions
    {
        private static readonly List<string> TemperatureIndexNames = new List<string>
        {
            "def_temperature"
        };

        public static void AddCouchbase(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.Get<CouchbaseOptions>();

            var couchbaseServer = options.CouchbaseServer;

            ClusterHelper.Initialize(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri(couchbaseServer) }
            });

            var bucketName = options.CouchbaseBucket;
            var username = options.CouchbaseUser;
            var password = options.CouchbasePassword;

            // provide authentication to cluster
            ClusterHelper.Get().Authenticate(new PasswordAuthenticator(username, password));

            EnsureIndexes(bucketName);
        }

        private static void EnsureIndexes(string bucketName)
        {
            var bucket = ClusterHelper.GetBucket(bucketName);
            var bucketManager = bucket.CreateManager();

            var indexes = bucketManager.ListN1qlIndexes();
            if (!indexes.Any(index => index.IsPrimary))
            {
                bucketManager.CreateN1qlPrimaryIndex(true);
            }

            var missingIndexes = TemperatureIndexNames.Except(indexes.Where(x => !x.IsPrimary).Select(x => x.Name)).ToList();
            if (!missingIndexes.Any())
            {
                return;
            }

            foreach (var missingIndex in missingIndexes)
            {
                var propertyName = missingIndex.Replace("def_", string.Empty);
                bucketManager.CreateN1qlIndex(missingIndex, true, propertyName);
            }

            bucketManager.BuildN1qlDeferredIndexes();
            bucketManager.WatchN1qlIndexes(missingIndexes, TimeSpan.FromSeconds(30));
        }

        public static void CleanUp()
        {
            ClusterHelper.Close();
        }
    }
}