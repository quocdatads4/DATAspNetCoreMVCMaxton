using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    public class SocialSelectDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute makes Id auto-increment
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
    }
}
