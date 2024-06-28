using CouchDB.Driver.Options;
using CouchDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample1
{
    public class SampleContext : CouchContext
    {
        public CouchDatabase<DocumentModel> Documents { get; set; }

        protected override void OnConfiguring(CouchOptionsBuilder optionsBuilder)
        {
            optionsBuilder
              .UseEndpoint("http://localhost:5984/")
              .EnsureDatabaseExists()
              .UseBasicAuthentication(username: "admin", password: "password");
        }

        protected override void OnDatabaseCreating(CouchDatabaseBuilder databaseBuilder)
        {
            databaseBuilder.Document<DocumentModel>()
                .HasIndex("documets_index", builder => builder
                    .IndexBy(r => r.Title)
                    .ThenBy(r => r.Note));
        }
    }
}
