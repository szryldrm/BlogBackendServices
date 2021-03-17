
using AutoMapper;
using LogServices.Model.Concrete;
using LogServices.Model.Dtos.Methods.GET;
using LogServices.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public LogController(ILogService logService, IMapper mapper)
        {
            _logService = logService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _logService.GetAll();
            if (result.Result.Success)
            {
                var mappingData = _mapper.Map<IEnumerable<GET_LogDTO>>(result.Result.Data);

                return Ok(mappingData);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
