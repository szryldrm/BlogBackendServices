using ArticleServices.Data.Abstract;
using ArticleServices.Extensions.Messages;
using ArticleServices.Model.Concrete;
using ArticleServices.Service.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Service.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<IQueryable<Article>> GetAll()
        {
            var list = _articleRepository.AsQueryable();

            return list != null
                ? (IDataResult<IQueryable<Article>>)new SuccessDataResult<IQueryable<Article>>(list)
                : new ErrorDataResult<IQueryable<Article>>(GeneralMessages.RECORDS_NOT_FOUND);
        }

        public IDataResult<Article> FindById(string id)
        {
            var value = _articleRepository.FindById(id);

            return value != null
                ? (IDataResult<Article>)new SuccessDataResult<Article>(value)
                : new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public async Task<IDataResult<Article>> FindByIdAsync(string id)
        {
            var value = await _articleRepository.FindByIdAsync(id);

            return value != null
                ? (IDataResult<Article>)new SuccessDataResult<Article>(value)
                : new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public IDataResult<Article> FindOne(Article article)
        {
            var value = _articleRepository.FindOne(a => a.Id == article.Id);

            return value != null
                ? (IDataResult<Article>)new SuccessDataResult<Article>(value)
                : new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public async Task<IDataResult<Article>> FindOneAsnyc(Article article)
        {
            var value = await _articleRepository.FindOneAsync(a => a.Id == article.Id);

            return value != null
                ? (IDataResult<Article>)new SuccessDataResult<Article>(value)
                : new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_FOUND);
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<Article> InsertOne(Article article)
        {
            try
            {
                _articleRepository.InsertOne(article);
                return new SuccessDataResult<Article>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Article>> InsertOneAsync(Article article)
        {
            try
            {
                await _articleRepository.InsertOneAsync(article);
                return new SuccessDataResult<Article>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public IResult InsertMany(ICollection<Article> articles)
        {
            try
            {
                _articleRepository.InsertMany(articles);
                return new SuccessDataResult<Article>(GeneralMessages.RECORDS_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORDS_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public async Task<IResult> InsertManyAsync(ICollection<Article> articles)
        {
            try
            {
                await _articleRepository.InsertManyAsync(articles);
                return new SuccessDataResult<Article>(GeneralMessages.RECORDS_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORDS_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public IDataResult<Article> ReplaceOne(Article article)
        {
            try
            {
                _articleRepository.ReplaceOne(article);
                return new SuccessDataResult<Article>(GeneralMessages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_UPDATED + " Ex: " + ex.Message);
            }
        }

        public async Task<IDataResult<Article>> ReplaceOneAsync(Article article)
        {
            try
            {
                await _articleRepository.ReplaceOneAsync(article);
                return new SuccessDataResult<Article>(GeneralMessages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Article>(GeneralMessages.RECORD_NOT_UPDATED + " Ex: " + ex.Message);
            }
        }

        public IResult DeleteOne(Article article)
        {
            try
            {
                _articleRepository.DeleteOne(a => a.Id == article.Id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }

        public async Task<IResult> DeleteOneAsync(Article article)
        {
            try
            {
                await _articleRepository.DeleteOneAsync(a => a.Id == article.Id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }
        public IResult DeleteById(string id)
        {
            try
            {
                _articleRepository.DeleteById(id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }

        public async Task<IResult> DeleteByIdAsync(string id)
        {
            try
            {
                await _articleRepository.DeleteByIdAsync(id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }
    }
}
