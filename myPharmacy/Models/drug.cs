using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace myPharmacy.Models
{
    public class drug
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string drug_name { get; set; }
        [Key]
        public int drug_id { get; set; }

        public drug()
        {

        }
    }
}
