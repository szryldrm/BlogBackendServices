using SYCore.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServices.Extensions.Messages
{
    public class PostMessages : IPostMessages
    {
        private LangCode _langCode;
        private string _name;

        public PostMessages(LangCode langCode)
        {
            if (langCode.Equals(LangCode.EN))
            {
                _name = "POST";
            }
            else if (langCode.Equals(LangCode.TR))
            {
                _name = "POST";
            }
            else if (langCode.Equals(LangCode.DE))
            {
                _name = "POST";
            }
            else if (langCode.Equals(LangCode.ES))
            {
                _name = "POST";
            }
            else if (langCode.Equals(LangCode.RU))
            {
                _name = "ЗАПИСЬ";
            }

            _langCode = langCode;
        }

        public PostMessages()
        {
            _name = "POST";
            _langCode = LangCode.EN;
        }

        public string ERROR_MESSAGE()
        {
            return GeneralMessages.ERROR_MESSAGE(_langCode);
        }

        public string ADDED()
        {
            return GeneralMessages.ADDED(_name, _langCode);
        }

        public string NOT_ADDED()
        {
            return GeneralMessages.NOT_ADDED(_name, _langCode);
        }

        public string UPDATED()
        {
            return GeneralMessages.UPDATED(_name, _langCode);
        }

        public string NOT_UPDATED()
        {
            return GeneralMessages.NOT_UPDATED(_name, _langCode);
        }

        public string DELETED()
        {
            return GeneralMessages.DELETED(_name, _langCode);
        }

        public string NOT_DELETED()
        {
            return GeneralMessages.NOT_DELETED(_name, _langCode);
        }

        public string NOT_FOUND()
        {
            return GeneralMessages.NOT_FOUND(_name, _langCode);
        }

        public string POST_NOT_FOUND()
        {
            return GeneralMessages.NOT_FOUND("POST", _langCode);
        }
    }
}
