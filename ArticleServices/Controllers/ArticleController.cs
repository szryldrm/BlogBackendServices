using ArticleServices.Model.Concrete;
using ArticleServices.Model.Dto.Methods.DELETE;
using ArticleServices.Model.Dto.Methods.GET;
using ArticleServices.Model.Dto.Methods.POST;
using ArticleServices.Model.Dto.Methods.PUT;
using ArticleServices.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public IActionResult GetArticle(string id)
        {
            var result = _articleService.GetOneAsync(id);
            if (result.Result.Success)
            {
                var mappingData = _mapper.Map<GET_ArticleDTO>(result.Result.Data);
                return Ok(mappingData);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpPost]
        public IActionResult InsertArticle([FromBody] POST_PostAndArticleDTO POST_PostAndArticleDTO)
        {
            var article = _mapper.Map<Article>(POST_PostAndArticleDTO.Article);
            var result = _articleService.InsertOneAsync(POST_PostAndArticleDTO.Id, article);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpPut]
        public IActionResult UpdateArticle([FromBody] PUT_PostAndArticleDTO PUT_PostAndArticleDTO)
        {
            var article = _mapper.Map<Article>(PUT_PostAndArticleDTO.Article);
            var result = _articleService.UpdateOneAsync(PUT_PostAndArticleDTO.Id, article);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteArticle([FromBody] DELETE_PostAndArticleDTO DELETE_PostAndArticleDTO)
        {
            var article = _mapper.Map<Article>(DELETE_PostAndArticleDTO.Article);
            var result = _articleService.DeleteOneAsync(DELETE_PostAndArticleDTO.Id, article);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
