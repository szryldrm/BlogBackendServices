using SYCore.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Extensions.Messages
{
    public class LogMessages : ILogMessages
    {
        private LangCode _langCode;
        private string _name;

        public LogMessages(LangCode langCode)
        {
            if (langCode.Equals(LangCode.EN))
            {
                _name = "LOG";
            }
            else if (langCode.Equals(LangCode.TR))
            {
                _name = "LOG";
            }
            else if (langCode.Equals(LangCode.DE))
            {
                _name = "LOG";
            }
            else if (langCode.Equals(LangCode.ES))
            {
                _name = "INICIAR SESIÓN";
            }
            else if (langCode.Equals(LangCode.RU))
            {
                _name = "БРЕВНО";
            }

            _langCode = langCode;
        }

        public LogMessages()
        {
            _name = "LOG";
            _langCode = LangCode.EN;
        }

        public string ERROR_MESSAGE()
        {
            return GeneralMessages.ERROR_MESSAGE(_langCode);
        }

        public string NOT_FOUND()
        {
            return GeneralMessages.NOT_FOUND(_name, _langCode);
        }
    }
}
