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
        return Ok(new { OrderId = res });
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
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _OrderService.GetByIdFullRes(id);
        return Ok(res);
    }
    /// <summary>
    /// FilterByOrderStatus
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByOrderStatus")]
    public async Task<IActionResult> SearchByOrderStatus([FromQuery] QueryStringParameters query, ORDER_STATUS orderStatus)
    {
        var res = await _OrderService.SearchByOrderStatus(query, orderStatus);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
    /// <summary>
    /// FilterByOrderStatus
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByOrderStatus{userId}")]
    public async Task<IActionResult> SearchUserOrderStatus([FromQuery] QueryStringParameters query, ORDER_STATUS orderStatus, int userId)
    {
        var res = await _OrderService.SearchByOrderStatus(query, orderStatus, userId);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
    /// <summary>
    /// FilterByUserId
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("FilterByUserId{userId}")]
    public async Task<IActionResult> SearchUserOrderStatusById([FromQuery] QueryStringParameters query, int userId)
    {
        var res = await _OrderService.SearchByOrderStatus(query, userId);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(int id, ORDER_STATUS orderStatus)
    {
        var res = await _OrderService.Update(id, orderStatus);
        if (res)
        {
            return Ok(new { message = "Cập nhật trạng thái đơn hàng thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật trạng thái đơn hàng thất bại" });
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
            return Ok(new { message = "Xoá mềm đơn hàng thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm đơn hàng thất bại" });
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
            return Ok(new { message = "Xoá đơn hàng thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá đơn hàng thất bại" });
        }
    }
    [HttpPost]
    [Route("ConfirmationChecking{id}")]
    public async Task<IActionResult> ConfirmationChecking(int id){
        var res = await _OrderService.ConfirmationChecking(id);
        if (res)
        {
            return Ok(new { message = "Xác nhận đơn hàng thành công" });
        }
        else
        {
            return BadRequest(new { message = "Đơn hàng VNPay chưa được thanh toán" });
        }
    }
}
