using CategoryServices.Data.Abstract;
using CategoryServices.Extensions.Messages;
using CategoryServices.Model.Concrete;
using CategoryServices.Service.Abstract;
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

namespace CategoryServices.Service.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertAsync(string id, List<Category> categories)
        {
            try
            {
                var filter = Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
                var update = Builders<Post>.Update.Combine(
                        Builders<Post>.Update.Set(x => x.Categories, categories),
                        Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                    );
                await _categoryRepository.InsertSubOneAsync(filter, update);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> InsertOneAsync(string id, Category category)
        {
            try
            {
                var filter = Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
                var update = Builders<Post>.Update.Combine(
                        Builders<Post>.Update.Push(x => x.Categories, category),
                        Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                    );
                await _categoryRepository.InsertSubOneAsync(filter, update);
                return new SuccessDataResult<Post>(GeneralMessages.RECORD_ADDED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORD_NOT_ADDED + " Ex: " + ex.Message);
            }
        }

        [LogAspect(typeof(DatabaseLogger), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public async Task<IDataResult<Post>> DeleteOneAsync(string id, Category category)
        {
            try
            {
                var filter = Builders<Post>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
                var update = Builders<Post>.Update.Combine(
                                Builders<Post>.Update.PullFilter(x => x.Categories, Builders<Category>.Filter.Eq(x => x.CategoryName, category.CategoryName)),
                                Builders<Post>.Update.Set(x => x.ModifiedDate, DateTime.Now)
                            );
                await _categoryRepository.DeleteSubOneAsync(filter, update);
                return new SuccessDataResult<Post>(GeneralMessages.RECORDS_DELETED);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Post>(GeneralMessages.RECORDS_NOT_DELETED + " Ex: " + ex.Message);
            }
        }        
    }
}
