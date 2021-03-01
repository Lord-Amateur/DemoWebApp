using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models
{
    public class MedicineDetails
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string BatchNo { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="The value of quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Required]
        [Range(0,65536,ErrorMessage ="The value must be between 0 and 65536")]
        public float Rate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ManufactureDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("MedicineRefId")]
        public virtual Medicine Medicine { get; set; }
        public int MedicineRefId { get; set; }

        public virtual IList<Sales> Sales { get; set; }



    }
}
