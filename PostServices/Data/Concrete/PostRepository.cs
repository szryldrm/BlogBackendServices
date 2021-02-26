using PostServices.Data.Abstract;
using PostServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using SYCore.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Data.Concrete
{
    public class PostRepository : MongoRepository<Post>, IPostRepository
    {
        public PostRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
