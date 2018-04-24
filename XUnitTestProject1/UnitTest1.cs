using AlexaHelper.Request;
using Amazon.Lambda.Core;
using Moq;
using System;
using TestLambdaProject;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Mock<ILambdaLogger> logger = new Mock<ILambdaLogger>();
            logger.Setup(x => x.LogLine(It.IsAny<string>()));

            Mock<ILambdaContext> ctx = new Mock<ILambdaContext>();
            ctx.SetupGet(x => x.Logger).Returns(logger.Object);

            Request r = new Request()
            {
                Directive = new Directive()
                {
                    Header = new Header()
                    {
                        Namespace = "Alexa.Discovery",
                        Name = "Discover"
                    }
                }
            };

            Function f = new Function();
            f.FunctionHandler(r, ctx.Object);

            logger.Verify(x => x.LogLine(It.IsAny<string>()));
            logger.Verify(x => x.LogLine(It.Is<string>(y => y.Contains("{"))));
        }

        [Fact]
        public void Test2()
        {
            Request r = new Request();

            Assert.Contains("{", r.ToString());
        }

        [Fact]
        public void Test3()
        {
            Mock<ILambdaLogger> logger = new Mock<ILambdaLogger>();
            logger.Setup(x => x.LogLine(It.IsAny<string>()));

            Mock<ILambdaContext> ctx = new Mock<ILambdaContext>();
            ctx.SetupGet(x => x.Logger).Returns(logger.Object);

            Function f = new Function();
            var z = f.Discovery(ctx.Object);
            Assert.NotNull(z);
        }
    }
}
