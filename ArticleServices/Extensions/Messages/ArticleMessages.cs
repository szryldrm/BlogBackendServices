using SYCore.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Extensions.Messages
{
    public class ArticleMessages
    {
        private LangCode _langCode;
        private string _name;

        public ArticleMessages(LangCode langCode)
        {
            if (langCode.Equals(LangCode.EN))
            {
                _name = "ARTICLE";
            }
            else if (langCode.Equals(LangCode.TR))
            {
                _name = "ILETI";
            }
            else if (langCode.Equals(LangCode.DE))
            {
                _name = "ARTIKEL";
            }
            else if (langCode.Equals(LangCode.ES))
            {
                _name = "ARTÍCULO";
            }
            else if (langCode.Equals(LangCode.RU))
            {
                _name = "СТАТЬЯ";
            }

            _langCode = langCode;
        }

        public ArticleMessages()
        {
            _name = "ARTICLE";
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
