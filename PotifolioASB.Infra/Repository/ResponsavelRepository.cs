using Microsoft.EntityFrameworkCore;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Repository.Context;

namespace PotifolioASB.Infra.Repository
{
    public class ResponsavelRepository : BaseRepository<Responsavel>, IResponsavelRepository
    {
        private readonly ManagerContext _context;

        public ResponsavelRepository(ManagerContext context) : base(context)
        {
            _context=context;
        }

        public async Task<Responsavel> BuscaCPf(string cpf)
        {
            try
            {
               return await _context.Responsavel.Where(x => x.Cpf == cpf ).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Responsavel> BuscaEmail(string email)
        {
            try
            {
                return await _context.Responsavel.Where(x => x.Email == email).AsNoTracking().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Responsavel>> BuscaNome(string nome)
        {
            try
            {
                return await _context.Responsavel.Where(x => x.Nome == nome).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
