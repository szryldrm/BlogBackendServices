using ArticleServices.Model.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dtos
{
    public class AddArticleDTO : AuditableDocument
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
    }
}
