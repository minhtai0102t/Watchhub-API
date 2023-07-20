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
            return Ok(new { message = $"Order {orderId} is in transit" });
        }
        else
        {
            return BadRequest(new { message = $"Order {orderId} status update failed" });
        }
    }
    [HttpPost]
    [Route("T3PDeliverySuccess{orderId}")]
    public async Task<IActionResult> T3PDeliverySuccess(int orderId)
    {
        var res = await _OrderService.T3PDeliveryUpdateSuccessful(orderId);
        if (res)
        {
            return Ok(new { message = $"Order {orderId} is delivered to customer" });
        }
        else
        {
            return BadRequest(new { message = $"Order {orderId} status update failed" });
        }
    }
    [HttpPost]
    [Route("T3PDeliveryFail{orderId}")]
    public async Task<IActionResult> T3PDeliveryFail(int orderId)
    {
        var res = await _OrderService.T3PDeliveryUpdateFail(orderId);
        if (res)
        {
            return Ok(new { message = $"Order {orderId} is canceled by delivery third party" });
        }
        else
        {
            return BadRequest(new { message = $"Order {orderId} status update failed" });
        }
    }
}
