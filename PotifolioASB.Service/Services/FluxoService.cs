using AutoMapper;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels.Fluxo;

namespace PotifolioASB.Service.Services
{
    public class FluxoService : IFluxoService
    {

        private readonly IMapper _mapper;
        private readonly IFluxoRepository _fluxoRepository;

        public FluxoService(IMapper mapper, IFluxoRepository fluxoRepository)
        {
            _mapper=mapper;
            _fluxoRepository=fluxoRepository;
        }

        public IMapper Mapper { get; }
        public IFluxoRepository fluxoRepository { get; }

        public async Task<Fluxo> CreateAsync(CreateFluxoViewModel dto)
        {
            try
            {
                var item = _mapper.Map<Fluxo>(dto);
                var itemCreated = await _fluxoRepository.CreateAsync(item);
                return _mapper.Map<Fluxo>(itemCreated);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<Fluxo> UpdateAsync(UpdateFluxoViewModel dto)
        {
            try
            {
                var itemExists = await _fluxoRepository.GetAsync(dto.Id);

                if (itemExists == null)
                    throw new DomainExceptions("não existe usuario com esse ID informado!");

                var item = _mapper.Map<Fluxo>(dto);

                var itemUpdate = await _fluxoRepository.UpdateAsync(item);

                return _mapper.Map<Fluxo>(itemUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                await _fluxoRepository.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Fluxo> GetAsync(int id)
        {
            try
            {
                var item = await _fluxoRepository.GetAsync(id);
                return _mapper.Map<Fluxo>(item);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<IList<Fluxo>> GetAllAsync()
        {
            try
            {
                var item = await _fluxoRepository.GetAllAsync();
                return _mapper.Map<List<Fluxo>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<decimal> BuscarSaldo()
        {
            try
            {
                decimal saldo = 0;
                var listaSaldo = await GetAllAsync();
                saldo = await CalcularSaldo(listaSaldo);
                return saldo;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public async Task<decimal> BuscarSaldoData(int? dia, int? mes, int? ano)
        {
            try
            {
                decimal saldo = 0;
                    var listaSaldo = await _fluxoRepository.BuscaExtradoData(dia, mes, ano);
                saldo = await CalcularSaldo(listaSaldo);

                return saldo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public async Task<decimal> CalcularSaldo(IList<Fluxo> dto)
        {
            try
            {
                decimal saldo = 0;
                 foreach (var item in dto)
                {
                    if (item.Entrada)
                        saldo = saldo + item.ValorLancamento;
                    else
                        saldo = saldo - item.ValorLancamento;
                }
                return saldo;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<IList<Fluxo>> BuscaExtradoDia(int? dia, int? mes, int? ano)
        {
            try
            {
                var item = await _fluxoRepository.BuscaExtradoData(dia, mes, ano);
                return _mapper.Map<List<Fluxo>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
