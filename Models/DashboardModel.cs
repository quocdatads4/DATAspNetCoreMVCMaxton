using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.Models
{
	public class DashboardModel
	{
		public IEnumerable<SelectListItem>? ProfileGroupSelectList { get; set; }
		public List<ProfileOrbitaModel>? ProfileOrbitas { get; set; }
        public List<UserAccountModel>? UserAccount { get; set; }
		public int ProfileCount { get; set; } // Thêm thuộc tính này

	}
}
