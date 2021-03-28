using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("addimage")]
        public IActionResult AddImage([FromForm(Name = "image")] IFormFile formFile,[FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(carImage, formFile);

            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpPost("updateimage")]
        public IActionResult UpdateImage([FromForm(Name = "image")] IFormFile formFile, [FromForm] CarImage carImage)
        {

            var result = _carImageService.Update(carImage, formFile);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deleteimage")]
        public IActionResult DeleteImage(CarImage carImage)
        {

            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
