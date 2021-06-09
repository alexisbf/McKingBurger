using System;
using System.ComponentModel.DataAnnotations;
using DomainModel.ValidationAttributes;

namespace DomainModel
{
    public abstract class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [PositiveNumber]
        public int Stockpiled { get; set; }
    }
}
