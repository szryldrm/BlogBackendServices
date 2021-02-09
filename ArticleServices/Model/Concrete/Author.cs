using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Model.Concrete
{
    public class Author : BaseDocument
    {
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorEmail { get; set; }
    }
}
