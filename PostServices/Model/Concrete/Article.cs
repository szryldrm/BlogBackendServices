using SYCore.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Concrete
{
    public class Article : AuditableDocument
    {
        public Article()
        {
            Id = ObjectId.GenerateNewId();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public Language Language { get; set; }
    }
}
