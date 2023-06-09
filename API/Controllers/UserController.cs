using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.PagingModel;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    /// <summary>
    /// Verify API
    /// </summary>
    /// <param name="string"></param>
    /// <returns>message</returns>
    [AllowAnonymous]
    [HttpGet("Verify")]
    public async Task<IActionResult> Verify(string code, string email)
    {
        var response = await _userService.UserVerification(code, email);
        if (response)
        {
            return Ok(new { message = "Verification successful, User is verified" });

        }
        return BadRequest(new { message = "Verification failed. Incorrect code entered." });
    }
    /// <summary>
    /// Authenticate API
    /// </summary>
    /// <param name="typeof(AuthenticateReq)"></param>
    /// <returns>jwt token</returns>
    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateReq model)
    {
        var response = await _userService.Authenticate(model);
        return Ok(response);
    }
    /// <summary>
    /// Login with google API
    /// </summary>
    /// <param name="typeof(GoogleUser)"></param>
    /// <returns>jwt token</returns>
    [AllowAnonymous]
    [HttpPost("LoginWithGoogle")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleUser req)
    {
        var response = await _userService.LoginWithGoogle(req);
        return Ok(response);
    }
    /// <summary>
    /// Register API
    /// </summary>
    /// <param name="typeof(UserRegisterReq)"></param>
    /// <returns>message</returns>
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterReq model)
    {
        var res = await _userService.Register(model);
        return Ok(new { message = "Registrination successful" });
    }
    /// <summary>
    /// Get List User API
    /// </summary>
    /// <param name="typeof(UserRegisterReq)"></param>
    /// <returns>List<User></returns>
    [Authorize(true)]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _userService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }
    /// <summary>
    /// Get User By Id API
    /// </summary>
    /// <param name="typeof(int)"></param>
    /// <returns>User</returns>
    [Authorize(true)]
    [HttpGet("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }
    /// <summary>
    /// Update API
    /// </summary>
    /// <param name="typeof(UserUpdateReq)"></param>
    /// <returns>message</returns>
    [Authorize]
    [HttpPut("Update{id}")]
    public async Task<IActionResult> Update(UserUpdateReq model, int id)
    {
        var res = await _userService.Update(model, id);
        if (res.token != string.Empty)
        {
            return Ok(res);
        }
        else
        {
            return BadRequest(res);
        }
    }
    /// <summary>
    /// Soft Delete API
    /// </summary>
    /// <param name="typeof(int)"></param>
    /// <returns>message</returns>
    [Authorize(true)]
    [HttpDelete("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _userService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Delete failed" });
        }
    }
    /// <summary>
    /// Delete API
    /// </summary>
    /// <param name="typeof(int)"></param>
    /// <returns>message</returns>
    [Authorize(true)]
    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _userService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Delete successful" });
        }
        else
        {
            return BadRequest(new { message = "Delete failed" });
        }
    }
}
