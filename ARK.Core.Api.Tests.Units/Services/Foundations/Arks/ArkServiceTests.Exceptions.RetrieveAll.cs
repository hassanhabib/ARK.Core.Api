// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using ARK.Core.Api.Models.ARKs.Exceptions;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Moq;

namespace ARK.Core.Api.Tests.Units.Services.Foundations.Arks
{
    public partial class ArkServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveIfDependencyFailureOccurredAndLogItAsync()
        {
            // given
            SqlException sqlException = CreateSqlException();

            var failedArkStorageException =
                new FailedArkStorageException(
                    message: "Failed Ark storage error occurred, contact support.",
                    innerException: sqlException);

            var expectedArkDependencyException =
                new ArkDependencyException(
                    message: "Ark dependency error occurred, contact support.",
                    innerException: failedArkStorageException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllArksAsync())
                    .ThrowsAsync(sqlException);

            // when
            ValueTask<IQueryable<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkDependencyException actualArkDependencyException =
                await Assert.ThrowsAsync<ArkDependencyException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkDependencyException.Should().BeEquivalentTo(
                expectedArkDependencyException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCriticalAsync(It.Is(
                    SameExceptionAs(expectedArkDependencyException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveIfServiceFailureOccurredAndLogItAsync()
        {
            // given
            var serviceException = new Exception();

            var failedArkServiceException =
                new FailedArkServiceException(
                    message: "Failed Ark service error occurred, contact support.",
                    innerException: serviceException);

            var expectedArkServiceException =
                new ArkServiceException(
                    message: "Ark service error occurred, contact support.",
                    innerException: failedArkServiceException);

            this.storageBrokerMock.Setup(broker =>
                broker.SelectAllArksAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<IQueryable<Ark>> retrieveAllArksTask =
                this.arkService.RetrieveAllArksAsync();

            ArkServiceException actualArkServiceException =
                await Assert.ThrowsAsync<ArkServiceException>(
                    retrieveAllArksTask.AsTask);

            // then
            actualArkServiceException.Should().BeEquivalentTo(
                expectedArkServiceException);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectAllArksAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCriticalAsync(It.Is(
                    SameExceptionAs(expectedArkServiceException))),
                        Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
