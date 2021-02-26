using PostServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Dtos.Methods.GET
{
    public class GET_PostDTO
    {
        public string Id { get; set; }
        public List<GET_ArticleDTO> Articles { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public GET_AuthorDTO Author { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
