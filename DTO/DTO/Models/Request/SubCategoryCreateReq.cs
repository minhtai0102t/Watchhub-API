using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_API.DTO.Models;
public class SubCategoryCreateReq
{
    public int category_id {get;set;}
    public string sub_category_name { get; set; }
}