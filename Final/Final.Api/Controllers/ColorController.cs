using Final.Bl.Dtos.ColorDtos;
using Final.Bl.Dtos.SizeDtos;
using Final.Bl.Exceptions;
using Final.Bl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateColorDto createColorDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }

            try
            {

                return StatusCode(StatusCodes.Status200OK, await _colorService.Create(createColorDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {



            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.DeleteAsync(id));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {



            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetById(id));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetAll());
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateColorDto updateColorDto)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.Update(id, updateColorDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
    }
}
