using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductCoreController : ControllerBase
{
    private IProductCoreService _ProductCoreService;
    public ProductCoreController(IProductCoreService ProductCoreService)
    {
        _ProductCoreService = ProductCoreService;
    }
    /// <summary>
    /// Create
    /// </summary>
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductCoreCreateReq obj)
    {
        var res = await _ProductCoreService.Create(obj);
        if (res)
        {
            return Ok(new { message = "ProductCore creation successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductCore creation fail" });
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
        var res = await _ProductCoreService.GetAll(query);
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
        var res = await _ProductCoreService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductCoreCreateReq obj, int id)
    {
        var res = await _ProductCoreService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "ProductCore update successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductCore update failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _ProductCoreService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "ProductCore soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductCore soft delete failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _ProductCoreService.Delete(id);
        if (res)
        {
            return Ok(new { message = "ProductCore delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductCore delete failed" });
        }
    }
}
