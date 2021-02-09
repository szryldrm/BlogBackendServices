using Core.Entities;
using Core.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Concrete
{
    [BsonCollection("Articles")]
    public class Article : AuditableDocument
    {
        public string TitleTR { get; set; }
        public string TitleEN { get; set; }
        public string ContentTR { get; set; }
        public string ContentEN { get; set; }
        public string SlugTR { get; set; }
        public string SlugEN { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public Author Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }

    }
}
