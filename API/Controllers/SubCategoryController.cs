using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SubCategoryController : ControllerBase
{
    private ISubCategoryService _subCategoryService;

    public SubCategoryController(ISubCategoryService subCategoryService)
    {
        _subCategoryService = subCategoryService;
    }

    /// <summary>
    /// Tạo mới
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(SubCategoryCreateReq obj)
    {
        var res = await _subCategoryService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo danh mục con thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo danh mục con thất bại" });
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
        var res = await _subCategoryService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    /// <summary>
    /// Lấy tất cả theo ID danh mục
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetAllById{categoryId}")]
    public async Task<IActionResult> GetAllById([FromQuery] QueryStringParameters query, int categoryId)
    {
        var res = await _subCategoryService.GetAllById(query, categoryId);
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
        var res = await _subCategoryService.GetById(id);
        return Ok(res);
    }

    /// <summary>
    /// Cập nhật theo ID
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(SubCategoryUpdateReq obj, int id)
    {
        var res = await _subCategoryService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật danh mục con thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật danh mục con thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _subCategoryService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm danh mục con thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm danh mục con thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _subCategoryService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá danh mục con thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá danh mục con thất bại" });
        }
    }
}
