using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using static Ecom_API.Helpers.Constants;

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
    /// Search
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Search")]
    public async Task<IActionResult> Search([FromQuery] QueryStringParameters param, string searchTerm)
    {
        var res = await _productTypeService.Search(param, searchTerm);
        return Ok(new { res, res.TotalCount });
    }
    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
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
    // [Authorize]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters param)
    {
        var res = await _productTypeService.GetAll(param);
        return Ok(new { res, res.TotalCount });
    }
    // [Authorize]
    [HttpGet]
    [Route("GetAllBySubCategoryId{subCategoryId}")]
    public async Task<IActionResult> GetAllBySubCategoryId([FromQuery] QueryStringParameters param, int subCategoryId)
    {
        var res = await _productTypeService.GetAllBySubCategoryIdPaging(param, subCategoryId);
        return Ok(new { res, res.TotalCount });
    }
    // [Authorize]
    [HttpGet]
    [Route("GetAllByBrandId{brandId}")]
    public async Task<IActionResult> GetAllBybrandId([FromQuery] QueryStringParameters param, int brandId)
    {
        var res = await _productTypeService.GetAllByBrandIdPaging(param, brandId);
        return Ok(new { res, res.TotalCount });
    }
    // [Authorize]
    [HttpGet]
    [Route("GetTotalBySubCategoryId{subCategoryId}")]
    public async Task<IActionResult> GetTotalBySubCategoryId(int subCategoryId)
    {
        var res = await _productTypeService.GetTotalBySubCategoryId(subCategoryId);
        return Ok(new { total = res });
    }
    // [Authorize]
    [HttpGet]
    [Route("GetTotalByBrandId{brandId}")]
    public async Task<IActionResult> GetTotalBybrandId(int brandId)
    {
        var res = await _productTypeService.GetTotalByBrandId(brandId);
        return Ok(new { total = res });
    }

    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
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
    // [Authorize]
    [HttpGet]
    [Route("GetImagesById{id}")]
    public async Task<IActionResult> GetImagesById(int id)
    {
        var res = await _productTypeService.GetImagesById(id);
        return Ok(res);
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetByListId")]
    public async Task<IActionResult> GetByListId([FromQuery] List<int> listId)
    {
        var res = await _productTypeService.GetByListId(listId);
        return Ok(res);
    }
    /// <summary>
    /// Filter
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("Filter{subCategoryId}")]
    public async Task<IActionResult> Filter([FromQuery] QueryStringParameters param, int subCategoryId, [FromQuery] FilterOptions filterOptions)
    {
        var res = await _productTypeService.Filter(param, subCategoryId, filterOptions);
        return Ok(new { res, res.TotalCount });
    }
    /// <summary>
    /// Search
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByPrice")]
    public async Task<IActionResult> FilterByPrice([FromQuery] QueryStringParameters param, int minPrice = 0, int maxPrice = 500000000)
    {
        var res = await _productTypeService.FilterByPrice(param, minPrice, maxPrice);
        return Ok(new { res, res.TotalCount });
    }
    /// <summary>
    /// Search
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByGender")]
    public async Task<IActionResult> FilterByGender([FromQuery] QueryStringParameters param, GENDER gender)
    {
        var res = await _productTypeService.FilterByGender(param, gender);
        return Ok(new { res, res.TotalCount });
    }
    /// <summary>
    /// Search
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByDialColor")]
    public async Task<IActionResult> FilterByDialColor([FromQuery] QueryStringParameters param, DIAL_COLOR color)
    {
        var res = await _productTypeService.FilterByDialColor(param, color);
        return Ok(new { res, res.TotalCount });
    }
    [HttpGet]
    [Route("Sort")]
    public async Task<IActionResult> Sort([FromQuery] QueryStringParameters param, [FromQuery] SORT_OPTION sortOption, bool isDescending = false)
    {
        var res = await _productTypeService.Sort(param, sortOption, isDescending);
        return Ok(new { res, res.TotalCount });
    }
    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
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
    // [Authorize]
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
    // [Authorize]
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
