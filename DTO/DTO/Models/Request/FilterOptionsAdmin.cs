using static Ecom_API.Helpers.Constants;

namespace Ecom_API.DTO.Models;
public class FilterOptionsAdmin
{
    public List<int> ids { get; set; }
    public List<string> productTypeCodes { get; set; }
    public List<string> productTypeNames { get; set; }
    public List<int> brands { get; set; }
    public int? minPrice { get; set; } = 0;
    public int? maxPrice { get; set; } = int.MaxValue;
    public List<int> alberts { get; set; }
    public List<int> cores { get; set; }
    public List<int> glasses { get; set; }
    public List<string> genders { get; set; }
    public List<string> dialColors { get; set; }
    public List<string> sources { get; set; }
    public DateTime? createdFrom { get; set; }
    public DateTime? createdTo { get; set; }
    public DateTime? updatedFrom { get; set; }
    public DateTime? updatedTo{ get; set; }
}