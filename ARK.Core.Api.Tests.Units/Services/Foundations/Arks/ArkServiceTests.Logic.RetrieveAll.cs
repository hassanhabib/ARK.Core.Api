// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace ARK.Core.Api.Tests.Units.Services.Foundations.Arks
{
    public partial class ArkServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllArksAsync()
        {
            // given
            IQueryable<Ark> randomArks =
                CreateRandomArks();

            IQueryable<Ark> selectedArks =
                randomArks;

            IQueryable<Ark> expectedArks =
                randomArks.DeepClone();

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllArksAsync())
                    .ReturnsAsync(selectedArks);

            // when
            IQueryable<Ark> actualArks =
                await this.arkService.RetrieveAllArksAsync();

            // then
            actualArks.Should().BeEquivalentTo(expectedArks);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllArksAsync(),
                    Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
