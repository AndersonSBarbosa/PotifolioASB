using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PotifolioASB.API.Utilities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels;
using PotifolioASB.Service.ViewModels.Responsavel;

namespace PotifolioASB.API.Controllers
{
    public class ResponsavelController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IResponsavelService _responsavelService;

        public ResponsavelController(IMapper mapper, IResponsavelService responsavelService)
        {
            _mapper=mapper;
            _responsavelService=responsavelService;
        }

        [HttpPost]
        //[Authorize]
        [Route("/api/v1/Responsavel/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateResponsavelViewModel dto)
        {
            try
            {
                var itemCreated = await _responsavelService.CreateAsync(dto);
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
        [Route("/api/v1/Responsavel/update")]
        public async Task<IActionResult> updateasync([FromBody] UpdateResponsavelViewModel dto)
        {
            try
            {
                var itemUpdated = await _responsavelService.UpdateAsync(dto);

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
        [Route("/api/v1/Responsavel/remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                await _responsavelService.RemoveAsync(id);
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
        [Route("/api/v1/Responsavel/get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _responsavelService.GetAsync(id);

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
        [Route("/api/v1/Responsavel/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var itens = await _responsavelService.GetAllAsync();

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
        //[Authorize]
        [Route("/api/v1/Responsavel/BuscaNome/{nome}")]
        public async Task<IActionResult> BuscaNome(string nome)
        {
            try
            {
                var itens = await _responsavelService.BuscaNome(nome);

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
        //[Authorize]
        [Route("/api/v1/Responsavel/BuscaEmail/{email}")]
        public async Task<IActionResult> BuscaEmail(string email)
        {
            try
            {
                var itens = await _responsavelService.BuscaEmail(email);

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
        //[Authorize]
        [Route("/api/v1/Responsavel/BuscaCPf/{cpf}")]
        public async Task<IActionResult> BuscaCPf(string cpf)
        {
            try
            {
                var itens = await _responsavelService.BuscaCPf(cpf);

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

    }
}
