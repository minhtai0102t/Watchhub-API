using DTO.DTO.Models;
using Microsoft.AspNetCore.Mvc;
using VNPAY_CS_ASPX;
[Route("payment")]
[ApiController]
public class VnPayController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly VnPayUtil vnPayUtil;
    public VnPayController(IConfiguration configuration)
    {
        _configuration = configuration;
        this.vnPayUtil = new VnPayUtil(_configuration);
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
