using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DATAspNetCoreMVCMaxton.Models
{
	public class ProfileGroupModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This attribute makes Id auto-increment
		public int Id { get; set; }
		public string? Name { get; set; }

		public int? TotalProfile { get; set; }
	}
}
