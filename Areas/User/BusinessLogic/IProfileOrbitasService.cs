using DATAspNetCoreMVCMaxton.Areas.User.Data;
using DATAspNetCoreMVCMaxton.Areas.User.Models;
using Microsoft.EntityFrameworkCore;

namespace DATAspNetCoreMVCMaxton.Areas.User.BusinessLogic
{

    public interface IProfileOrbitasService
    {
       Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaList();
       Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId);
        Task<_UserMainDTO> GetProfileOrbitaForEditAsync(int id);
        Task<bool> EditProfileOrbitaAsyncTable(_UserMainDTO model);
        Task<bool> EditProfileOrbitaAsync(_UserMainDTO model);

        Task<bool> DeleteProfileOrbitaAsync(int id);
    }
    public class ProfileOrbitaService : IProfileOrbitasService
    {
        private readonly IProfileOrbitasRepository _profileOrbitaRepository;

        public ProfileOrbitaService(IProfileOrbitasRepository profileOrbitaRepository)
        {
            _profileOrbitaRepository = profileOrbitaRepository;
        }
        public async Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaList()
        {
            return await _profileOrbitaRepository.GetAllProfileOrbitaAsync();
        }
        public async Task<IEnumerable<ProfileOrbitaDTO>> GetProfileOrbitasByGroupAsync(int profileGroupId)
        {
            return await _profileOrbitaRepository.GetProfileOrbitasByGroupAsync(profileGroupId);
        }
        public async Task<bool> EditProfileOrbitaAsyncTable(_UserMainDTO model)
        {
            var profileOrbitaInDb = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(model.IdProfileOrbitaTable);
            if (profileOrbitaInDb == null) return false;

            profileOrbitaInDb.ProfileGroupID = model.ProfileGroupIDTable;


            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbitaInDb);
            return true;
        }
        public async Task<_UserMainDTO> GetProfileOrbitaForEditAsync(int id)
        {
            var profileOrbita = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita == null) return null;

            var mainVM = new _UserMainDTO { ProfileOrbita = profileOrbita };
            return mainVM;
        }
        public async Task<bool> EditProfileOrbitaAsync(_UserMainDTO model)
        {
            var profileOrbitaInDb = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(model.ProfileOrbita.Id);
            if (profileOrbitaInDb == null) return false;

            profileOrbitaInDb.ProfileName = model.ProfileOrbita.ProfileName;
            profileOrbitaInDb.ProfileGroupID = model.ProfileOrbita.ProfileGroupID;


            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbitaInDb);
            return true;
        }
        public async Task<bool> DeleteProfileOrbitaAsync(int id)
        {
            var profileOrbita = await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
            if (profileOrbita != null)
            {
                await _profileOrbitaRepository.DeleteProfileOrbitaAsync(id);
                return true;
            }
            return false;
        }
    }




}
