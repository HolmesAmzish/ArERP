using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.Inventory.Models;

public class TransactionLine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int TransactionId { get; set; }

    [ForeignKey("TransactionId")]
    public Transaction Transaction { get; set; }

    [Required]
    public int ItemId { get; set; }

    [ForeignKey("ItemId")]
    public Item Item { get; set; }

    public decimal Quantity { get; set; }

    public int? WarehouseId { get; set; }

    [ForeignKey("WarehouseId")]
    public Warehouse? Warehouse { get; set; }
}