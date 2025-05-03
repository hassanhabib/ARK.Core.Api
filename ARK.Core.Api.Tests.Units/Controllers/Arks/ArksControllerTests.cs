// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using ARK.Core.Api.Controllers;
using ARK.Core.Api.Models.ARKs;
using ARK.Core.Api.Models.ARKs.Exceptions;
using ARK.Core.Api.Services.Foundations.Arks;
using Moq;
using RESTFulSense.Controllers;
using Tynamix.ObjectFiller;
using Xeptions;

namespace ARK.Core.Api.Tests.Units.Controllers.Arks
{
    public partial class ArksControllerTests : RESTFulController
    {
        private readonly Mock<IArkService> arkServiceMock;
        private readonly ArksController arksController;

        public ArksControllerTests()
        {
            this.arkServiceMock =
                new Mock<IArkService>();

            this.arksController =
                new ArksController(
                    arkService: this.arkServiceMock.Object);
        }

        private IQueryable<Ark> CreateRandomArks()
        {
            return CreateArkFiller().Create(count: GetRandomNumber())
                .AsQueryable();
        }

        public static TheoryData<Xeption> ServerException()
        {
            string someMessage = GetRandomMessage();
            var someInnerException = new Xeption(someMessage);

            return new TheoryData<Xeption>
            {
                new ArkDependencyException(
                    message: someMessage,
                    innerException: someInnerException),

                new ArkServiceException(
                    message: someMessage,
                    innerException: someInnerException)
            };
        }
        private static string GetRandomMessage() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private Filler<Ark> CreateArkFiller()
        {
            var filler = new Filler<Ark>();

            filler.Setup()
                .OnType<DateTimeOffset>().IgnoreIt();

            return filler;
        }
    }
}
