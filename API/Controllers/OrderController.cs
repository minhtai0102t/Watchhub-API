using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using static Ecom_API.Helpers.Constants;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private IOrderService _OrderService;
    public OrderController(IOrderService OrderService)
    {
        _OrderService = OrderService;
    }
    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(OrderCreateReq obj)
    {
        var res = await _OrderService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Order creation successful" });
        }
        else
        {
            return BadRequest(new { message = "Order creation fail" });
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
        var res = await _OrderService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
      /// <summary>
    /// Get All
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("SearchByOrderStatus")]
    public async Task<IActionResult> SearchByOrderStatus([FromQuery] QueryStringParameters query, string orderStatus)
    {
        var res = await _OrderService.SearchByOrderStatus(query, orderStatus);
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
        var res = await _OrderService.GetById(id);
        return Ok(res);
    }
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(int id, string orderStatus)
    {
        var res = await _OrderService.Update(id, orderStatus);
        if (res)
        {
            return Ok(new { message = "Order status update successful" });
        }
        else
        {
            return BadRequest(new { message = "Order status update failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _OrderService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Order soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Order soft delete failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _OrderService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Order delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Order delete failed" });
        }
    }
}
