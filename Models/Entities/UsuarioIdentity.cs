using Microsoft.AspNetCore.Identity;

namespace ReciicerAPI.Models.Entities
{
    public class UsuarioIdentity : IdentityUser
    {
        public int PontoColetaId { get; set; }

        public PontoColeta? PontoColeta { get; set; }
    }
}