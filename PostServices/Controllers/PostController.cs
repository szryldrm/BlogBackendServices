using PostServices.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostServices.Model.Dtos.Methods.GET;
using PostServices.Model.Concrete;
using PostServices.Model.Dtos.Methods.POST;

namespace PostServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _postService.GetAll();
            if (result.Success)
            {
                var mappingData = _mapper.Map<IEnumerable<Post>, IEnumerable<GETPostDTO>>(result.Data);
                return Ok(mappingData);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _postService.FindByIdAsync(id);
            if (result.Result.Success)
            {
                var mappingData = _mapper.Map<Post, GETPostDTO>(result.Result.Data);
                return Ok(mappingData);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpPost]
        public IActionResult Add([FromBody] POSTPostDTO POSTPostDTO)
        {
            var mappingData = _mapper.Map<POSTPostDTO, Post>(POSTPostDTO);

            var result = _postService.InsertOneAsync(mappingData);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
