using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{
    public interface IGoogleAccountService
    {
        Task<List<GoogleAccountDTO>> GetAllGoogleAccountAsync();
    }
    public class GoogleAccountService : IGoogleAccountService
    {
        private readonly IGoogleAccountRepository _googleAccountRepository;
        public GoogleAccountService(IGoogleAccountRepository GoogleAccountRepository)
        {
            _googleAccountRepository = GoogleAccountRepository;
        }
        public async Task<List<GoogleAccountDTO>> GetAllGoogleAccountAsync()
        {
            return await _googleAccountRepository.GetAllGoogleAccountAsync();
        }

    }
}
