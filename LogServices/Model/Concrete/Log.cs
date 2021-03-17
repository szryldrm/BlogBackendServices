using SYCore.Entities;
using SYCore.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Model.Concrete
{
    [BsonCollection("Logs")]
    public class Log : BaseDocument
    {
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public string Audit { get; set; }
    }
}
