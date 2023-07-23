using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using static Ecom_API.Helpers.Constants;

[ApiController]
[Route("[controller]")]
public class WarehouseController : ControllerBase
{
    private IOrderService _OrderService;
    public WarehouseController(IOrderService OrderService)
    {
        _OrderService = OrderService;
    }
    [HttpPost]
    [Route("InventoryChecking{orderId}")]
    public async Task<IActionResult> InventoryChecking(int orderId)
    {
        var res = await _OrderService.InventoryChecking(orderId);
        if (res == ORDER_STATUS.AWAITING_COLLECTION.ToString())
        {
            return Ok(new { message = $"Order {orderId} đã sẵn sàng đóng gói" });
        }
        else
        {
            return Ok(new { message = $"Order {orderId} không đủ hàng tồn, vui lòng nhập thêm" });
        }
    }
}
