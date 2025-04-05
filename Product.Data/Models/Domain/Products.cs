using System.ComponentModel.DataAnnotations;
namespace Product.Data.Models.Domain;

public class Products
{
    public int Id { get; set; }
    [Required]
    public string? ProductName { get; set; }

    public string? Description { get; set; }
    [Required]
    public string? Price { get; set; }  

    public DateTime CreatedAt { get; set; }
}
