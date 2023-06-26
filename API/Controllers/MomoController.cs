using DTO.DTO.Models;
using Ecom_API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
[Route("momo")]
[ApiController]
public class MomoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContext;
    public MomoController(IConfiguration configuration, IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
    {
        _configuration = configuration;
        _httpContext = httpContext;
    }

    [HttpPost("create_payment")]
    public async Task<ActionResult<string>> CreatePayment()
    {
        var res = await MomoUtil.CreatePaymentMomo();
        return Ok(res);
    }
}
