using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PaymentMethodController : ControllerBase
{
    private IPaymentMethodService _paymentMethodService;
    public PaymentMethodController(IPaymentMethodService PaymentMethodService)
    {
        _paymentMethodService = PaymentMethodService;
    }

    /// <summary>
    /// Create
    /// </summary>
    // [Authorize]
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create(PaymentMethodCreateReq obj)
    {
        var res = await _paymentMethodService.Create(obj);
        if (res)
        {
            return Ok(new { message = "Tạo phương thức thanh toán thành công" });
        }
        else
        {
            return BadRequest(new { message = "Tạo phương thức thanh toán thất bại" });
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
        var res = await _paymentMethodService.GetAll(query);
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
        var res = await _paymentMethodService.GetById(id);
        return Ok(res);
    }

    /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpPut]
    [Route("Update{id}")]
    public async Task<IActionResult> Update(PaymentMethodCreateReq obj, int id)
    {
        var res = await _paymentMethodService.Update(obj, id);
        if (res)
        {
            return Ok(new { message = "Cập nhật phương thức thanh toán thành công" });
        }
        else
        {
            return BadRequest(new { message = "Cập nhật phương thức thanh toán thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _paymentMethodService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm phương thức thanh toán thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm phương thức thanh toán thất bại" });
        }
    }

    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _paymentMethodService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá phương thức thanh toán thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá phương thức thanh toán thất bại" });
        }
    }
}
