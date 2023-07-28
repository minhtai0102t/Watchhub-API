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
    /// Tìm kiếm
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
    /// Tìm kiếm theo Mã hoặc ID loại sản phẩm
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("SearchByProductTypeCodeOrId")]
    public async Task<IActionResult> SearchByProductTypeCodeOrId([FromQuery] QueryStringParameters param, string searchTerm)
    {
        var res = await _productTypeService.SearchByProductTypeCodeOrId(param, searchTerm);
        return Ok(new { res, res.TotalCount });
    }

    /// <summary>
    /// Tạo mới
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductTypeCreateReq obj)
    {
        var res = await _productTypeService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo loại sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo loại sản phẩm thất bại" });
        }
    }

    /// <summary>
    /// Lấy tất cả
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
    /// Lấy theo ID
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
    /// Lấy hình ảnh theo ID
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
    /// Lấy theo danh sách ID
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
    /// Lọc theo danh mục con
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("FilterBySubCategoryId{subCategoryId}")]
    public async Task<IActionResult> FilterBySubCategoryId([FromQuery] QueryStringParameters param, int subCategoryId, FilterOptions filterOptions)
    {
        var res = await _productTypeService.Filter(param, subCategoryId, filterOptions);
        return Ok(new { res, res.TotalCount });
    }

    /// <summary>
    /// Lọc
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Filter")]
    public async Task<IActionResult> Filter([FromQuery] QueryStringParameters param, FilterOptions filterOptions)
    {
        var res = await _productTypeService.Filter(param, filterOptions);
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
    /// Cập nhật theo ID
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(ProductTypeUpdateReq obj, int id)
    {
        var res = await _productTypeService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật loại sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật loại sản phẩm thất bại" });
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
            return Ok(new { message = "Xoá mềm loại sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm loại sản phẩm thất bại" });
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
            return Ok(new { message = "Xoá loại sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá loại sản phẩm thất bại" });
        }
    }
    #region Admin
    [HttpPost]
    [Route("SearchAdmin")]
    public async Task<IActionResult> SearchAdmin([FromQuery] QueryStringParameters param, string searchTerm)
    {
        var res = await _productTypeService.SearchAdmin(param, searchTerm);
        return Ok(new { res, res.TotalCount });
    }
    [HttpPost]
    [Route("SearchByProductTypeCodeOrIdAdmin")]
    public async Task<IActionResult> SearchByProductTypeCodeOrIdAdmin([FromQuery] QueryStringParameters param, string searchTerm)
    {
        var res = await _productTypeService.SearchByProductTypeCodeOrIdAdmin(param, searchTerm);
        return Ok(new { res, res.TotalCount });
    }
    [HttpGet]
    [Route("GetAllAdmin")]
    public async Task<IActionResult> GetAllAdmin([FromQuery] QueryStringParameters param)
    {
        var res = await _productTypeService.GetAllAdmin(param);
        return Ok(new { res, res.TotalCount });
    }
    [HttpGet]
    [Route("GetAllBySubCategoryIdAdmin{subCategoryId}")]
    public async Task<IActionResult> GetAllBySubCategoryIdAdmin([FromQuery] QueryStringParameters param, int subCategoryId)
    {
        var res = await _productTypeService.GetAllBySubCategoryIdPagingAdmin(param, subCategoryId);
        return Ok(new { res, res.TotalCount });
    }
    #endregion
}
