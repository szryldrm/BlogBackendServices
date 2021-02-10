using PostServices.Model.Concrete;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Dtos.Methods.POST
{
    public class POSTPostDTO
    {
        public List<POSTArticleDTO> Articles { get; set; }
        public int Status { get; set; }
        public string ImageURL { get; set; }
        public POSTAuthorDTO Author { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
