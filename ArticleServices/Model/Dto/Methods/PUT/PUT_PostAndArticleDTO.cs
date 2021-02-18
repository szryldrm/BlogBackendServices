using ArticleServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.PUT
{
    public class PUT_PostAndArticleDTO
    {
        public string Id { get; set; }
        public PUT_ArticleDTO Article { get; set; }
    }
}
