using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class FilterOptions
{
    public List<int> brands { get; set; } = new List<int>();

    public int? minPrice { get; set; } = 0;
    public int? maxPrice { get; set; } = 500000000;
    public List<int> alberts { get; set; } = new List<int>();
    public List<int> cores { get; set; } = new List<int>();
    public List<int> glasses { get; set; } = new List<int>();
    public List<string> genders { get; set; } = new List<string>();
    public List<string> dialColors { get; set; } = new List<string>();
}