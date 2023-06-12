using DTO.DTO.Models.Request;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductCreateReq obj)
    {
        var res = await _productService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Product creation successful" });
        }
        else
        {
            return BadRequest(new { message = "Product creation fail" });
        }
    }
    /// <summary>
    /// Get All
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _productService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductCreateReq obj, int id)
    {
        var res = await _productService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Product update successful" });
        }
        else
        {
            return BadRequest(new { message = "Product update failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Product soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Product soft delete failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Product delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Product delete failed" });
        }
    }
}
