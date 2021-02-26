using CategoryServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Data.Abstract
{
    public interface ICategoryRepository : IMongoRepository<Post>
    {
    }
}
