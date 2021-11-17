using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public int? ParentId { get; set; }
    }
}
