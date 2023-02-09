using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Entities.Concrete;

namespace NorthwindBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }


        private readonly ICategoryService _categoryService;


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _categoryService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        [Authorize(Roles = "Category.Add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Category.Update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Category.Delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
