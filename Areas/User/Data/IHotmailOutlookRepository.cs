using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IHotmailOutlookRepository
    {
        Task<List<HotmailOutlookDTO>> GetAllHotmailOutlookAccountAsync();
    }

    public class HotmailOutlookRepository : IHotmailOutlookRepository
    {
        private readonly ApplicationDbContext _context;

        public HotmailOutlookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<List<HotmailOutlookDTO>> GetAllHotmailOutlookAccountAsync()
        {
            return await _context.AspNetHotmailOutlook.ToListAsync();
        }
    }
}
