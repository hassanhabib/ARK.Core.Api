// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace ARK.Core.Api.Brokers.DateTimes
{
    internal class DateTimeBroker : IDateTimeBroker
    {
        public async ValueTask<DateTimeOffset> GetCurrentDateTimeOffsetAsync() =>
            DateTimeOffset.UtcNow;
    }
}
