using DTO.DTO.Models;
using DTO.DTO.Models.Response;
using Ecom_API.DTO.Entities;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
using System.Collections.Specialized;
using System.Web;

[Route("payment")]
[ApiController]
public class VnPayController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContext;
    private readonly IVNPayService _vNPayService;
    public VnPayController(IConfiguration configuration, IUnitOfWork unitOfWork, IHttpContextAccessor httpContext, IVNPayService vNPayService)
    {
        _configuration = configuration;
        _httpContext = httpContext;
        _vNPayService = vNPayService;
    }

    [HttpPost("create_payment")]
    public async Task<ActionResult<string>> CreatePayment(PaymentRequestModel model)
    {
        var res = _vNPayService.CreateRequestUrl(model);
        return Ok(res);
    }
    [HttpGet("payment_response")]
    public async Task<ActionResult<string>> PaymentRedirect()
    {
        var httpContext = _httpContext.HttpContext;
        // Get the current URL from the request
        var currentUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{httpContext.Request.QueryString}";

        Uri uri = new Uri(currentUrl);
        NameValueCollection queryParameters = HttpUtility.ParseQueryString(uri.Query);
        PaymentResponse paymentResponse = new PaymentResponse
        {
            Amount = queryParameters["vnp_Amount"],
            BankCode = queryParameters["vnp_BankCode"],
            BankTranNo = queryParameters["vnp_BankTranNo"],
            CardType = queryParameters["vnp_CardType"],
            OrderInfo = queryParameters["vnp_OrderInfo"],
            PayDate = queryParameters["vnp_PayDate"],
            ResponseCode = queryParameters["vnp_ResponseCode"],
            TmnCode = queryParameters["vnp_TmnCode"],
            TransactionNo = queryParameters["vnp_TransactionNo"],
            TransactionStatus = queryParameters["vnp_TransactionStatus"],
            TxnRef = queryParameters["vnp_TxnRef"],
            SecureHash = queryParameters["vnp_SecureHash"]
        };

        var res = await _vNPayService.Create(paymentResponse);
        if (res)
        {
            return Ok(new { message = "VNPay create successful" });
        }
        else
        {
            return BadRequest(new { message = "VnPay create failed" });
        }
    }
    [HttpGet("getall")]
    public async Task<ActionResult<VNPay>> PaymentRedirect([FromQuery] QueryStringParameters param)
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
