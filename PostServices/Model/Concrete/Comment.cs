using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Concrete
{
    public class Comment : AuditableDocument
    {
        public string CommentAuthor { get; set; }
        public string CommentContent { get; set; }
        public string CommentAuthorEmail { get; set; }
        public int Status { get; set; }
        public List<SubComment> SubComments { get; set; }
        public List<Like> Likes { get; set; }

    }
}
