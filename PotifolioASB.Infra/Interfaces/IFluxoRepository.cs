using PotifolioASB.Domain.Entities;

namespace PotifolioASB.Infra.Interfaces
{
    public interface IFluxoRepository : IBaseRepository<Fluxo>
    {
        Task<IList<Fluxo>> BuscaExtradoDia();
        Task<IList<Fluxo>> BuscaExtradoData(int? dia, int? mes, int? ano);

    }
}
