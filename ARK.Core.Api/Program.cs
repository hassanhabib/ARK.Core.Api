// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using ARK.Core.Api.Brokers.Loggings;
using ARK.Core.Api.Brokers.Storages;
using ARK.Core.Api.Services.Foundations.Arks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ARK.Core.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder webApplicationBuilder =
                WebApplication.CreateBuilder(args);

            webApplicationBuilder.Services.AddControllers();
            webApplicationBuilder.Services.AddOpenApi();
            webApplicationBuilder.Services.AddLogging();
            webApplicationBuilder.Services.AddDbContext<StorageBroker>();

            webApplicationBuilder.Services.AddTransient<
                ILoggingBroker,
                LoggingBroker>();

            webApplicationBuilder.Services.AddTransient<
                IStorageBroker,
                StorageBroker>();

            webApplicationBuilder.Services.AddTransient<
                IArkService,
                ArkService>();

            WebApplication webApplication =
                webApplicationBuilder.Build();

            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.MapOpenApi();
            }

            webApplication.UseHttpsRedirection();
            webApplication.UseAuthorization();
            webApplication.MapControllers();
            webApplication.Run();
        }
    }
}