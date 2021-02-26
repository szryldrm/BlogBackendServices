using CategoryServices.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Model.Dto.Methods.POST
{
    public class DELETE_PostAndCategoryDTO
    {
        public string Id { get; set; }
        public Category Category { get; set; }
    }
}
