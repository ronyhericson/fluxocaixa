
using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.RemoveFluxoCaixa;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using Moq;
using Xunit;

namespace FluxoCaixa.Tests
{
    public class RemoveFluxoCaixa
    {
        [Fact]
        public async Task CommandRemoveIsValid_Executed_Success()
        {
            // Arrange
            var fluxoRepository = new Mock<IFluxoCaixaRepository>();
            var fluxoCaixaCommand = new RemoveFluxoCaixaCommand(4);

            fluxoRepository.Setup(pr => pr.CreateMovto(It.IsAny<FluxoCaixaEntity>())).Verifiable();
            var returnExdpected = 1;

            var removeFluxoCaixaCommandHandler = new RemoveFluxoCaixaCommandHandler(fluxoRepository.Object);

            // Act
            var fluxoCaixaResult = await  removeFluxoCaixaCommandHandler.Handle(fluxoCaixaCommand, new CancellationToken());

            // Assert
            fluxoRepository.Verify(pr => pr.CreateMovto(It.IsAny<FluxoCaixaEntity>()), Times.Once);
            Assert.NotNull(fluxoCaixaResult);
            Assert.Equal(returnExdpected, fluxoCaixaResult);
        }

    }
}