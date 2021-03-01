using CategoryServices.Model.Concrete;
using CategoryServices.Service.Abstract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryServices.Model.Dto.Methods.POST;

namespace ArticleServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult InsertCategory([FromBody] POST_PostAndCategoryDTO POST_PostAndCategoryDTO)
        {
            var result = _categoryService.InsertAsync(POST_PostAndCategoryDTO.Id, POST_PostAndCategoryDTO.Categories);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpPost("one")]
        public IActionResult InsertOneCategory([FromBody] POST_PostAndCategoryOneDTO POST_PostAndCategoryOneDTO)
        {
            var result = _categoryService.InsertOneAsync(POST_PostAndCategoryOneDTO.Id, POST_PostAndCategoryOneDTO.Category);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteCategory([FromBody] DELETE_PostAndCategoryDTO DELETE_PostAndCategoryDTO)
        {
            var result = _categoryService.DeleteOneAsync(DELETE_PostAndCategoryDTO.Id, DELETE_PostAndCategoryDTO.Category);
            if (result.Result.Success)
            {
                return Ok(result.Result.Message);
            }
            return BadRequest(result.Result.Message);
        }
    }
}
