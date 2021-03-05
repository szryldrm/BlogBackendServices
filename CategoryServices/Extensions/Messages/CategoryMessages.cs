using SYCore.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices.Extensions.Messages
{
    public class CategoryMessages : ICategoryMessages
    {
        private LangCode _langCode;
        private string _name;

        public CategoryMessages(LangCode langCode)
        {
            if (langCode.Equals(LangCode.EN))
            {
                _name = "CATEGORY";
            }
            else if (langCode.Equals(LangCode.TR))
            {
                _name = "KATEGORI";
            }
            else if (langCode.Equals(LangCode.DE))
            {
                _name = "KATEGORIE";
            }
            else if (langCode.Equals(LangCode.ES))
            {
                _name = "CATEGORÍA";
            }
            else if (langCode.Equals(LangCode.RU))
            {
                _name = "КАТЕГОРИЯ";
            }

            _langCode = langCode;
        }

        public CategoryMessages()
        {
            _name = "CATEGORY";
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

        public string DELETED()
        {
            return GeneralMessages.DELETED(_name, _langCode);
        }

        public string NOT_DELETED()
        {
            return GeneralMessages.NOT_DELETED(_name, _langCode);
        }

        public string POST_NOT_FOUND()
        {
            return GeneralMessages.NOT_FOUND("POST", _langCode);
        }

    }
}
