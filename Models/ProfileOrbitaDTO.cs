using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Models
{
	public class ProfileOrbitaDTO
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public string? ProfileName { get; set; }
		public string? Status { get; set; }
		public int? ProfileGroupID { get; set; }
		public string? UserId { get; set; }
	}
}
