using CategoryServices.Model.Concrete;
using SYCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Service.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Post>> InsertAsync(string id, List<Category> categories);
        Task<IDataResult<Post>> InsertOneAsync(string id, Category category);
        Task<IDataResult<Post>> DeleteOneAsync(string id, Category category);
    }
}
