using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PAW.Models.ViewModels;

public class ProductViewModel
{
    [JsonPropertyName("tempID")]
    public int TempID { get; set; }

    [JsonPropertyName("identifier")]
    public int Identifier { get; set; }

    [JsonPropertyName("productId")]
    [Display(Name = "Product Id")]
    public int ProductId { get; set; }

    [JsonPropertyName("productName")]
    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }

    [JsonPropertyName("inventoryId")]
    [Display(Name = "Inventory Id")]
    public int? InventoryId { get; set; }

    [JsonPropertyName("supplierId")]
    [Display(Name = "Supplier Id")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("description")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [JsonPropertyName("rating")]
    [Display(Name = "Rating")]
    [DataType(DataType.Currency)]
    public decimal? Rating { get; set; }

    [JsonPropertyName("categoryId")]
    [Display(Name = "Category Id")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("lastModified")]
    [Display(Name = "Last Modified")]
    [DataType(DataType.Date)]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("createdDate")]
    [Display(Name = "Created Date")]
    [DataType(DataType.Date)]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("createdBy")]
    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("modifiedBy")]
    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
}
