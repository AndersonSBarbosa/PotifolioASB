using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PotifolioASB.API.Utilities;
using PotifolioASB.Domain.Exceptions;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels;
using PotifolioASB.Service.ViewModels.Fluxo;

namespace PotifolioASB.API.Controllers
{
    public class FluxoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFluxoService _fluxoService;

        public FluxoController(IMapper mapper, IFluxoService fluxoService)
        {
            _mapper=mapper;
            _fluxoService=fluxoService;
        }

        [HttpPost]
        //[Authorize]
        [Route("/api/v1/Fluxo/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateFluxoViewModel dto)
        {
            try
            {

                var itemCreated = await _fluxoService.CreateAsync(dto);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
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
        [Route("/api/v1/Fluxo/update")]
        public async Task<IActionResult> updateasync([FromBody] UpdateFluxoViewModel dto)
        {
            try
            {
                var itemUpdated = await _fluxoService.UpdateAsync(dto);

                return Ok(new ResultViewModel
                {
                    Message = "usuário atualizado com sucesso!",
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
        [Route("/api/v1/Fluxo/remove/{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            try
            {
                await _fluxoService.RemoveAsync(id);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário removido com sucesso!",
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
        [Route("/api/v1/Fluxo/get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var item = await _fluxoService.GetAsync(id);

            if (item == null)
            {
                return Ok(new ResultViewModel
                {
                    Message = "Nenhum Item Foi Encontrado.",
                    Success = true,
                    Data = item
                });
            }
            else
            {
                return NotFound(new ResultViewModel
                {
                    Message = "Item encontrado com sucesso!",
                    Success = true,
                    Data = item
                });
            }
        }


        [HttpGet]
        //[Authorize]
        [Route("/api/v1/Fluxo/get-all")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var itens = await _fluxoService.GetAllAsync();
                decimal saldo = await _fluxoService.CalcularSaldo(itens);
                return Ok(new ResultViewModel
                {
                    Message = "Saldo: "+saldo.ToString(),
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
        [Route("/api/v1/Fluxo/BuscarSaldo")]
        public async Task<IActionResult> BuscarSaldo()
        {
            try
            {
                decimal itens = await _fluxoService.BuscarSaldo();

                return Ok(new ResultViewModel
                {
                    Message = "Saldo: ",
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
        [Route("/api/v1/Fluxo/BuscaExtradoDia")]
        public async Task<IActionResult> BuscaExtradoDia()
        {
            try
            {
                DateTime hoje = DateTime.Now;
                var itens = await _fluxoService.BuscaExtradoDia(hoje.Day, hoje.Month, hoje.Year);
                decimal saldo = await _fluxoService.CalcularSaldo(itens);
                
                return Ok(new ResultViewModel
                {
                    Message = "Extrado do dia: "+ hoje.ToString() + " - Saldo: "+saldo.ToString(),
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
        [Route("/api/v1/Fluxo/BuscaExtrado/{dia}/{mes}/{ano}")]
        public async Task<IActionResult> BuscaExtrado(int? dia, int? mes, int? ano)
        {
            try
            {
                var itens = await _fluxoService.BuscaExtradoDia(dia, mes, ano);
                decimal saldo = await _fluxoService.CalcularSaldo(itens);

                return Ok(new ResultViewModel
                {
                    Message = "Extrado do dia: "+dia+"/"+mes+"/"+ano+" - Saldo: "+saldo.ToString(),
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
