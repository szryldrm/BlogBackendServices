using ArticleServices.Data.Abstract;
using ArticleServices.Extensions.Messages;
using ArticleServices.Model.Concrete;
using ArticleServices.Service.Abstract;
using SYCore.Aspects.Autofac.Logging;
using SYCore.Aspects.Autofac.Transaction;
using SYCore.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SYCore.Utilities.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYCore.Utilities.Messages;

namespace ArticleServices.Service.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ArticleMessages _articleMessages;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
            _articleMessages = new ArticleMessages(LangCode.EN);
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Article>> GetOneAsync(string id)
        {
            var value = await _articleRepository.FindOneAsync(Builders<Post>.Filter.ElemMatch(x => x.Articles, x => x.Id == ObjectId.Parse(id)));

            if (value != null)
            {
                foreach (var item in from item in value.Articles
                                     where item.Id == ObjectId.Parse(id)
                                     select item)
                {
                    return new SuccessDataResult<Article>(item);
                }
            }

            return new ErrorDataResult<Article>(_articleMessages.NOT_FOUND());
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertOneAsync(string id, Article article)
        {
            try
            {
                var value = await _articleRepository.FindOneAsync(Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id)));

                if (value != null)
                {
                    article.AddedDate = DateTime.Now;
                    var filter = Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
                    var update = Builders<Post>.Update.Combine(
                            Builders<Post>.Update.Push(x => x.Articles, article),
                            Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                        );
                    await _articleRepository.InsertSubOneAsync(filter, update);
                    return new SuccessDataResult<Post>(_articleMessages.ADDED());
                }
                else
                {
                    return new ErrorDataResult<Post>(_articleMessages.POST_NOT_FOUND() + " - ID = " + id);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_articleMessages.NOT_ADDED() + " Ex = " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> UpdateOneAsync(string id, Article article)
        {
            try
            {
                var value = await _articleRepository.FindOneAsync(Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id)));

                if (value != null)
                {

                    var tempArticle = _articleRepository.FindOneAsync(Builders<Post>.Filter.ElemMatch(x => x.Articles, x => x.Id == ObjectId.Parse(id)));

                    if (tempArticle != null)
                    {
                        var filter = Builders<Post>.Filter.And(
                            Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id)),
                            Builders<Post>.Filter.ElemMatch(x => x.Articles, x => x.Id == article.Id));

                        var update = Builders<Post>.Update.Combine(
                                Builders<Post>.Update.Set(x => x.Articles[-1].Content, article.Content),
                                Builders<Post>.Update.Set(x => x.Articles[-1].Language, article.Language),
                                Builders<Post>.Update.Set(x => x.Articles[-1].Slug, article.Slug),
                                Builders<Post>.Update.Set(x => x.Articles[-1].Title, article.Title),
                                Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                            );
                        await _articleRepository.UpdateSubOneAsync(filter, update);
                        return new SuccessDataResult<Post>(_articleMessages.UPDATED());
                    }
                    else
                    {
                        return new ErrorDataResult<Post>(_articleMessages.NOT_FOUND() + " - ID = " + article.Id);
                    }
                }
                else
                {
                    return new ErrorDataResult<Post>(_articleMessages.POST_NOT_FOUND() + " - ID = " + id);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_articleMessages.NOT_UPDATED() + " Ex = " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> DeleteOneAsync(string id, Article article)
        {
            try
            {
                var value = await _articleRepository.FindOneAsync(Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id)));

                if (value != null)
                {
                    var tempArticle = _articleRepository.FindOneAsync(Builders<Post>.Filter.ElemMatch(x => x.Articles, x => x.Id == ObjectId.Parse(id)));

                    if (tempArticle != null)
                    {
                        var filter = Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
                        var update = Builders<Post>.Update.Combine(
                                        Builders<Post>.Update.PullFilter(x => x.Articles, Builders<Article>.Filter.Eq(x => x.Id, article.Id)),
                                        Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                                    );
                        await _articleRepository.DeleteSubOneAsync(filter, update);
                        return new SuccessDataResult<Post>(_articleMessages.DELETED());
                    }
                    else
                    {
                        return new ErrorDataResult<Post>(_articleMessages.NOT_FOUND() + " - ID = " + article.Id);
                    }
                }
                else
                {
                    return new ErrorDataResult<Post>(_articleMessages.POST_NOT_FOUND() + " - ID = " + id);
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_articleMessages.NOT_DELETED() + " - Ex = " + ex.Message);
            }
        }
    }
}
