using AutoMapper;
using Bogus;
using Moq;
using PotifolioASB.Domain.Entities;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Service.Interfaces;
using PotifolioASB.Service.ViewModels.Fluxo;
using Xunit;

namespace PotifolioASB.Test.Services
{
    public class FluxoServiceTeste
    {
        private Mock<IFluxoRepository> _fluxoRepositoryMock;
        private IFluxoService _fluxoService;
        private IMapper _mapper;


        [Fact]
        [Trait("Category", "Services")]
        public async Task InsereLancamentoEntrada()
        {
            // Arrange
            var ValorLancamento = new Randomizer().Decimal(1, 100);
            DateTime DataAgora = DateTime.Now;
            var Entrada = new CreateFluxoViewModel {  Descricao = "Entrada de Valores", ValorLancamento = ValorLancamento, Entrada = true };
            
            // Ação
            _fluxoRepositoryMock = new Mock<IFluxoRepository>();
            _fluxoRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Fluxo>()))
                .ReturnsAsync(It.IsAny<Fluxo>());

            var item = _mapper.Map<CreateFluxoViewModel>(Entrada);
            var resultado = await _fluxoService.CreateAsync(item);
            Assert.NotNull(resultado);
            _fluxoRepositoryMock.Verify(x=> x.CreateAsync(It.IsAny<Fluxo>()), Times.Once());
        }

    }
}
