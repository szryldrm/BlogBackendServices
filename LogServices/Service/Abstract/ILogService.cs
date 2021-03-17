using LogServices.Model.Concrete;
using SYCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Service.Abstract
{
    public interface ILogService
    {
        Task<IDataResult<List<Log>>> GetAll();
    }
}
