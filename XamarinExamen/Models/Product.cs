using System;
using System.ComponentModel.DataAnnotations;

namespace XamarinExamen.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set; }
    }
}
