using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Extensions.Messages
{
    public interface ILogMessages
    {
        public string ERROR_MESSAGE();
        public string NOT_FOUND();
    }
}
