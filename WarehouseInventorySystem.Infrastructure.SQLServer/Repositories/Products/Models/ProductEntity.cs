using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WarehouseInventorySystem.Infrastructure.Common.Base;

namespace WarehouseInventorySystem.Infrastructure.SQLServer.Repositories.Products.Models;

[Table("Products")]
[Index(nameof(Sku), IsUnique = true)]
public class ProductEntity : BaseEntity
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } 

    [Required]
    [MaxLength(8)]
    public string Sku { get; set; } 

    public int Length { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
    
    public ProductEntity(
        string name, 
        string sku, 
        int length, 
        int width, 
        int height
    )
    {
        Name = name;
        Sku = sku;
        Length = length;
        Width = width;
        Height = height;
    }
}