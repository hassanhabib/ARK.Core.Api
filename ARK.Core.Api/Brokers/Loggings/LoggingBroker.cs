﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ARK.Core.Api.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger) =>
            this.logger = logger;

        public async ValueTask LogInformationAsync(string message) =>
           this.logger.LogInformation(message);

        public async ValueTask LogTraceAsync(string message) =>
            this.logger.LogTrace(message);

        public async ValueTask LogDebugAsync(string message) =>
            this.logger.LogDebug(message);

        public async ValueTask LogWarningAsync(string message) =>
            this.logger.LogWarning(message);

        public async ValueTask LogErrorAsync(Exception exception) =>
            this.logger.LogError(exception.Message, exception);

        public async ValueTask LogCriticalAsync(Exception exception) =>
            this.logger.LogCritical(exception.Message, exception);
    }
}
