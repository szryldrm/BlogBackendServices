using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Model.Dtos.Methods.GET
{
    public class GET_LogDTO
    {
        public string Id { get; set; }
        public dynamic Detail { get; set; }
        public string Date { get; set; }
        public string Audit { get; set; }
    }
}
