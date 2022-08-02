using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPharmacy.Models
{
    public class historyy
    {
        [Key]
        public int his_id { get; set; }
        [ForeignKey("drug")]
        public int drug_id { get; set; }
        [ForeignKey("drug")]
        public string drug_name { get; set; }
        [Required]
        public DateTime comming_date { get; set; }
        [Required]
        public DateTime expirey_date { get; set; }
        public int quantity { get; set; } = 0;
        [Required]
        [StringLength(maximumLength: 100)]
        public string unit { get; set; }
        public bool expired { get; set; }
        public bool finished { get; set; }

        public historyy()
        {

        }
    }
}

/*
        [Required]
        public DateTime production_date { get; set; }*/
