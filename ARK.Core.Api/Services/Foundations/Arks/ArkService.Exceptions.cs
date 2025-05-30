﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using ARK.Core.Api.Models.ARKs.Exceptions;
using Microsoft.Data.SqlClient;
using Xeptions;

namespace ARK.Core.Api.Services.Foundations.Arks
{
    internal partial class ArkService : IArkService
    {
        private delegate ValueTask<IQueryable<Ark>> ReturningArksFunction();

        private async ValueTask<IQueryable<Ark>> TryCatch(
            ReturningArksFunction returningArksFunction)
        {
            try
            {
                return await returningArksFunction();
            }
            catch (SqlException sqlException)
            {
                var failedArkStorageException =
                    new FailedArkStorageException(
                        message: "Failed Ark storage error occurred, contact support.",
                        sqlException);

                throw await CreateAndLogDependencyExceptionAsync(
                    failedArkStorageException);
            }
            catch (Exception exception)
            {
                var failedArkServiceException =
                    new FailedArkServiceException(
                        message: "Failed Ark service error occurred, contact support.",
                        exception);

                throw await CreateAndLogServiceExceptionAsync(
                    failedArkServiceException);
            }; ;
        }

        private async ValueTask<ArkDependencyException> CreateAndLogDependencyExceptionAsync(
            Xeption exception)
        {
            var arkDependencyException =
                new ArkDependencyException(
                    "Ark dependency error occurred, contact support.",
                    exception);

            await this.loggingBroker.LogCriticalAsync(
                arkDependencyException);

            return arkDependencyException;
        }

        private async ValueTask<ArkServiceException> CreateAndLogServiceExceptionAsync(
            Xeption exception)
        {
            var arkServiceException =
                new ArkServiceException(
                    "Ark service error occurred, contact support.",
                    exception);

            await this.loggingBroker.LogErrorAsync(
                arkServiceException);

            return arkServiceException;
        }
    }
}
