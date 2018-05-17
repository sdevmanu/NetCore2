using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2.Models
{
    public class Item
    {
        [Required]
        [Range(1,100)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
