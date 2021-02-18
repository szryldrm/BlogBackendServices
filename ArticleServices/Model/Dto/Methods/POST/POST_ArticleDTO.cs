using ArticleServices.Model.Concrete;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.POST
{
    public class POST_ArticleDTO
    {
        public POST_ArticleDTO()
        {
            this.Id = ObjectId.GenerateNewId();
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public Language Language { get; set; }
    }
}
