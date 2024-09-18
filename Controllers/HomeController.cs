using DATAspNetCoreMVCMaxton.Data;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace DATAspNetCoreMVCMaxton.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public List<ProfileGroupModel> ProfileGroups { get; set; }
        public List<ProfileOrbitaModel> ProfileOrbitas { get; set; }
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> Index()
		{

            var profileGroups = await GetProfileGroupsAsync();
            var profileOrbitas = await GetProfileOrbitasAsync();

            int profileCount = profileOrbitas.Count;

            var profileGroupSelectList = CreateProfileGroupSelectList(profileGroups);
            var dashboardModel = CreateDashboardModel(profileGroupSelectList, profileOrbitas,  profileCount);

            // Điền dữ liệu cần thiết vào từng model
            // ...

            var viewMainVM = new MainVM
            {
                Dashboard = dashboardModel,
            };

            return View(viewMainVM);
        }

       

        // Phương thức này lấy danh sách các ProfileGroup từ cơ sở dữ liệu
        private async Task<List<ProfileGroupModel>> GetProfileGroupsAsync()
        {
            return await _context.AspNetProfileGroup.ToListAsync();
        }

        // Phương thức này lấy danh sách các ProfileOrbita từ cơ sở dữ liệu
        private async Task<List<ProfileOrbitaModel>> GetProfileOrbitasAsync()
        {
            return await _context.AspNetProfileOrbita.ToListAsync();
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
        private DashboardModel CreateDashboardModel(
            List<SelectListItem> profileGroupSelectList, 
            List<ProfileOrbitaModel> profileOrbitas,
			int profileCount
            )
        {
            return new DashboardModel
            {
                ProfileGroupSelectList = profileGroupSelectList,
                ProfileOrbitas = profileOrbitas,
                ProfileCount = profileCount,
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
