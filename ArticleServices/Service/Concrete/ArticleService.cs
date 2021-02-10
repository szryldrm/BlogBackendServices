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

        public async Task<IDataResult<Post>> FindByIdAsync(string id)
        {
            var value = await _articleRepository.FindByIdAsync(id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_FOUND);
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertOneAsync(Post post)
        {
            try
            {
                await _articleRepository.InsertOneAsync(post);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public async Task<IDataResult<Post>> UpdateOneAsync(string id, Article article)
        {
            try
            {
                await _articleRepository.UpdateSubOneAsync(id, article);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_UPDATED + " Ex: " + ex.Message);
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
