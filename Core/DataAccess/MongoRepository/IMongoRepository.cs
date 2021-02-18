using Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.MongoRepository
{
    public interface IMongoRepository<TDocument> where TDocument : class, IDocument, new()
    {
        IQueryable<TDocument> AsQueryable();
        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);
        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);
        TDocument FindOne(FilterDefinition<TDocument> filterDefinition);
        Task<TDocument> FindOneAsync(FilterDefinition<TDocument> filterDefinition);
        TDocument FindById(string id);
        Task<TDocument> FindByIdAsync(string id);
        void InsertOne(TDocument document);
        Task InsertOneAsync(TDocument document);
        void InsertMany(ICollection<TDocument> documents);
        Task InsertManyAsync(ICollection<TDocument> documents);
        void InsertSubOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        Task InsertSubOneAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        void ReplaceOne(TDocument document);
        Task ReplaceOneAsync(TDocument document);
        void UpdateSubOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        Task UpdateSubOneAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        void DeleteSubOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        Task DeleteSubOneAsync(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update);
        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        void DeleteById(string id);
        Task DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);

        //bool Add(TDocument entity);
        //bool Update(TDocument entity);
        //bool Delete(string id);
        //bool UpdateOne(FilterDefinition<TDocument> filter, UpdateDefinition<TDocument> update, UpdateOptions options = null);
        //TDocument Get(FilterDefinition<TDocument> filter);
        //List<TDocument> GetList(FilterDefinition<TDocument> filter = null);
        //List<TDocument> GetProjectionList(ProjectionDefinition<TDocument> project, FilterDefinition<T> filter = null);
    }
}
