using ArticleServices.Model.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Service.Abstract
{
    public interface IArticleService
    {
        Task<IDataResult<Post>> FindByIdAsync(string id);
        Task<IDataResult<Post>> InsertOneAsync(Post post);
        Task<IDataResult<Post>> UpdateOneAsync(string id, Article article);
        Task<IResult> DeleteByIdAsync(string id);
    }
}
