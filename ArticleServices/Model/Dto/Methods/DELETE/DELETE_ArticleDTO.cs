using ArticleServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.DELETE
{
    public class DELETE_ArticleDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public Language Language { get; set; }
    }
}
