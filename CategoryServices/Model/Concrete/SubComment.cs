using SYCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Model.Concrete
{
    public class SubComment : AuditableDocument
    {
        public string CommentAuthor { get; set; }
        public string CommentContent { get; set; }
        public string CommentAuthorEmail { get; set; }
        public int Status { get; set; }
        public List<Like> Likes { get; set; }
    }
}
