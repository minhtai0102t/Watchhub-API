using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DeliveryController : ControllerBase
{
    private IOrderService _OrderService;
    public DeliveryController(IOrderService OrderService)
    {
        _OrderService = OrderService;
    }
    [HttpPost]
    [Route("T3PDeliveryInTransit{orderId}")]
    public async Task<IActionResult> T3PDeliveryInTransit(int orderId)
    {
        var res = await _OrderService.T3PDeliveryInTransit(orderId);
        if (res)
        {
            return Ok(new { message = $"Order {orderId} đang được vận chuyển" });
        }
        else
        {
            return BadRequest(new { message = $"Order {orderId} cập nhật thất bại" });
        }
    }
    [HttpPost]
    [Route("T3PDeliverySuccess{orderId}")]
    public async Task<IActionResult> T3PDeliverySuccess(int orderId)
    {
        var res = await _OrderService.T3PDeliveryUpdateSuccessful(orderId);
        if (res)
        {
            return Ok(new { message = $"Order {orderId} đã giao thành công" });
        }
        else
        {
            return BadRequest(new { message = $"Order {orderId} cập nhật thất bại" });
        }
    }
    [HttpPost]
    [Route("T3PDeliveryFail{orderId}/{cancelReason}")]
    public async Task<IActionResult> T3PDeliveryFail(int orderId, string cancelReason)
    {
        var res = await _OrderService.T3PDeliveryUpdateFail(orderId, cancelReason);
        return Ok(res);
    }
}
