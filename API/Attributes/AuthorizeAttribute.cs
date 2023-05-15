using Ecom_API.Authorization;
using Ecom_API.DTO.Entities;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecom_API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var _jwtUtils = context.HttpContext.RequestServices.GetService<IJwtUtils>();
            var _userService = context.HttpContext.RequestServices.GetService<IUserService>();

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtUtils.ValidateToken(token);
            if (userId != -1)
            {
                // attach user to context on successful jwt validation
                context.HttpContext.Items["User"] = _userService.GetById(userId);
            }
            // authorization
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                var jsonCreateReq = new { message = "Unauthorized" };
                context.Result = new JsonResult(jsonCreateReq) {StatusCode = StatusCodes.Status401Unauthorized};
            }
        }
    }
}

