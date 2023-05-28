using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
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
    /// Create
    /// </summary>
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(SubCategoryCreateReq obj)
    {
        var res = await _subCategoryService.Create(obj);
        if (res)
        {
            return Ok(new { message = "SubCategory creation successful" });
        }
        else
        {
            return BadRequest(new { message = "SubCategory creation fail" });
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
        var res = await _subCategoryService.GetAll();
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
        var res = await _subCategoryService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(SubCategoryUpdateReq obj, int id)
    {
        var res = await _subCategoryService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "SubCategory update successful" });
        }
        else
        {
            return BadRequest(new { message = "SubCategory update failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id){
        var res = await _subCategoryService.SoftDelete(id);
         if (res)
        {
            return Ok(new { message = "SubCategory soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "SubCategory soft delete failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id){
        var res = await _subCategoryService.Delete(id);
         if (res)
        {
            return Ok(new { message = "SubCategory delete successful" });
        }
        else
        {
            return BadRequest(new { message = "SubCategory delete failed" });
        }
    }
}
