using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindBackend.Business.Abstract;
using NorthwindBackend.Entities.Concrete;

namespace NorthwindBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        public RegionsController(IRegionService regionService)
        {
            this._regionService = regionService;
        }


        private readonly IRegionService _regionService;


        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _regionService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int Id)
        {
            var result = _regionService.GetById(Id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(Region region)
        {
            var result = _regionService.Add(region);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Region region)
        {
            var result = _regionService.Update(region);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Region region)
        {
            var result = _regionService.Delete(region);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
