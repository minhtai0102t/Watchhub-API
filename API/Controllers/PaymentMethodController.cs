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
            return Ok(new { message = "PaymentMethod creation successful" });
        }
        else
        {
            return BadRequest(new { message = "PaymentMethod creation fail" });
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
            return Ok(new { message = "PaymentMethod update successful" });
        }
        else
        {
            return BadRequest(new { message = "PaymentMethod update failed" });
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
            return Ok(new { message = "PaymentMethod soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "PaymentMethod soft delete failed" });
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
            return Ok(new { message = "PaymentMethod delete successful" });
        }
        else
        {
            return BadRequest(new { message = "PaymentMethod delete failed" });
        }
    }
}
