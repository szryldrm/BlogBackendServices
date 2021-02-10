using ArticleServices.Model.Concrete;
using ArticleServices.Model.Dto.Methods.POST;
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

        [HttpPost]
        public IActionResult UpdateArticle([FromBody] POSTPostAndArticleDTO POSTPostAndArticleDTO)
        {
            var article = _mapper.Map<Article>(POSTPostAndArticleDTO.Article);
            var result = _articleService.UpdateOneAsync(POSTPostAndArticleDTO.Id, article);
            if (result.Result.Success)
            {
                return Ok(result.Result.Data);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
