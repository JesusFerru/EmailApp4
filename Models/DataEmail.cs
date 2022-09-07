using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmailApp4.Models
{
    public class DataEmail
    {
        [Key]
        public int IdEmail { get; set; }

        public string From { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Es obligatorio")]
        public string To { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Es obligatorio")]
        
        public string? Subject { get; set; }
        
        public string? Body { get; set; }
        public DateTime Date { get; set; }
       // [ForeignKey("EmailTemplate")]
      //  public int IdTemplate { get; set; }
        // [JsonIgnore]
        //   public EmailTemplate Template { get; set; }
    }
}
