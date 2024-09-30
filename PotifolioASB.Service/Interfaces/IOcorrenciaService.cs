using PotifolioASB.Domain.Entities;
using PotifolioASB.Service.ViewModels.Ocorrencia;

namespace PotifolioASB.Service.Interfaces
{
    public interface IOcorrenciaService
    {
        Task<Ocorrencia> CreateAsync(CreateOcorrenciaViewModel dto);
        Task<Ocorrencia> UpdateAsync(UpdateOcorrenciaViewModel dto);
        Task RemoveAsync(int id);
        Task<Ocorrencia> GetAsync(int id);
        Task<IList<Ocorrencia>> GetAllAsync();
        Task<IList<Ocorrencia>> BuscaResponsavelCliente(int nome);
        Task<IList<Ocorrencia>> BuscaResponsavelAbertura(int nome);
        Task<IList<Ocorrencia>> BuscaFluxo(int fluxoId);
    }
}
