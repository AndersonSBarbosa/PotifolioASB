using AutoMapper;
using Moq;
using PotifolioASB.Infra.Interfaces;
using PotifolioASB.Service.Interfaces;
using Xunit;
using Bogus;

namespace PotifolioASB.Test.Services
{
    public class ResponsavelServiceTeste
    {
        private Mock<IResponsavelRepository> _responsavelRepositoryMock;
        private IResponsavelService _responsavelService;
        private IMapper _mapper;


        [Fact]
        public async Task GetAllAsync_ShouldReturnAllResponsaveis()
        {
            // Arrange
            var responsaveis = await _responsavelService.GetAllAsync();

            // Act
            var result = await _responsavelService.GetAllAsync();

            // Assert
            Assert.NotNull(responsaveis.Count);
            Assert.NotNull(result.Count);
        }
    }
}
