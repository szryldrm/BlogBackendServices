using PostServices.Data.Abstract;
using PostServices.Extensions.Messages;
using PostServices.Model.Concrete;
using PostServices.Service.Abstract;
using SYCore.Aspects.Autofac.Logging;
using SYCore.Aspects.Autofac.Transaction;
using SYCore.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SYCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using SYCore.Utilities.Messages;

namespace PostServices.Service.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly PostMessages _postMessages;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _postMessages = new PostMessages(LangCode.EN);
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<List<Post>>> GetAll()
        {
            var list = await _postRepository.GetAll();

            return list != null
                ? (IDataResult<List<Post>>)new SuccessDataResult<List<Post>>(list)
                : new ErrorDataResult<List<Post>>(_postMessages.POST_NOT_FOUND());
        }

        public async Task<IDataResult<Post>> FindByIdAsync(string id)
        {
            var value = await _postRepository.FindByIdAsync(id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(_postMessages.POST_NOT_FOUND());
        }

        public async Task<IDataResult<Post>> FindOneAsnyc(Post post)
        {
            var value = await _postRepository.FindOneAsync(Builders<Post>.Filter.Eq(x => x.Id, post.Id));

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(_postMessages.POST_NOT_FOUND());
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertOneAsync(Post post)
        {
            try
            {
                await _postRepository.InsertOneAsync(post);
                return new SuccessDataResult<Post>(_postMessages.ADDED());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_postMessages.NOT_ADDED() + " - Ex = " + ex.Message);
            }
        }

        public async Task<IResult> InsertManyAsync(ICollection<Post> posts)
        {
            try
            {
                await _postRepository.InsertManyAsync(posts);
                return new SuccessDataResult<Post>(_postMessages.ADDED());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_postMessages.NOT_ADDED() + " - Ex = " + ex.Message);
            }
        }

        public async Task<IDataResult<Post>> ReplaceOneAsync(Post post)
        {
            try
            {
                await _postRepository.ReplaceOneAsync(post);
                return new SuccessDataResult<Post>(_postMessages.UPDATED());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(_postMessages.NOT_UPDATED() + " - Ex = " + ex.Message);
            }
        }

        public async Task<IResult> DeleteOneAsync(Post post)
        {
            try
            {
                await _postRepository.DeleteOneAsync(a => a.Id == post.Id);
                return new SuccessResult(_postMessages.DELETED());
            }
            catch (Exception ex)
            {
                return new ErrorResult(_postMessages.NOT_DELETED() + " - Ex = " + ex.Message);
            }
        }

        public async Task<IResult> DeleteByIdAsync(string id)
        {
            try
            {
                await _postRepository.DeleteByIdAsync(id);
                return new SuccessResult(_postMessages.DELETED());
            }
            catch (Exception ex)
            {
                return new ErrorResult(_postMessages.NOT_DELETED() + " - Ex = " + ex.Message);
            }
        }
    }
}
