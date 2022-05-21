
using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.AddFluxoCaixa;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using Moq;
using Xunit;

namespace FluxoCaixa.Tests
{
    public class AddFluxoCaixa
    {
        [Fact]
        public async Task CommandIsValid_Executed_Success()
        {
            // Arrange
            var fluxoRepository = new Mock<IFluxoCaixaRepository>();
            var fluxoCaixaCommand = new AddFluxoCaixaCommand("salario","Credito",3500);

            fluxoRepository.Setup(pr => pr.CreateMovto(It.IsAny<FluxoCaixaEntity>())).Verifiable();
            var returnExdpected = 1;

            var addFluxoCaixaCommandHandler = new AddFluxoCaixaCommandHandler(fluxoRepository.Object);

            // Act
            var fluxoCaixaResult = await  addFluxoCaixaCommandHandler.Handle(fluxoCaixaCommand, new CancellationToken());

            // Assert
            fluxoRepository.Verify(pr => pr.CreateMovto(It.IsAny<FluxoCaixaEntity>()), Times.Once);
            Assert.NotNull(fluxoCaixaResult);
            Assert.Equal(returnExdpected, fluxoCaixaResult);
        }

    }
}