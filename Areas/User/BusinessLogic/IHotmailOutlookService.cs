using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{

    public interface IHotmailOutlookService
    {
        Task<List<HotmailOutlookDTO>> GetAllHotmailOutlookAccountAsync();
    }
    public class HotmailOutlookService : IHotmailOutlookService
    {
        private readonly IHotmailOutlookRepository _hotmailOutlookAccountRepository;
        public HotmailOutlookService(IHotmailOutlookRepository HotmailOutlookRepository)
        {
            _hotmailOutlookAccountRepository = HotmailOutlookRepository;
        }
        public async Task<List<HotmailOutlookDTO>> GetAllHotmailOutlookAccountAsync()
        {
            return await _hotmailOutlookAccountRepository.GetAllHotmailOutlookAccountAsync();
        }

    }
}
