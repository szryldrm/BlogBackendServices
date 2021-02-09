using ArticleServices.Model.Concrete;
using ArticleServices.Model.Dtos;
using ArticleServices.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _articleService.GetAll();
            if (result.Success)
            {
                var mappingData = _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(result.Data);
                return Ok(mappingData);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _articleService.FindByIdAsync(id);
            if (result.Result.Success)
            {
                var mappingData = _mapper.Map<Article, ArticleDTO>(result.Result.Data);
                return Ok(mappingData);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddArticleDTO addArticleDTO)
        {
            var mappingData = _mapper.Map<AddArticleDTO, Article>(addArticleDTO);

            var result = _articleService.InsertOneAsync(mappingData);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
