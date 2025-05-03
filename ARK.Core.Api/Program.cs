// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

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
