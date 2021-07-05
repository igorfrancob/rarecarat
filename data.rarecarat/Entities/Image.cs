using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace data.rarecarat.Entities
{
    public class Image
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }

        [Required]
        public int DiamondId { get; set; }

        [ForeignKey("DiamondId")]
        public Diamond Diamond { get; set; }
    }
}
