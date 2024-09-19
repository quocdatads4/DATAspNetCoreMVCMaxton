using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Models
{
    public class SocialMainModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string? Name { get; set; }
        public string? Logo { get; set; }
    }
}
