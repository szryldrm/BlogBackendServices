using PostServices.Model.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Dtos.Methods.POST
{
    public class POST_PostDTO
    {
        public List<POST_ArticleDTO> Articles { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public POST_AuthorDTO Author { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
