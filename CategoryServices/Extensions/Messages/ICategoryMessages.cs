using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Extensions.Messages
{
    public interface ICategoryMessages
    {
        public string ERROR_MESSAGE();

        public string ADDED();

        public string NOT_ADDED();

        public string DELETED();

        public string NOT_DELETED();

        public string POST_NOT_FOUND();
    }
}
