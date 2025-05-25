// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;

namespace ARK.Core.Api.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        ValueTask<Ark> InsertArkAsync(Ark ark);
        ValueTask<IQueryable<Ark>> SelectAllArksAsync();
    }
}
