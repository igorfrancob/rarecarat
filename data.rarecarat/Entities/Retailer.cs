using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace data.rarecarat.Entities
{
    public class Retailer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Diamond> Diamonds { get; set; }
    }
}
