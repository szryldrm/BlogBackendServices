using ArticleServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.DELETE
{
    public class DELETE_PostAndArticleDTO
    {
        public string Id { get; set; }
        public DELETE_ArticleDTO Article { get; set; }
    }
}
