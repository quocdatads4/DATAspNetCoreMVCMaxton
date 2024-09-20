using DATAspNetCoreMVCMaxton.DataAccess;
using DATAspNetCoreMVCMaxton.Models;
using DATAspNetCoreMVCMaxton.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DATAspNetCoreMVCMaxton.BusinessLogic
{

    public interface IProfileOrbitaService
    {
        Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaAsync();
        Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id);
        Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita);
        Task<bool> DeleteProfileOrbitaAsync(int id);
    }
    public class ProfileOrbitaService : IProfileOrbitaService
    {
        private readonly IProfileOrbitaRepository _profileOrbitaRepository;

        public ProfileOrbitaService(IProfileOrbitaRepository profileOrbitaRepository)
        {
            _profileOrbitaRepository = profileOrbitaRepository;
        }

        public async Task<List<ProfileOrbitaDTO>> GetAllProfileOrbitaAsync()
        {
            return await _profileOrbitaRepository.GetAllProfileOrbitaAsync();
        }

        public async Task<ProfileOrbitaDTO> GetProfileOrbitaByIdAsync(int id)
        {
            return await _profileOrbitaRepository.GetProfileOrbitaByIdAsync(id);
        }

        public async Task AddProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            await _profileOrbitaRepository.AddProfileOrbitaAsync(profileOrbita);
        }

        public async Task UpdateProfileOrbitaAsync(ProfileOrbitaDTO profileOrbita)
        {
            await _profileOrbitaRepository.UpdateProfileOrbitaAsync(profileOrbita);
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
