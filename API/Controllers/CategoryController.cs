using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
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
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(CategoryCreateReq obj)
    {
        var res = await _categoryService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Category creation successful" });
        }
        else
        {
            return BadRequest(new { message = "Category creation fail" });
        }
    }
    /// <summary>
    /// Get All
    /// </summary>
    [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var res = await _categoryService.GetAll();
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _categoryService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(CategoryUpdateReq obj, int id)
    {
        var res = await _categoryService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Category update successful" });
        }
        else
        {
            return BadRequest(new { message = "Category update failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id){
        var res = await _categoryService.SoftDelete(id);
         if (res)
        {
            return Ok(new { message = "Category soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Category soft delete failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id){
        var res = await _categoryService.Delete(id);
         if (res)
        {
            return Ok(new { message = "Category delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Category delete failed" });
        }
    }
}
