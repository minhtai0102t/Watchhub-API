using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class FilterOptions
{
    public int? minPrice { get; set; } = 0;
    public int? maxPrice { get; set; } = 500000000;
    public List<DIAL_COLOR> dialColors { get; set; }
    public List<GENDER> genders { get; set; } 
    public List<int> brands {get;set;}
}