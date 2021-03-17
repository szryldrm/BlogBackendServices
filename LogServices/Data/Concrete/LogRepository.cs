using LogServices.Data.Abstract;
using LogServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using SYCore.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Data.Concrete
{
    public class LogRepository : MongoRepository<Log>, ILogRepository
    {
        public LogRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
