using DTO.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
using VNPAY_CS_ASPX;
[Route("payment")]
[ApiController]
public class VnPayController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly VnPayUtil vnPayUtil;
    private readonly IUnitOfWork _unitOfWork;
    public VnPayController(IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        this.vnPayUtil = new VnPayUtil(_configuration, _unitOfWork);
    }

    [HttpPost("create_payment")]
    public async Task<ActionResult<string>> CreatePayment(PaymentRequestModel model)
    {
        var res = vnPayUtil.CreateRequestUrl(model);
        return Ok(res);
    }
    [HttpGet("payment_response")]
    public async Task<ActionResult<string>> PaymentRedirect([FromQuery]dynamic res)
    {
        var resObject = res;
        return Ok(res);
    }

}
