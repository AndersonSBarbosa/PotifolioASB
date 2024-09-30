using PotifolioASB.Domain.Entities;

namespace PotifolioASB.Infra.Interfaces
{
    public interface IOcorrenciaRepository : IBaseRepository<Ocorrencia>
    {
        Task<IList<Ocorrencia>> BuscaResponsavelCliente(int ResponsavelCliente);
        Task<IList<Ocorrencia>> BuscaResponsavelAbertura(int ResponsavelAbertura);
        Task<IList<Ocorrencia>> BuscaFluxo(int fluxoId);
    }
}