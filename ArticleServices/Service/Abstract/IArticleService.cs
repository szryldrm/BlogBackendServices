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
        Task<IDataResult<Article>> GetOneAsync(string id);
        Task<IDataResult<Post>> InsertOneAsync(string id, Article article);
        Task<IDataResult<Post>> UpdateOneAsync(string id, Article article);
        Task<IDataResult<Post>> DeleteOneAsync(string id, Article article);
    }
}
