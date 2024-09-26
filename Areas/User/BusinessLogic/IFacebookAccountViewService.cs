using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{

    public interface IFacebookAccountViewService
    {
        Task<FacebookAccountViewDTO> GetFacebookAccountByIdView(int id);

    }
    public class FacebookAccountViewService : IFacebookAccountViewService
    {
        private readonly IFacebookAccountViewRepository _facebookAccountViewRepository;

        public FacebookAccountViewService(IFacebookAccountViewRepository FacebookAccountViewRepository)
        {
            _facebookAccountViewRepository = FacebookAccountViewRepository;
        }
   
        public async Task<FacebookAccountViewDTO> GetFacebookAccountByIdView(int id)
        {
            return await _facebookAccountViewRepository.GetFacebookAccountByIdView(id);
        }

    }
    

}
