using Ecom_API.Attributes;
using Ecom_API.Authorization;
using Ecom_API.DTO.Models;
using Ecom_API.Helpers;
using Ecom_API.Service;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductSearchController : ControllerBase
{
    private readonly GoogleHelperService _googleSearchService;
    public ProductSearchController(GoogleHelperService googleSearchService)
    {
        _googleSearchService = googleSearchService;
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> Search(string searchTerm){
        var result = await _googleSearchService.SearchProducts(searchTerm);
        return Ok(result);
    }

}
