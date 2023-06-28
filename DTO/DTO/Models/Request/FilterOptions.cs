using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class FilterOptions
{
    public int? minPrice { get; set; } = 0;
    public int? maxPrice { get; set; } = 500000000;
    public DIAL_COLOR? dialColor { get; set; } = null;
    public GENDER? gender { get; set; } = null;
}