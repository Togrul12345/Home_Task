using AutoMapper;
using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Exceptions;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly ICategoryService _categoryService;

        public CategoryController( ICategoryService categoryService)
        {
            
            _categoryService = categoryService;
        }
        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }
           
            try
            {
               
                return StatusCode(StatusCodes.Status200OK, await _categoryService.Create(createCategoryDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            


            try
            {
                return StatusCode(StatusCodes.Status200OK,await _categoryService.DeleteAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetById(id));
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
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetAll());
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpPut("Update")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Update(int id,UpdateCategoryDto updateCategoryDto)
        {
           
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.Update(id,updateCategoryDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }

    }
}
