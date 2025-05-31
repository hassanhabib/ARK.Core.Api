// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using Microsoft.EntityFrameworkCore;

namespace ARK.Core.Api.Brokers.Storages
{
    internal partial class StorageBroker
    {
        public DbSet<Ark> Arks { get; set; }

        public async ValueTask<Ark> InsertArkAsync(Ark ark) =>
            await InsertAsync(ark);

        public async ValueTask<IQueryable<Ark>> SelectAllArksAsync() =>
            await SelectAll<Ark>();
    }
}
