using ArticleServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Dto.Methods.POST
{
    public class POSTPostAndArticleDTO
    {
        public string Id { get; set; }
        public POSTArticleDTO Article { get; set; }
    }
}
