using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Areas.User.Models
{
    public class GoogleAccountDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute makes Id auto-increment
      public int Id { get; set; }
      public string? Avatar { get; set; }
      public string? Email { get; set; }
      public string? Password { get; set; }
      public string? AppPassword { get; set; }
      public string? BackupCode { get; set; }
      public string? Code2FA { get; set; }
      public string? EmailPrimary { get; set; }
      public string? Status { get; set; }
      public int FacebookGroupID { get; set; }
      public int ProfileOrbitaID { get; set; }
      public string? Name { get; set; }
      public string? FirstName { get; set; }
      public string? LastName { get; set; }
      public DateTime? Birthday { get; set; }
      public string? Phone { get; set; }
      public string? Note { get; set; }

    }
}
