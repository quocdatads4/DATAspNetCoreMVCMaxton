using DATAspNetCoreMVCMaxton.Data;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DATAspNetCoreMVCMaxton.Controllers
{
	public class ProfileOrbitaController : Controller
	{
		private readonly ApplicationDbContext _context;
		public List<ProfileGroupModel> ProfileGroups { get; set; }
		public ProfileOrbitaController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> CreateProfileOrbita()
		{

			var profileGroups = await GetProfileGroupsAsync();
			var profileGroupSelectList = CreateProfileGroupSelectList(profileGroups);
			var dashboardModel = CreateDashboardModel(profileGroupSelectList);

			var viewMainVM = new MainVM
			{
				Dashboard = dashboardModel
			};

			return View(viewMainVM);

		}
		// Phương thức này lấy danh sách các ProfileGroup từ cơ sở dữ liệu
		private async Task<List<ProfileGroupModel>> GetProfileGroupsAsync()
		{
			return await _context.AspNetProfileGroup.ToListAsync();
		}
		// Phương thức này tạo danh sách SelectListItem từ danh sách ProfileGroup
		private List<SelectListItem> CreateProfileGroupSelectList(List<ProfileGroupModel> profileGroups)
		{
			return profileGroups.Select(g => new SelectListItem
			{
				Value = g.Id.ToString(),
				Text = g.Name
			}).ToList();
		}
		// Phương thức này tạo DashboardModel từ các tham số đầu vào
		private DashboardModel CreateDashboardModel(List<SelectListItem> profileGroupSelectList)
		{
			return new DashboardModel
			{
				ProfileGroupSelectList = profileGroupSelectList,
			};
		}
	}
}
