using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Model.Dtos.Methods.GET
{
    public class GET_AuthorDTO
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorEmail { get; set; }
    }
}
