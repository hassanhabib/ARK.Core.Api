// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using Microsoft.EntityFrameworkCore;

namespace ARK.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Ark> Arks { get; set; }

        public async ValueTask<IQueryable<Ark>> SelectAllArksAsync() =>
            await this.SelectAll<Ark>();
    }
}
