using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductGlassController : ControllerBase
{
    private IProductGlassService _productGlassService;

    public ProductGlassController(IProductGlassService productGlassService)
    {
        _productGlassService = productGlassService;
    }

    /// <summary>
    /// Tạo mới
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductGlassCreateReq obj)
    {
        var res = await _productGlassService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo kính sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo kính sản phẩm thất bại" });
        }
    }

    /// <summary>
    /// Lấy tất cả
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _productGlassService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    /// <summary>
    /// Lấy theo ID
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productGlassService.GetById(id);
        return Ok(res);
    }

    /// <summary>
    /// Cập nhật theo ID
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductGlassCreateReq obj, int id)
    {
        var res = await _productGlassService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật kính sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật kính sản phẩm thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productGlassService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm kính sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm kính sản phẩm thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productGlassService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá kính sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá kính sản phẩm thất bại" });
        }
    }
}

