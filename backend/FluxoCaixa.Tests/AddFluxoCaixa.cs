
using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using Moq;
using Xunit;

namespace FluxoCaixa.Tests
{
    public class AddFluxoCaixa
    {
        [Fact]
        public async Task Meu_Primeiro_Teste()
        {
            // Arrange
            var fluxoCaixaMock = new Mock<IFluxoCaixaRepository>();
            var fluxoCaixaCommand = new MovtoFluxoCaixa()
            {
                descricao = "teste",
                tp_movimento = "Credito",
                vl_movimento = 3500
            };

            fluxoCaixaMock.Setup(pr => pr.CreateMovto(It.IsAny<FluxoCaixaEntity>())).Verifiable();
            // var FluxoCaixaRepository = new FluxoCaixaRepository(fluxoCaixaMock.Object);

            // Act

            // Assert
        }

    }
}