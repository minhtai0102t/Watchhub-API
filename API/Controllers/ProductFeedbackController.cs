using DTO.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductFeedbackController : ControllerBase
{
    private IProductFeedbackService _productFeedbackService;

    public ProductFeedbackController(IProductFeedbackService productFeedbackService)
    {
        _productFeedbackService = productFeedbackService;
    }

    /// <summary>
    /// Tạo mới đánh giá sản phẩm
    /// </summary>
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(ProductFeedbackCreateReq req)
    {
        var res = await _productFeedbackService.Create(req);
        if (res)
        {
            return Ok(new { message = "Tạo đánh giá sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo đánh giá sản phẩm thất bại" });
        }
    }

    /// <summary>
    /// Lấy tất cả đánh giá sản phẩm
    /// </summary>
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _productFeedbackService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    /// <summary>
    /// Lấy đánh giá sản phẩm theo ID
    /// </summary>
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _productFeedbackService.GetById(id);
        return Ok(res);
    }

    [HttpGet]
    [Route("GetByUserId{userId}")]
    public async Task<IActionResult> GetByUserId([FromQuery] QueryStringParameters query, int userId)
    {
        var res = await _productFeedbackService.GetByUserId(query, userId);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    [HttpGet]
    [Route("GetByProductTypeId{productTypeId}")]
    public async Task<IActionResult> GetByProductTypeId([FromQuery] QueryStringParameters query, int productTypeId)
    {
        var res = await _productFeedbackService.GetByProductTypeId(query, productTypeId);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _productFeedbackService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm đánh giá sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm đánh giá sản phẩm thất bại" });
        }
    }

    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _productFeedbackService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá đánh giá sản phẩm thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá đánh giá sản phẩm thất bại" });
        }
    }
}
