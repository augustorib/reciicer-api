using Microsoft.AspNetCore.Identity;
using Entities = ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Service.UsuarioIdentity
{
    public class UsuarioIdentityService
    {
        private readonly UserManager<Entities.UsuarioIdentity> _userManager;

        public UsuarioIdentityService(UserManager<Entities.UsuarioIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Entities.UsuarioIdentity> ObterUsuarioIdentityPorIdAsync(string usuarioGuid)
        {
            return await _userManager.FindByIdAsync(usuarioGuid) ?? throw new Exception("Usuário não encontrado.");
        }
        
        public IEnumerable<Entities.UsuarioIdentity> ObterUsuariosPorPontoColetaId(int id)
        {
            return _userManager.Users.Where(u => u.PontoColetaId == id).ToList();
        }
  
        
    }
}