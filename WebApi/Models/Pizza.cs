using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Models
{
    [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool Temglutem { get; set; }
        public float Price { get; set; }
        public string? Desc { get; set; }
        public DateTime? Created { get; set; }

    }
}
