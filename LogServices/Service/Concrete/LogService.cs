using SYCore.Aspects.Autofac.Logging;
using SYCore.Aspects.Autofac.Transaction;
using SYCore.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using SYCore.Utilities.Results;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYCore.Utilities.Messages;
using LogServices.Service.Abstract;
using LogServices.Data.Abstract;
using LogServices.Model.Concrete;
using LogServices.Extensions.Messages;
using Newtonsoft.Json;

namespace LogServices.Service.Concrete
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly ILogMessages _logMessages;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
            _logMessages = new LogMessages(LangCode.EN);
        }

        [TransactionScopeAspect(Priority = 1)]
        public async Task<IDataResult<List<Log>>> GetAll()
        {
            var list = await _logRepository.GetAll();

            return list != null
                ? (IDataResult<List<Log>>)new SuccessDataResult<List<Log>>(list)
                : new ErrorDataResult<List<Log>>(_logMessages.NOT_FOUND());
        }
    }
}
