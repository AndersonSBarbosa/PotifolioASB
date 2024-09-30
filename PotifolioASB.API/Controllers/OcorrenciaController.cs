using Microsoft.AspNetCore.Mvc;
using PotifolioASB.API.Utilities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Service.ViewModels.Ocorrencia;
using PotifolioASB.Service.ViewModels;
using AutoMapper;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Domain.Entities;

namespace PotifolioASB.API.Controllers
{
    public class OcorrenciaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOcorrenciaService _ocorrenciaService;

        public OcorrenciaController(IMapper mapper, IOcorrenciaService ocorrenciaService)
        {
            _mapper=mapper;
            _ocorrenciaService=ocorrenciaService;
        }

        [HttpPost]
        //[Authorize]
        [Route("/api/v1/Ocorrencia/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOcorrenciaViewModel dto)
        {
            try
            {
                var itemCreated = await _ocorrenciaService.CreateAsync(dto);
                return Ok(new ResultViewModel
                {
                    Message = "item criado com sucesso!",
                    Success = true,
                    Data = itemCreated
                });
            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        // [Authorize]
        [Route("/api/v1/Ocorrencia/update")]
        public async Task<IActionResult> updateasync([FromBody] UpdateOcorrenciaViewModel dto)
        {
            try
            {
                var itemUpdated = await _ocorrenciaService.UpdateAsync(dto);

                return Ok(new ResultViewModel
                {
                    Message = "item atualizado com sucesso!",
                    Success = true,
                    Data = itemUpdated
                });

            }
            catch (DomainExceptions ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }

        [HttpDelete]
        //[Authorize]
        [Route("/api/v1/Ocorrencia/remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                await _ocorrenciaService.RemoveAsync(id);
                return Ok(new ResultViewModel
                {
                    Message = "item removido com sucesso!",
                    Success = true,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ErrorMessage(ex.Message));
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("/api/v1/Ocorrencia/get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _ocorrenciaService.GetAsync(id);

            if (item != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = " Item Foi Encontrado.",
                    Success = true,
                    Data = item
                });
            }
            else
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Nenhum Item encontrado com sucesso!",
                    Success = true,
                    Data = item
                });
            }
        }


        [HttpGet]
        //[Authorize]
        [Route("/api/v1/Ocorrencia/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var itens = await _ocorrenciaService.GetAllAsync();

                return Ok(new ResultViewModel
                {
                    Message = "",
                    Success = true,
                    Data = itens
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, Responses.ErrorMessage(ex.Message));
            }

        }


        [HttpGet]
        // [Authorize]
        [Route("/api/v1/Ocorrencia/BuscaResponsavelCliente/{id}")]
        public async Task<IActionResult> BuscaResponsavelCliente(int id)
        {
            var item = await _ocorrenciaService.BuscaResponsavelCliente(id);

            if (item != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = " Item Foi Encontrado.",
                    Success = true,
                    Data = item
                });
            }
            else
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Nenhum Item encontrado com sucesso!",
                    Success = true,
                    Data = item
                });
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("/api/v1/Ocorrencia/BuscaResponsavelAbertura/{id}")]
        public async Task<IActionResult> BuscaResponsavelAbertura(int id)
        {
            var item = await _ocorrenciaService.BuscaResponsavelAbertura(id);

            if (item != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = " Item Foi Encontrado.",
                    Success = true,
                    Data = item
                });
            }
            else
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Nenhum Item encontrado com sucesso!",
                    Success = true,
                    Data = item
                });
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("/api/v1/Ocorrencia/BuscaFluxo/{id}")]
        public async Task<IActionResult> BuscaFluxo(int id)
        {
            var item = await _ocorrenciaService.BuscaFluxo(id);

            if (item != null)
            {
                return Ok(new ResultViewModel
                {
                    Message = " Item Foi Encontrado.",
                    Success = true,
                    Data = item
                });
            }
            else
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Nenhum Item encontrado com sucesso!",
                    Success = true,
                    Data = item
                });
            }
        }


    }
}
