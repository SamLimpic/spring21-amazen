using System.ComponentModel.DataAnnotations;
using AmaZen.Models;

namespace spring21_amazen.Models
{
    public class WarehouseProductDTO
    // NOTE DTO = Data Transfer Object: The reference for creating a new instance.
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int WarehouseId { get; set; }
    }

    public class WarehouseProductView : Product
    // NOTE : Product allows you to Inherit all the inherent propterties from Product
    // NOTE View = The object we're getting that holds all necessary data
    {
        public string location { get; set; }

        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public int WarehouseProductId { get; set; }
    }
}