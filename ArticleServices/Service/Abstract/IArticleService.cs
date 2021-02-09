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
        IDataResult<Article> FindOne(Article article);
        Task<IDataResult<Article>> FindOneAsnyc(Article article);
        IDataResult<Article> FindById(string id);
        Task<IDataResult<Article>> FindByIdAsync(string id);
        IDataResult<IQueryable<Article>> GetAll();
        IDataResult<Article> InsertOne(Article article);
        Task<IDataResult<Article>> InsertOneAsync(Article article);
        IResult InsertMany(ICollection<Article> articles);
        Task<IResult> InsertManyAsync(ICollection<Article> articles);
        IDataResult<Article> ReplaceOne(Article article);
        Task<IDataResult<Article>> ReplaceOneAsync(Article article);
        IResult DeleteOne(Article article);
        Task<IResult> DeleteOneAsync(Article article);
        IResult DeleteById(string id);
        Task<IResult> DeleteByIdAsync(string id);
    }
}
