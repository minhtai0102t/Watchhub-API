using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Models;
public class CategoryCreateReq
{
    public string category_name { get; set; }
}