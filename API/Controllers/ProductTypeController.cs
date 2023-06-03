using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductTypeController : ControllerBase
{
    private IProductTypeService _productTypeService;
    public ProductTypeController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }
    /// <summary>
    /// Create
    /// </summary>
    [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductTypeCreateReq obj)
    {
        var res = await _productTypeService.Create(obj);
        if (res)
        {
            return Ok(new { message = "ProductType creation successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductType creation fail" });
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
        var res = await _productTypeService.GetAll();
        return Ok(res);
    }
    [Authorize]
    [HttpGet]
    [Route("GetAllBySubCategoryId{subCategoryId}")]
    public async Task<IActionResult> GetAllBySubCategoryId(int subCategoryId)
    {
        var res = await _productTypeService.GetAllBySubCategoryId(subCategoryId);
        return Ok(res);
    }
    [Authorize]
    [HttpGet]
    [Route("GetAllByBrandId{brandId}")]
    public async Task<IActionResult> GetAllBybrandId(int brandId)
    {
        var res = await _productTypeService.GetAllByBrandId(brandId);
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
        var res = await _productTypeService.GetById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductTypeUpdateReq obj, int id)
    {
        var res = await _productTypeService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "ProductType update successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductType update failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productTypeService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "ProductType soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductType soft delete failed" });
        }
    }
    [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productTypeService.Delete(id);
        if (res)
        {
            return Ok(new { message = "ProductType delete successful" });
        }
        else
        {
            return BadRequest(new { message = "ProductType delete failed" });
        }
    }
}
