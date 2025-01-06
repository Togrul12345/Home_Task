using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Dtos.ProductDtos;
using Final.Bl.Exceptions;
using Final.Bl.Services.Concretes;
using Final.Bl.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.Create(createProductDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
                
            }
           
        }
        [HttpDelete("Delete/{id}")]
    
        public async Task<IActionResult> Delete(int id)
        {



            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.DeleteAsync(id));
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
                return StatusCode(StatusCodes.Status200OK, await _productService.GetById(id));
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
                return StatusCode(StatusCodes.Status200OK, await _productService.GetAll());
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
        [HttpPut("Update")]
   
        public async Task<IActionResult> Update(int id, UpdateCategoryDto updateCategoryDto)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.Update(id, updateCategoryDto));
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
        }
    }
}
