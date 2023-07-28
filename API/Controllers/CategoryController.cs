using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CategoryCreateReq obj)
    {
        var res = await _categoryService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo danh mục thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo danh mục thất bại" });
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
        var res = await _categoryService.GetAll(query);
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
        var res = await _categoryService.GetById(id);
        return Ok(res);
    }

    [HttpGet]
    [Route("GetByListId{ids}")]
    public async Task<IActionResult> GetByListId(List<int> ids)
    {
        var res = await _categoryService.GetByListId(ids);
        return Ok(res);
    }

    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(CategoryUpdateReq obj, int id)
    {
        var res = await _categoryService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật danh mục thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật danh mục thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _categoryService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm danh mục thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm danh mục thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _categoryService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá danh mục thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá danh mục thất bại" });
        }
    }
}
