using ReciicerAPI.Models.HomeViewModels;
using ReciicerAPI.Repository.Interface;
using Entities = ReciicerAPI.Models.Entities;

namespace ReciicerAPI.Service.TipoMaterial
{
    public class TipoMaterialService
    {
        private readonly ITipoMaterialRepository _tipoMaterialrepository;

        public TipoMaterialService(ITipoMaterialRepository tipoMaterialRepository)
        {
            _tipoMaterialrepository = tipoMaterialRepository;
        }

        
        public IEnumerable<Entities.TipoMaterial> ListarTipoMaterial()
        {
            return _tipoMaterialrepository.ListarTipoMaterial();
        } 

        public Entities.TipoMaterial ObterTipoMaterialPorId(int id)
        {
            return _tipoMaterialrepository.ObterTipoMaterialPorId(id);
        }

        public void RegistrarTipoMaterial(Entities.TipoMaterial tipoMaterial)
        {
            _tipoMaterialrepository.RegistrarTipoMaterial(tipoMaterial);
        }

        public void AtualizarTipoMaterial(Entities.TipoMaterial tipoMaterial)
        {
            _tipoMaterialrepository.AtualizarTipoMaterial(tipoMaterial);
        }

        public void ExcluirTipoMaterial(int id)
        {
            _tipoMaterialrepository.ExcluirTipoMaterial(id);
        }
    
  
        public IEnumerable<TipoMaterialQuantidadeChart> ObterNomeQuantidadeTipoMaterialGrafico(int? anoDashboard)
        {
            var anoFiltroDashBoard = anoDashboard ?? DateTime.Now.Year;

            return _tipoMaterialrepository.ObterNomeQuantidadeTipoMaterialGrafico(anoFiltroDashBoard);  
        }

        public IEnumerable<TipoMaterialQuantidadeChart> ObterNomeQuantidadeTipoMaterialGrafico(int anoDashboard, int pontoColetaId)
        {
            return _tipoMaterialrepository.ObterNomeQuantidadeTipoMaterialGrafico(anoDashboard, pontoColetaId);  
        }

    }
}