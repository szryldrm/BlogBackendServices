using PostServices.Model.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Dtos
{
    public class AddPostDTO : AuditableDocument
    {
        public List<Article> Articles { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public Author Author { get; set; }
    }
}
