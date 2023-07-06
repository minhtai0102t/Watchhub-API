using DTO.DTO.Models;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

[Route("payment")]
[ApiController]
public class VnPayController : ControllerBase
{
    private readonly IVNPayService _vNPayService;
    public VnPayController(IVNPayService vNPayService)
    {
        _vNPayService = vNPayService;
    }

    [HttpPost("create_payment")]
    public async Task<IActionResult> CreatePayment(PaymentRequestModel model)
    {
        var res = _vNPayService.CreateRequestUrl(model);
        return Ok(new {url = res });
    }
    [HttpPost("store_transaction")]
    public async Task<IActionResult> StoreTransaction(StoreVnPayCreateReq model)
    {
        var res = await _vNPayService.Create(model);
        if (res)
        {
            return Ok(new { message = "VNPay store transaction successful" });
        }
        else
        {
            return BadRequest(new { message = "VNPay store transaction fail" });
        }
    }

    [HttpGet("getall")]
    public async Task<ActionResult<VNPay>> GetAll([FromQuery] QueryStringParameters param)
    {
        var res = await _vNPayService.GetAll(param);
        return Ok(res);
    }
        /// <summary>
    /// Get by id 
    /// </summary>
    // [Authorize]
    [HttpGet]
    [Route("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _vNPayService.GetById(id);
        return Ok(res);
    }
    // [Authorize]
    [HttpDelete]
    [Route("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _vNPayService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "VNPay soft delete successful" });
        }
        else
        {
            return BadRequest(new { message = "VNPay soft delete failed" });
        }
    }
    // [Authorize]
    [HttpDelete]
    [Route("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _vNPayService.Delete(id);
        if (res)
        {
            return Ok(new { message = "VNPay delete successful" });
        }
        else
        {
            return BadRequest(new { message = "VNPay delete failed" });
        }
    }
}
