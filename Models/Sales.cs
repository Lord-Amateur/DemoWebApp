using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The value of quantity must be greater than 0")]
        public int Quantity { get; set; }

        public float Net { get; set; }

        public string  BuyerName { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("MedicineDetailsRefId")]
        public MedicineDetails MedicineDetails { get; set; }
        public int MedicineDetailsRefId { get; set; }

    }
}
