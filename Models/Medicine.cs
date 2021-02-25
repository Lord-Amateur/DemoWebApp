using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Generic Name")]
        public string GenericName { get; set; }

        [Required]
        public string Unit { get; set; }

        public string Place { get; set; }

        public virtual IList<MedicineDetails> MedicineDetails { get; set; }

    }
}
