using System.ComponentModel.DataAnnotations;

namespace EmailApp4.Models
{
    public class EmailTemplate
    {
        [Key]
        public int IdTemplate { get; set; }
        [Required]
        public string? NameTemplate { get; set; }
        [Required]
        public string? BodyTemplate { get; set; }
    }
}
