using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.Data
{
    public interface IUserAccountRepository
    {
        Task<UserAccountDTO> GetUserAccountByIdAsync(int id);
        Task UpdateUserAccountAsync(UserAccountDTO userAccount);
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
            var entity = await _context.AspNetUserAccounts.FindAsync(1);
            if (entity != null)
            {
                entity.Name = userAccount.FirstName + " " + userAccount.LastName;
                entity.FirstName = userAccount.FirstName;
                entity.LastName = userAccount.LastName;
                entity.Email = userAccount.Email;
                entity.PhoneNumber = userAccount.PhoneNumber;
                entity.Address = userAccount.Address;
                entity.State = userAccount.State;
                entity.Organization = userAccount.Organization;
                entity.ZipCode = userAccount.ZipCode;
                entity.Country = userAccount.Country;
                entity.Language = userAccount.Language;
                entity.Currency = userAccount.Currency;
                entity.ApiKey = userAccount.ApiKey;
                entity.Avatar = userAccount.Avatar;
                entity.FacebookID = userAccount.FacebookID;
                _context.AspNetUserAccounts.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
