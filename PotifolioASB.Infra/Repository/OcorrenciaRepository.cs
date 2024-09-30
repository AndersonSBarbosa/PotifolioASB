using Microsoft.EntityFrameworkCore;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Repository.Context;

namespace PotifolioASB.Infra.Repository
{
    public class OcorrenciaRepository : BaseRepository<Ocorrencia>, IOcorrenciaRepository
    {

        private readonly ManagerContext _context;

        public OcorrenciaRepository(ManagerContext context) : base(context)
        {
            _context=context;
        }

        public async Task<IList<Ocorrencia>> BuscaFluxo(int fluxoId)
        {
            try
            {
                return await _context.Ocorrencia.Where(x => x.FluxoId == fluxoId).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Ocorrencia>> BuscaResponsavelAbertura(int ResponsavelAbertura)
        {
            try
            {
                return await _context.Ocorrencia.Where(x => x.ResponsavelAbertura == ResponsavelAbertura).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Ocorrencia>> BuscaResponsavelCliente(int ResponsavelCliente)
        {
            try
            {
                return await _context.Ocorrencia.Where(x => x.ResponsavelOcorrencia == ResponsavelCliente).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
