﻿using SYCore.Entities;
using SYCore.Settings.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Concrete
{
    [BsonCollection("Posts")]
    public class Post : AuditableDocument
    {
        public List<Article> Articles { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public Author Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }

    }
}
