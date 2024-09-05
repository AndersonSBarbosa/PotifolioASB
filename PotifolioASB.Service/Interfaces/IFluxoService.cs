using PotifolioASB.Domain.Entities;
using PotifolioASB.Service.ViewModels.Fluxo;

namespace PotifolioASB.Service.Interfaces
{
    public interface IFluxoService
    {
        Task<Fluxo> CreateAsync(CreateFluxoViewModel dto);
        Task<Fluxo> UpdateAsync(UpdateFluxoViewModel dto);
        Task RemoveAsync(int id);
        Task<Fluxo> GetAsync(int id);
        Task<IList<Fluxo>> GetAllAsync();
        Task<IList<Fluxo>> BuscaExtradoDia(int? dia, int? mes, int? ano);
        Task<decimal> BuscarSaldoData(int? dia, int? mes, int? ano);
        Task<decimal> BuscarSaldo();
        Task<decimal> CalcularSaldo(IList<Fluxo> dto);


    }
}
