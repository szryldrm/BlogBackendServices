using ArticleServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.POST
{
    public class POST_PostAndArticleDTO
    {
        public string Id { get; set; }
        public POST_ArticleDTO Article { get; set; }
    }
}
