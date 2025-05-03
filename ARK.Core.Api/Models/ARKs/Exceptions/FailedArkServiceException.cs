// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace ARK.Core.Api.Models.ARKs.Exceptions
{
    public class FailedArkServiceException : Xeption
    {
        public FailedArkServiceException(string message, Exception innerException)
             : base(message, innerException) { }
    }
}
