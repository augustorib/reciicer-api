using Microsoft.EntityFrameworkCore;
using ReciicerAPI.Data;
using ReciicerAPI.Models.Entities;
using ReciicerAPI.Repository.Interface;

namespace ReciicerAPI.Repository
{
    public class RecolhimentoRepository : IRecolhimentoRepository
    {
        private readonly AppDbContext _context;

        public RecolhimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Recolhimento> ListarRecolhimento()
        {
            return _context.Recolhimento.Include(r => r.RecolhimentoEstoqueMateriais).Include(r => r.Cooperativa).ToList();
        }

        public Recolhimento ObterRecolhimentoPorId(int id)
        {
            return _context.Recolhimento.Include(r => r.Cooperativa)
                                        .Include(r => r.RecolhimentoEstoqueMateriais)
                                        .ThenInclude(rem => rem.EstoqueMaterial)
                                        .ThenInclude(em => em.Material)
                                        .FirstOrDefault(r => r.Id == id);
            
        }

        public void RegistrarRecolhimento(Recolhimento recolhimento)
        {
            _context.Recolhimento.Add(recolhimento);
            _context.SaveChanges();
        }

        public void AtualizarRecolhimento(Recolhimento recolhimento)
        {
            var recolhimentoBd = _context.Recolhimento.Find(recolhimento.Id);

            if(recolhimentoBd != null)
            {
                recolhimentoBd.DataRecolhimento = recolhimento.DataRecolhimento;
                recolhimentoBd.CooperativaId = recolhimento.CooperativaId;
       

                _context.Recolhimento.Update(recolhimentoBd);
                _context.SaveChanges();
            }
        }

        public void ExcluirRecolhimento(int id)
        {
           var recolhimetoExcluir = _context.Recolhimento.Find(id);

           if(recolhimetoExcluir != null)
           {
                _context.Recolhimento.Remove(recolhimetoExcluir);
                _context.SaveChanges();
           }
        }
    }
}