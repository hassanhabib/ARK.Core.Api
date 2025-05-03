// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using ARK.Core.Api.Models.ARKs;

namespace ARK.Core.Api.Services.Foundations.Arks
{
    public interface IArkService
    {
        ValueTask<IQueryable<Ark>> RetrieveAllArksAsync();
    }
}
