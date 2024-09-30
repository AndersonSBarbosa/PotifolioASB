using AutoMapper;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels.Ocorrencia;

namespace PotifolioASB.Service.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {

        private readonly IMapper _mapper;
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly IResponsavelService _responsavelService;

        public OcorrenciaService(IMapper mapper, IOcorrenciaRepository ocorrenciaRepository, IResponsavelService responsavelService)
        {
            _mapper=mapper;
            _ocorrenciaRepository=ocorrenciaRepository;
            _responsavelService=responsavelService;
        }

        public IMapper Mapper { get; }
        public IOcorrenciaRepository OcorrenciaRepository { get; }
        public IResponsavelService ResponsavelService { get; }

        public async Task<IList<Ocorrencia>> BuscaFluxo(int fluxoId)
        {
            try
            {
                var item = await _ocorrenciaRepository.BuscaFluxo(fluxoId);
                return _mapper.Map<List<Ocorrencia>>(item);
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
                var item = await _ocorrenciaRepository.BuscaResponsavelAbertura(ResponsavelAbertura);
                return _mapper.Map<List<Ocorrencia>>(item);
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
                var item = await _ocorrenciaRepository.BuscaResponsavelCliente(ResponsavelCliente);
                return _mapper.Map<List<Ocorrencia>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Ocorrencia> CreateAsync(CreateOcorrenciaViewModel dto)
        {
            try
            { 
                if (dto.ResponsavelAbertura == dto.ResponsavelOcorrencia)
                {
                    throw new DomainExceptions("O Responsavel Abertura de deve ser diferente do Responsavel Ocorrencia");
                }
                else
                {
                    var item = _mapper.Map<Ocorrencia>(dto);
                    var itemCreated = await _ocorrenciaRepository.CreateAsync(item);
                    return _mapper.Map<Ocorrencia>(itemCreated);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Ocorrencia>> GetAllAsync()
        {
            try
            {
                var item = await _ocorrenciaRepository.GetAllAsync();
                return _mapper.Map<List<Ocorrencia>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Ocorrencia> GetAsync(int id)
        {
            try
            {
                var item = await _ocorrenciaRepository.GetAsync(id);
                return _mapper.Map<Ocorrencia>(item);
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
                await _ocorrenciaRepository.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Ocorrencia> UpdateAsync(UpdateOcorrenciaViewModel dto)
        {
            try
            {
                var itemExists = await _ocorrenciaRepository.GetAsync(dto.Id);

                if (itemExists == null)
                    throw new DomainExceptions("não existe item com esse ID informado!");

                if (dto.ResponsavelAbertura == dto.ResponsavelOcorrencia)
                {
                    throw new DomainExceptions("O Responsavel Abertura de deve ser diferente do Responsavel Ocorrencia");
                }
                else
                {
                    var item = _mapper.Map<Ocorrencia>(dto);
                    var itemUpdate = await _ocorrenciaRepository.UpdateAsync(item);
                    return _mapper.Map<Ocorrencia>(itemUpdate);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
