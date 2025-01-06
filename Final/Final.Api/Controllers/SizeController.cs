using Final.Bl.Dtos.CategoryDtos;
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
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateSizeDto createSizeDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }

            try
            {

                return StatusCode(StatusCodes.Status200OK, await _sizeService.Create(createSizeDto));
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
                return StatusCode(StatusCodes.Status200OK, await _sizeService.DeleteAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetById(id));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpGet("GeAll")]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetAll());
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, UpdateSizeDto updateSizeDto)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.Update(id, updateSizeDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }

    }
}
