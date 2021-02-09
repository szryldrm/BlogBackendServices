using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Settings.MongoSettings
{
    public interface IMongoSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
