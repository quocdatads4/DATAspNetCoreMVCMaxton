using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{
    public interface IFacebookAccountService 
    { 
    
        Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync();

    }
    public class FacebookAccountService : IFacebookAccountService
    {
        private readonly IFacebookAccountRepository _facebookAccountRepository;
        public FacebookAccountService(IFacebookAccountRepository FacebookAccountRepository)
        {
            _facebookAccountRepository = FacebookAccountRepository;
        }
        public async Task<List<FacebookAccountDTO>> GetAllFacebookAccountAsync()
        {
            return await _facebookAccountRepository.GetAllFacebookAccountAsync();
        }

    }
   


}
