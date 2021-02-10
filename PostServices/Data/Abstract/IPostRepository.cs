using PostServices.Model.Concrete;
using Core.DataAccess.MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Data.Abstract
{
    public interface IPostRepository : IMongoRepository<Post>
    {
    }
}
