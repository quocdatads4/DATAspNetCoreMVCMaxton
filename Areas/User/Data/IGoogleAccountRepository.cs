using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IGoogleAccountRepository
    {
        Task<List<GoogleAccountDTO>> GetAllGoogleAccountAsync();
    }

    public class GoogleAccountRepository : IGoogleAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public GoogleAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<List<GoogleAccountDTO>> GetAllGoogleAccountAsync()
        {
            return await _context.AspNetGoogleAccount.ToListAsync();
        }
    }
}
