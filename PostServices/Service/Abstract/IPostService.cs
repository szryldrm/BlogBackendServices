using PostServices.Model.Concrete;
using SYCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Service.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<List<Post>>> GetAll();
        Task<IDataResult<Post>> FindOneAsnyc(Post post);
        Task<IDataResult<Post>> FindByIdAsync(string id);
        Task<IDataResult<Post>> InsertOneAsync(Post post);
        Task<IResult> InsertManyAsync(ICollection<Post> post);
        Task<IDataResult<Post>> ReplaceOneAsync(Post post);
        Task<IResult> DeleteOneAsync(Post post);
        Task<IResult> DeleteByIdAsync(string id);
    }
}
