using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductCoreController : ControllerBase
{
    private IProductCoreService _productCoreService;

    public ProductCoreController(IProductCoreService productCoreService)
    {
        _productCoreService = productCoreService;
    }

    /// <summary>
    /// Tạo mới
    /// </summary>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductCoreCreateReq obj)
    {
        var res = await _productCoreService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo máy sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo máy sản phẩm thất bại" });
        }
    }

    /// <summary>
    /// Lấy tất cả
    /// </summary>
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _productCoreService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    /// <summary>
    /// Lấy theo ID
    /// </summary>
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productCoreService.GetById(id);
        return Ok(res);
    }

    /// <summary>
    /// Cập nhật theo ID
    /// </summary>
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductCoreCreateReq obj, int id)
    {
        var res = await _productCoreService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật máy sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật máy sản phẩm thất bại" });
        }
    }

    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productCoreService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm máy sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm máy sản phẩm thất bại" });
        }
    }

    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productCoreService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá máy sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá máy sản phẩm thất bại" });
        }
    }
}

