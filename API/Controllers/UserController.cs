using Ecom_API.Attributes;
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
    /// Xác thực tài khoản người dùng
    /// </summary>
    [AllowAnonymous]
    [HttpGet("Verify")]
    public async Task<IActionResult> Verify(string code, string email)
    {
        var response = await _userService.UserVerification(code, email);
        if (response)
        {
            return Ok(new { message = "Xác thực tài khoản thành công, Tài khoản đã được xác thực" });
        }
        return BadRequest(new { message = "Xác thực tài khoản thất bại. Mã xác thực không đúng." });
    }

    /// <summary>
    /// Xác thực tài khoản bằng tên đăng nhập và mật khẩu
    /// </summary>
    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateReq model)
    {
        var response = await _userService.Authenticate(model);
        return Ok(response);
    }

    /// <summary>
    /// Đăng nhập bằng tài khoản Google
    /// </summary>
    [AllowAnonymous]
    [HttpPost("LoginWithGoogle")]
    public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleUser req)
    {
        var response = await _userService.LoginWithGoogle(req);
        return Ok(response);
    }

    /// <summary>
    /// Đăng ký tài khoản mới
    /// </summary>
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterReq model)
    {
        var res = await _userService.Register(model);
        return Ok(new { message = "Đăng ký tài khoản thành công" });
    }

    /// <summary>
    /// Lấy danh sách tài khoản người dùng
    /// </summary>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] QueryStringParameters query)
    {
        var res = await _userService.GetAll(query);
        var response = new { res, res.TotalCount };
        return Ok(response);
    }

    /// <summary>
    /// Lấy thông tin người dùng theo ID
    /// </summary>
    [HttpGet("GetById{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

    /// <summary>
    /// Cập nhật thông tin tài khoản người dùng
    /// </summary>
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
    /// Xoá mềm tài khoản người dùng
    /// </summary>
    [HttpDelete("SoftDelete{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        var res = await _userService.SoftDelete(id);
        if (res)
        {
            return Ok(new { message = "Xoá mềm tài khoản thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá mềm tài khoản thất bại" });
        }
    }

    /// <summary>
    /// Xoá tài khoản người dùng
    /// </summary>
    [HttpDelete("Delete{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var res = await _userService.Delete(id);
        if (res)
        {
            return Ok(new { message = "Xoá tài khoản thành công" });
        }
        else
        {
            return BadRequest(new { message = "Xoá tài khoản thất bại" });
        }
    }
}

