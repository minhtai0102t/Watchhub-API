using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductAlbertController : ControllerBase
{
    private IProductAlbertService _ProductAlbertService;

    public ProductAlbertController(IProductAlbertService ProductAlbertService)
    {
        _ProductAlbertService = ProductAlbertService;
    }

    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductAlbertCreateReq obj)
    {
        var res = await _ProductAlbertService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo dây thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo dây thất bại" });
        }
    }

    /// <summary>
    /// Get All
    /// </summary>
    //[Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _ProductAlbertService.GetAll(query);
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
        var res = await _ProductAlbertService.GetById(id);
        return Ok(res);
    }

    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductAlbertCreateReq obj, int id)
    {
        var res = await _ProductAlbertService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật dây thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật dây thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _ProductAlbertService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm dây thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm dây thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _ProductAlbertService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá dây thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá dây thất bại" });
        }
    }
}
