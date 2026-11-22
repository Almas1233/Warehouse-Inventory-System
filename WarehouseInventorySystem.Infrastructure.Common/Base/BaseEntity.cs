using System.ComponentModel.DataAnnotations;

namespace WarehouseInventorySystem.Infrastructure.Common.Base;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}