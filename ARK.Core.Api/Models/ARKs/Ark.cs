// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;

namespace ARK.Core.Api.Models.ARKs
{
    public class Ark
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Act { get; set; }
    }
}
