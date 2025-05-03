// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;
using ARK.Core.Api.Services.Foundations.Arks;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace ARK.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArksController : RESTFulController
    {
        private readonly IArkService arkService;

        public ArksController(IArkService arkService) =>
            this.arkService = arkService;

        [HttpGet]
        public async ValueTask<ActionResult<IQueryable<Ark>>> GetAllArksAsync()
        {
            IQueryable<Ark> retrievedArks =
                await this.arkService.RetrieveAllArksAsync();

            return Ok(retrievedArks);
        }
    }
}
