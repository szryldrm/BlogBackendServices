using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Extensions.Messages
{
    public interface IPostMessages
    {
        public string ERROR_MESSAGE();

        public string ADDED();

        public string NOT_ADDED();

        public string UPDATED();

        public string NOT_UPDATED();

        public string DELETED();

        public string NOT_DELETED();

        public string NOT_FOUND();

        public string POST_NOT_FOUND();
    }
}
