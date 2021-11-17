using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Domain
{
    public class Item
    {
        public int ItemId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        [Range(0,1000)]
        public int Amount { get; set; }
    }
}
