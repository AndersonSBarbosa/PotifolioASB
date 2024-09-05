using Microsoft.EntityFrameworkCore;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Repository.Context;

namespace PotifolioASB.Infra.Repository
{
    public class FluxoRepository : BaseRepository<Fluxo>, IFluxoRepository
    {
        private readonly ManagerContext _context;

        public FluxoRepository(ManagerContext context) : base(context)
        {
            _context=context;
        }

        public async Task<IList<Fluxo>> BuscaExtradoDia()
        {
            try
            {
                DateTime hoje = DateTime.Now;
                var all = await _context.Fluxo.Where(x => x.DataRegistro.Day == hoje.Day && x.DataRegistro.Month == hoje.Month && x.DataRegistro.Year == hoje.Year).AsNoTracking().ToListAsync();
                return all;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Fluxo>> BuscaExtradoData(int? dia, int? mes, int? ano)
        {
            try
            {
                var all = await _context.Fluxo.Where(x => x.DataRegistro.Day == dia && x.DataRegistro.Month == mes && x.DataRegistro.Year == ano).AsNoTracking().ToListAsync();
                return all;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
