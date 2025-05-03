// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace ARK.Core.Api.Models.ARKs.Exceptions
{
    public class ArkServiceException : Xeption
    {
        public ArkServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
