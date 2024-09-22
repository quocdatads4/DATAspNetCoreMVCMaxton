using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{
    public interface IFacebookAccountService
    {
        Task<List<FacebookAccountDTO>> GetAllFacebookAccountList();
        Task<_UserMainDTO> GetFacebookAccountForEditAsync(int id);
        Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountEnumerable();
        Task<FacebookAccountDTO> GetFacebookAccountByIdAsync(int id);
        Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountByGroupAsync(int profileGroupId);
        Task AddFacebookAccountAsync(FacebookAccountDTO FacebookAccount);
        Task<bool> EditFacebookAccountAsync(_UserMainDTO model);
        Task<bool> DeleteFacebookAccountAsync(int id);
        
    }
    public class FacebookAccountService : IFacebookAccountService
    {
        private readonly IFacebookAccountRepository _facebookAccountRepository;

        public FacebookAccountService(IFacebookAccountRepository FacebookAccountRepository)
        {
            _facebookAccountRepository = FacebookAccountRepository;
        }

        // Thêm phương thức mới để lấy FacebookAccount theo nhóm
        public async Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountByGroupAsync(int profileGroupId)
        {
            return await _facebookAccountRepository.GetFacebookAccountByGroupAsync(profileGroupId);
        }
        public async Task<IEnumerable<FacebookAccountDTO>> GetFacebookAccountEnumerable()
        {
            return await _facebookAccountRepository.GetAllFacebookAccountAsync();
        }

        public async Task<List<FacebookAccountDTO>> GetAllFacebookAccountList()
        {
            return await _facebookAccountRepository.GetAllFacebookAccountAsync();
        }

        public async Task<FacebookAccountDTO> GetFacebookAccountByIdAsync(int id)
        {
            return await _facebookAccountRepository.GetFacebookAccountByIdAsync(id);
        }

        public async Task AddFacebookAccountAsync(FacebookAccountDTO FacebookAccount)
        {
            await _facebookAccountRepository.AddFacebookAccountAsync(FacebookAccount);
        }
        public async Task<_UserMainDTO> GetFacebookAccountForEditAsync(int id)
        {
            var FacebookAccountInDb = await _facebookAccountRepository.GetFacebookAccountByIdAsync(id);
            if (FacebookAccountInDb == null) return null;

            var mainVM = new _UserMainDTO { FacebookAccount = FacebookAccountInDb };
            return mainVM;
        }

        public async Task<bool> EditFacebookAccountAsync(_UserMainDTO model)
        {
            var FacebookAccountInDb = await _facebookAccountRepository.GetFacebookAccountByIdAsync(model.FacebookAccount.Id);
            if (FacebookAccountInDb == null) return false;

            FacebookAccountInDb.Name = model.FacebookAccount.Name;


            await _facebookAccountRepository.UpdateFacebookAccountAsync(FacebookAccountInDb);
            return true;
        }


        public async Task<bool> DeleteFacebookAccountAsync(int id)
        {
            var FacebookAccount = await _facebookAccountRepository.GetFacebookAccountByIdAsync(id);
            if (FacebookAccount != null)
            {
                await _facebookAccountRepository.DeleteFacebookAccountAsync(id);
                return true;
            }
            return false;
        }
    }
}
