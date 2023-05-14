using Ecom_API.Attributes;
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
        return Ok(new { message = "Registration successful" });
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userService.GetById(new Guid(id));
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UserUpdateReq model)
    {
        await _userService.Update(model);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _userService.Delete(new Guid(id));
        return Ok(new { message = "User deleted successfully" });
    }
}
