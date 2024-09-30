using AutoMapper;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels.Responsavel;

namespace PotifolioASB.Service.Services
{
    public class ResponsavelService : IResponsavelService
    {

        private readonly IMapper _mapper;
        private readonly IResponsavelRepository _ocorrenciaRepository;

        public ResponsavelService(IMapper mapper, IResponsavelRepository responsavelRepository)
        {
            _mapper=mapper;
            _ocorrenciaRepository=responsavelRepository;
        }

        public IMapper Mapper { get; }
        public IResponsavelRepository responsavelRepository { get; }

        public async Task<Responsavel> BuscaCPf(string cpf)
        {
            try
            {
                var item = await _ocorrenciaRepository.BuscaCPf(cpf);
                return _mapper.Map<Responsavel>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Responsavel> BuscaEmail(string email)
        {
            try
            {
                var item = await _ocorrenciaRepository.BuscaEmail(email);
                return _mapper.Map<Responsavel>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Responsavel>> BuscaNome(string nome)
        {
            try
            {
                var item = await _ocorrenciaRepository.BuscaNome(nome);
                return _mapper.Map<List<Responsavel>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Responsavel> CreateAsync(CreateResponsavelViewModel dto)
        {
            try
            {
                var itemExists = await _ocorrenciaRepository.BuscaCPf(dto.Cpf);

                if (itemExists != null)
                    throw new DomainExceptions("Cpf já Cadastrado");

                itemExists = await _ocorrenciaRepository.BuscaEmail(dto.Email);

                if (itemExists != null)
                    throw new DomainExceptions("e-mail já Cadastrado");

                var item = _mapper.Map<Responsavel>(dto);
                var itemCreated = await _ocorrenciaRepository.CreateAsync(item);
                return _mapper.Map<Responsavel>(itemCreated);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<Responsavel>> GetAllAsync()
        {
            try
            {
                var item = await _ocorrenciaRepository.GetAllAsync();
                return _mapper.Map<List<Responsavel>>(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Responsavel> GetAsync(int id)
        {
            try
            {
                var item = await _ocorrenciaRepository.GetAsync(id);
                return _mapper.Map<Responsavel>(item);
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

        public async Task<Responsavel> UpdateAsync(UpdateResponsavelViewModel dto)
        {
            try
            {
                var itemExists = await _ocorrenciaRepository.GetAsync(dto.Id);
                if (itemExists == null)
                    throw new DomainExceptions("não existe item com esse ID informado!");

                if(dto.Cpf != itemExists.Cpf)
                {
                    var verificaCPF = await _ocorrenciaRepository.BuscaCPf(dto.Cpf);
                    if (verificaCPF != null)
                        throw new DomainExceptions("Cpf já Cadastrado");
                }

                if(dto.Email != itemExists.Email)
                {
                    var verificaemail = await _ocorrenciaRepository.BuscaEmail(dto.Email);
                    if (itemExists != null)
                        throw new DomainExceptions("e-mail já Cadastrado");
                }

                var item = _mapper.Map<Responsavel>(dto);

                item.DataRegistro = itemExists.DataRegistro;
                item.Ativo = itemExists.Ativo;

                var itemUpdate = await _ocorrenciaRepository.UpdateAsync(item);

                return _mapper.Map<Responsavel>(itemUpdate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
