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
    public async Task<IActionResult> Create(int product_type_id, string product_code)
    {
        var res = await _productService.Create(product_type_id, product_code);
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
