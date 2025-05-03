// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace ARK.Core.Api.Models.ARKs.Exceptions
{
    public class FailedArkStorageException : Xeption
    {
        public FailedArkStorageException(string message, Exception innerException)
             : base(message, innerException)
        { }
    }
}
