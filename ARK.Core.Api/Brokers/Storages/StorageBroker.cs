// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ARK.Core.Api.Brokers.Storages
{
    internal partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(
                    name: "DefaultConnection");

            dbContextOptionsBuilder.UseSqlServer(
                connectionString);
        }

        private async ValueTask<IQueryable<T>> SelectAll<T>() where T : class =>
            this.Set<T>();
    }
}
