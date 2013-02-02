using System.Web.Http;
using WebApiTesting.Controllers.Filters;
using WebApiTesting.Infrastructure;

namespace WebApiTesting.Controllers
{
    [DontExposeExceptions]
    public class PingController : ApiController
    {
        private readonly IPingRepository _pingRepository;
        private readonly IDateTimeProvider _dateTimeProvider;

        public PingController(IPingRepository pingRepository, IDateTimeProvider dateTimeProvider)
        {
            _pingRepository = pingRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public TimestampResponse Get()
        {
            _pingRepository.CheckDatabase();

            return new TimestampResponse(_dateTimeProvider);
        }
    }

    public class TimestampResponse
    {
        public TimestampResponse(IDateTimeProvider dateTimeProvider)
        {
            Timestamp = dateTimeProvider.Now().ToUniversalTime().DateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string Timestamp { get; private set; }
    }
}