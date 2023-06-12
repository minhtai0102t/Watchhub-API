using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductGlassController : ControllerBase
{
    private IProductGlassService _ProductGlassService;
    public ProductGlassController(IProductGlassService ProductGlassService)
    {
        _ProductGlassService = ProductGlassService;
    }
    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    // [HttpPost]
    // [Route("Create")]
    // public async Task<IActionResult> Create(ProductGlassCreateReq obj)
    // {
    //     var res = await _ProductGlassService.Create(obj);
    //     if (res)
    //     {
    //         return Ok(new { message = "ProductGlass creation successful" });
    //     }
    //     else
    //     {
    //         return BadRequest(new { message = "ProductGlass creation fail" });
    //     }
    // }
    /// <summary>
    /// Get All
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _ProductGlassService.GetAll(query);
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
        var res = await _ProductGlassService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductGlassCreateReq obj, int id)
    {
        var res = await _ProductGlassService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "ProductGlass update successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductGlass update failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _ProductGlassService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "ProductGlass soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductGlass soft delete failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _ProductGlassService.Delete(id);
        if (res)
        {
            return Ok(new { message = "ProductGlass delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductGlass delete failed" });
        }
    }
}
