using ECommerce.Bl.Dtos.ProductDtos;
using ECommerce.Bl.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
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
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.CreateProductAsync(createProductDto));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
           
               
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetAllAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto, int id)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK,await _productService.UpdateProduct(updateProductDto,id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }


        }
    }
}
