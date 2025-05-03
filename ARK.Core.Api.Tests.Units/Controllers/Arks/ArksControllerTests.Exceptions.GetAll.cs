// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RESTFulSense.Clients.Extensions;
using RESTFulSense.Models;
using Xeptions;

namespace ARK.Core.Api.Tests.Units.Controllers.Arks
{
    public partial class ArksControllerTests
    {
        [Theory]
        [MemberData(nameof(ServerException))]
        public async Task ShouldReturnInternalServerErrorOnExceptionAsync(
            Xeption serverException)
        {
            // given
            InternalServerErrorObjectResult expectedObjectResult =
                InternalServerError(serverException);

            this.arkServiceMock.Setup(service =>
                service.RetrieveAllArksAsync())
                    .ThrowsAsync(serverException);

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
