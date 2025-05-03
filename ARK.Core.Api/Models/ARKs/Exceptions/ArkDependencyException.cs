// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace ARK.Core.Api.Models.ARKs.Exceptions
{
    public class ArkDependencyException : Xeption
    {
        public ArkDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
