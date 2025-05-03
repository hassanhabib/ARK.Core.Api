// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using Force.DeepCloner;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RESTFulSense.Clients.Extensions;

namespace ARK.Core.Api.Tests.Units.Controllers.Arks
{
    public partial class ArksControllerTests
    {
        [Fact]
        public async Task ShouldReturnOKWithAllArksAsync()
        {
            // given
            IQueryable<Ark> randomArks =
                CreateRandomArks();

            IQueryable<Ark> retrievedArks =
                randomArks;

            IQueryable<Ark> expectedArks =
                retrievedArks.DeepClone();

            OkObjectResult expectedObjectResult =
                Ok(expectedArks);

            this.arkServiceMock.Setup(service =>
                service.RetrieveAllArksAsync())
                    .ReturnsAsync(retrievedArks);

            // when
            ActionResult<IQueryable<Ark>> actualActionResult =
                await this.arksController.GetAllArksAsync();

            // then
            actualActionResult.ShouldBeEquivalentTo(
                expectedObjectResult);

            this.arkServiceMock.Verify(service =>
                service.RetrieveAllArksAsync(),
                    Times.Once);

            this.arkServiceMock.VerifyNoOtherCalls();
        }
    }
}
