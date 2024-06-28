// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using CouchDB.Driver;
using CouchDB.Driver.Types;
using Microsoft.Extensions.Configuration;
using System;
using System;

namespace sample1
{
    class Program
    {
        private static ICouchClient _client;
        private static ICouchDatabase<DocumentModel> _notes;

        static async Task Main(string[] args)
        {
            Console.WriteLine("CouchDB Begin:");

            // Build configuration
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var user = config["CouchDbSettings:Username"];
            var pass = config["CouchDbSettings:Password"];

            _client = new CouchClient("http://localhost:5984", c => c.UseBasicAuthentication(user, pass));
            _notes = await _client.GetOrCreateDatabaseAsync<DocumentModel>();

            var document = new DocumentModel
            {
                Title = "Title",
                Note = "test"
            };

            await _notes.AddAsync(document);

            Console.WriteLine("CouchDB End:");
        }
    }
}
