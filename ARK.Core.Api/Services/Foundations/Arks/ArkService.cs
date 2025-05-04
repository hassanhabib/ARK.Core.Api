// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Brokers.Loggings;
using ARK.Core.Api.Brokers.Storages;
using ARK.Core.Api.Models.ARKs;

namespace ARK.Core.Api.Services.Foundations.Arks
{
    internal partial class ArkService : IArkService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public ArkService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<IQueryable<Ark>> RetrieveAllArksAsync() => 
        TryCatch(async () =>
        {
            return await this.storageBroker.SelectAllArksAsync();
        });
    }
}