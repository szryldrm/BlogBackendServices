using ArticleServices.Model.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dtos
{
    public class ArticleDTO
    {
        public string Id { get; set; }
        public string TitleTR { get; set; }
        public string TitleEN { get; set; }
        public string ContentTR { get; set; }
        public string ContentEN { get; set; }
        public string SlugTR { get; set; }
        public string SlugEN { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public AuthorDTO Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
