using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private IBrandService _brandService;
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(BrandCreateReq obj)
    {
        var res = await _brandService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Xoá thương hiệu thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá thương hiệu thất bại" });
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
        var res = await _brandService.GetAll(query);
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
        var res = await _brandService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(BrandUpdateReq obj, int id)
    {
        var res = await _brandService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật thương hiệu thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật thương hiệu thất bại" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _brandService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm thương hiệu thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm thương hiệu thất bại" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _brandService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá thương hiệu thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá thương hiệu thất bại" });
        }
    }
}
