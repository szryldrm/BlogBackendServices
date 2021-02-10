using PostServices.Model.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Service.Abstract
{
    public interface IPostService
    {
        IDataResult<Post> FindOne(Post post);
        Task<IDataResult<Post>> FindOneAsnyc(Post post);
        IDataResult<Post> FindById(string id);
        Task<IDataResult<Post>> FindByIdAsync(string id);
        IDataResult<IQueryable<Post>> GetAll();
        IDataResult<Post> InsertOne(Post post);
        Task<IDataResult<Post>> InsertOneAsync(Post post);
        IResult InsertMany(ICollection<Post> post);
        Task<IResult> InsertManyAsync(ICollection<Post> post);
        IDataResult<Post> ReplaceOne(Post post);
        Task<IDataResult<Post>> ReplaceOneAsync(Post post);
        IResult DeleteOne(Post post);
        Task<IResult> DeleteOneAsync(Post post);
        IResult DeleteById(string id);
        Task<IResult> DeleteByIdAsync(string id);
    }
}
