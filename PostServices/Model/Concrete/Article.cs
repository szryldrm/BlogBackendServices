using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Concrete
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public Language Language { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
