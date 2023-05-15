using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateReq model)
    {
        var response = await _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterReq model)
    {
        var res = await _userService.Register(model);
        return Ok(new { message = "Registrination successful" });
    }

    [Authorize]
    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UserUpdateReq model)
    {
        await _userService.Update(model);
        return Ok(new { message = "User updated successfully" });
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }
}
