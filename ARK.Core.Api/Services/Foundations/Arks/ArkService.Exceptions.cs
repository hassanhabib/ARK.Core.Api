// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Brokers.Loggings;
using ARK.Core.Api.Brokers.Storages;
using ARK.Core.Api.Models.ARKs;
using Microsoft.Data.SqlClient;

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
                await returningArksFunction();
            }
            catch (SqlException sqlException)
            {
                throw sqlException;
            }

            return null;
        }
    }
}
