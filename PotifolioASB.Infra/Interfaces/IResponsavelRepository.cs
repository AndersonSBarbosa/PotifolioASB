using PotifolioASB.Domain.Entities;

namespace PotifolioASB.Infra.Interfaces
{
    public interface IResponsavelRepository : IBaseRepository<Responsavel>
    {
        Task<IList<Responsavel>> BuscaNome(string nome);
        Task<Responsavel> BuscaEmail(string email);
        Task<Responsavel> BuscaCPf(string cpf);
    }
}
