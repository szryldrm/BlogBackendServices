using LogServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Data.Abstract
{
    public interface ILogRepository : IMongoRepository<Log>
    {
    }
}
