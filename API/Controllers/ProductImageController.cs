using DTO.DTO.Models;
using Ecom_API.Attributes;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductImageController : ControllerBase
{
    private IProductImageService _productImageService;
    public ProductImageController(IProductImageService productImageService)
    {
        _productImageService = productImageService;
    }
    /// <summary>
    /// Create
    /// </summary>
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductImageCreateReq obj)
    {
        var res = await _productImageService.Create(obj);
        if (res)
        {
            return Ok(new { message = "ProductImage creation successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductImage creation fail" });
        }
    }
    /// <summary>
    /// Get All
    /// </summary>
    [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var res = await _productImageService.GetAll();
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productImageService.GetById(id);
        return Ok(res);
    }
    [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productImageService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "ProductImage soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductImage soft delete failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productImageService.Delete(id);
        if (res)
        {
            return Ok(new { message = "ProductImage delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductImage delete failed" });
        }
    }
}
