using PostServices.Data.Abstract;
using PostServices.Extensions.Messages;
using PostServices.Model.Concrete;
using PostServices.Service.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Service.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<IQueryable<Post>> GetAll()
        {
            var list = _postRepository.AsQueryable();

            return list != null
                ? (IDataResult<IQueryable<Post>>)new SuccessDataResult<IQueryable<Post>>(list)
                : new ErrorDataResult<IQueryable<Post>>(GeneralMessages.RECORDS_NOT_FOUND);
        }

        public IDataResult<Post> FindById(string id)
        {
            var value = _postRepository.FindById(id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public async Task<IDataResult<Post>> FindByIdAsync(string id)
        {
            var value = await _postRepository.FindByIdAsync(id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public IDataResult<Post> FindOne(Post post)
        {
            var value = _postRepository.FindOne(a => a.Id == post.Id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_FOUND);
        }

        public async Task<IDataResult<Post>> FindOneAsnyc(Post post)
        {
            var value = await _postRepository.FindOneAsync(a => a.Id == post.Id);

            return value != null
                ? (IDataResult<Post>)new SuccessDataResult<Post>(value)
                : new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_FOUND);
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<Post> InsertOne(Post post)
        {
            try
            {
                _postRepository.InsertOne(post);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertOneAsync(Post post)
        {
            try
            {
                await _postRepository.InsertOneAsync(post);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public IResult InsertMany(ICollection<Post> posts)
        {
            try
            {
                _postRepository.InsertMany(posts);
                return new SuccessDataResult<Post>(GeneralMessages.RECORDS_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORDS_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public async Task<IResult> InsertManyAsync(ICollection<Post> posts)
        {
            try
            {
                await _postRepository.InsertManyAsync(posts);
                return new SuccessDataResult<Post>(GeneralMessages.RECORDS_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORDS_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        public IDataResult<Post> ReplaceOne(Post post)
        {
            try
            {
                _postRepository.ReplaceOne(post);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_UPDATED + " Ex: " + ex.Message);
            }
        }

        public async Task<IDataResult<Post>> ReplaceOneAsync(Post post)
        {
            try
            {
                await _postRepository.ReplaceOneAsync(post);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_UPDATED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_UPDATED + " Ex: " + ex.Message);
            }
        }

        public IResult DeleteOne(Post post)
        {
            try
            {
                _postRepository.DeleteOne(a => a.Id == post.Id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }

        public async Task<IResult> DeleteOneAsync(Post post)
        {
            try
            {
                await _postRepository.DeleteOneAsync(a => a.Id == post.Id);
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
                _postRepository.DeleteById(id);
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
                await _postRepository.DeleteByIdAsync(id);
                return new SuccessResult(GeneralMessages.RECORD_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorResult(GeneralMessages.RECORD_NOT_DELETED + " Ex: " + ex.Message);
            }
        }
    }
}
