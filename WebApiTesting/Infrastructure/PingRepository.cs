namespace WebApiTesting.Infrastructure
{
    public interface IPingRepository
    {
        void CheckDatabase();
    }

    public class PingRepository : IPingRepository
    {
        public void CheckDatabase()
        {
            // todo: Check the database is up and running
        }
    }
}