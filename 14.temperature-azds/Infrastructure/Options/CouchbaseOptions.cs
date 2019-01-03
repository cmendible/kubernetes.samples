using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Temperature.Infrastructure
{
    public class CouchbaseOptions
    {
        public string CouchbaseBucket { get; set; } = "default";
        public string CouchbaseServer { get; set; } = "http://localhost:8091";
        public string CouchbasePassword { get; set; } = "password";
        public string CouchbaseUser { get; set; } = "Administrator";
    }
}