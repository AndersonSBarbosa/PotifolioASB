using PotifolioASB.Domain.Entities;
using PotifolioASB.Service.ViewModels.Responsavel;

namespace PotifolioASB.Service.Interfaces
{
    public interface IResponsavelService
    {
        Task<Responsavel> CreateAsync(CreateResponsavelViewModel dto);
        Task<Responsavel> UpdateAsync(UpdateResponsavelViewModel dto);
        Task RemoveAsync(int id);
        Task<Responsavel> GetAsync(int id);
        Task<IList<Responsavel>> GetAllAsync();
        Task<IList<Responsavel>> BuscaNome(string nome);
        Task<Responsavel> BuscaEmail(string email);
        Task<Responsavel> BuscaCPf(string cpf);

    }
}
