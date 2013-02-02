using System;
using System.Net;
using Autofac;
using NSubstitute;
using NUnit.Framework;
using WebApiTesting.Infrastructure;
using WebApiTesting.Tests.TestHelpers;

namespace WebApiTesting.Tests.Controllers
{
    internal class PingControllerTests : WebApiTestBase
    {
        private IDateTimeProvider _dateTimeProvider;
        private IPingRepository _pingRepository;

        [SetUp]
        public override void Setup()
        {
            ContainerBuilder = new ContainerBuilder();
            _dateTimeProvider = Substitute.For<IDateTimeProvider>();
            _pingRepository = Substitute.For<IPingRepository>();
            ContainerBuilder.Register(c => _dateTimeProvider);
            ContainerBuilder.Register(c => _pingRepository);
            base.Setup();
        }

        [Test]
        public void GivenTheDatabaseIsUpAndRunning_WhenGetToPing_ReturnCurrentTimestampAnd200Ok()
        {
            _dateTimeProvider.Now().Returns(new DateTimeOffset(new DateTime(2012, 11, 4, 12, 20, 6), TimeSpan.Zero));

            var response = PerformGetTo("api/ping");

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo(@"{""Timestamp"":""2012-11-04 12:20:06""}"));
        }

        [Test]
        public void GivenTheDatabaseIsNotRunning_WhenGetToPing_Return500ErrorWithNoContent()
        {
            _pingRepository.When(r => r.CheckDatabase()).Do(a => { throw new Exception(); });

            var response = PerformGetTo("api/ping");

            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.Content, Is.EqualTo(string.Empty));
        }
    }
}
