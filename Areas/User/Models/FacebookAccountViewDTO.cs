using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    public class FacebookAccountViewDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute makes Id auto-increment
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? UId { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? ProfileOrbitaID { get; set; }
        public string? Status { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Code2FA { get; set; }
        public string? Cookie { get; set; }
        public string? Token { get; set; }
        public string? EmailPrimaryID { get; set; }
        public string? Language { get; set; }
        public string? Birthday { get; set; }
        public string? Sex { get; set; }
        public string? Phone { get; set; }
        public string? Note { get; set; }
        public string? University { get; set; }
        public string? Location { get; set; }
        public string? HomeTown { get; set; }
        public string? FWork { get; set; }
        public string? Friends { get; set; }
        public string? Groups { get; set; }
    }
}
