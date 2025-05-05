using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReciicerAPI.Data;
using ReciicerAPI.Models.Entities;
using ReciicerAPI.Models.HomeViewModels;
using ReciicerAPI.Repository.Interface;

namespace ReciicerAPI.Repository
{
    public class TipoMaterialRepository : ITipoMaterialRepository
    {
        
        private readonly AppDbContext _context;

        public TipoMaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TipoMaterial> ListarTipoMaterial()
        {
            return _context.TipoMaterial.ToList();
        }
        public TipoMaterial ObterTipoMaterialPorId(int id)
        {
            return _context.TipoMaterial.Find(id);
        }

        public void RegistrarTipoMaterial(TipoMaterial tipoMaterial)
        {
            _context.TipoMaterial.Add(tipoMaterial) ;
            _context.SaveChanges();
        }

        public void AtualizarTipoMaterial(TipoMaterial tipoMaterial)
        {
            var tipoMaterialBd = _context.TipoMaterial.Find(tipoMaterial.Id);

            if(tipoMaterialBd != null)
            {
                tipoMaterialBd.Nome = tipoMaterial.Nome;
                tipoMaterialBd.Descricao = tipoMaterial.Descricao;
                tipoMaterialBd.Ativo = tipoMaterial.Ativo;

                _context.TipoMaterial.Update(tipoMaterialBd);
                _context.SaveChanges();
            }
        }

        public void ExcluirTipoMaterial(int id)
        {
            var tipoMaterialBd = _context.TipoMaterial.Find(id);

            if(tipoMaterialBd != null)
            {
                _context.TipoMaterial.Remove(tipoMaterialBd);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TipoMaterialQuantidadeChart> ObterNomeQuantidadeTipoMaterialGrafico(int anoDashboard)
        {
            var sql = MontarQueryGrafico();

            var result = _context.Database.SqlQueryRaw<TipoMaterialQuantidadeChart>(sql, new SqlParameter("@AnoDashboard", anoDashboard)).ToList();
            
            return result;
        }

        public IEnumerable<TipoMaterialQuantidadeChart> ObterNomeQuantidadeTipoMaterialGrafico(int anoDashboard, int pontoColetaId)
        {
            var sql = MontarQueryGrafico();

            var result = _context.Database.SqlQueryRaw<TipoMaterialQuantidadeChart>(sql, new SqlParameter("@AnoDashboard", anoDashboard), new SqlParameter("@PontoColetaId", pontoColetaId)).ToList();
            
            return result;
        }

        private string MontarQueryGrafico()
        {
            var sql = @"Select 
                            TM.Id, TM.Nome AS TipoMaterialNome, Count(MC.Id) AS Quantidade
                        FROM 
                            Coleta C
                            JOIN Material_Coleta MC ON C.Id = MC.ColetaId 
                                AND Year(C.DataOperacao) = @AnoDashboard
                            JOIN Material M ON Mc.MaterialId = M.Id
                            JOIN TipoMaterial TM ON tm.Id = M.TipoMaterialId
                        WHERE(@PontoColetaId = 0 OR C.PontoColetaId = @PontoColetaId))										
                        GROUP BY
                            TM.Nome, TM.id
                        ORDER BY 
                            TM.id;";

            return sql;
        }
    }
}