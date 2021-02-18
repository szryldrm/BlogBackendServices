using ArticleServices.Data.Abstract;
using ArticleServices.Model.Concrete;
using Core.DataAccess.MongoRepository;
using Core.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Data.Concrete
{
    public class ArticleRepository : MongoRepository<Post>, IArticleRepository
    {
        public ArticleRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
