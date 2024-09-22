using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IUserAccountRepository
    {
        Task<UserAccountDTO> GetUserAccountByIdAsync(int id);
        Task UpdateUserAccountAsync(UserAccountDTO userAccount); // Add this method
    }


    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public UserAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAccountDTO> GetUserAccountByIdAsync(int id)
        {
            return await _context.AspNetUserAccounts.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task UpdateUserAccountAsync(UserAccountDTO userAccount)
        {
            _context.AspNetUserAccounts.Update(userAccount);
            await _context.SaveChangesAsync();
        }
    }
}
