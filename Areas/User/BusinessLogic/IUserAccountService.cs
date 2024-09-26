using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using NuGet.Protocol.Core.Types;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{
    
    public interface IUserAccountService
    {
        Task<UserAccountDTO> GetUserAccountByIdAsync(int id);
        Task UpdateUserAccountAsync(UserAccountDTO userAccount);
    }
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }
        public async Task<UserAccountDTO> GetUserAccountByIdAsync(int id)
        {
            return await _userAccountRepository.GetUserAccountByIdAsync(id);
        }
        public async Task UpdateUserAccountAsync(UserAccountDTO userAccount)
        {
            await _userAccountRepository.UpdateUserAccountAsync(userAccount);
        }
    }
}
