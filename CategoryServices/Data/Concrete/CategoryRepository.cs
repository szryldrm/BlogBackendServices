using CategoryServices.Data.Abstract;
using CategoryServices.Model.Concrete;
using SYCore.DataAccess.MongoRepository;
using SYCore.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Data.Concrete
{
    public class CategoryRepository : MongoRepository<Post>, ICategoryRepository
    {
        public CategoryRepository(IMongoSettings settings) : base(settings)
        {
        }
    }
}
