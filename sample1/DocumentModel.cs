using System.Collections.Generic;
using CouchDB.Driver.Types;
using Newtonsoft.Json;

namespace sample1
{
    [JsonObject("document")] //changes database name
    public class DocumentModel : CouchDocument
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
}
