using LiteDB;
using ScheduledErrands.Models;

namespace ScheduledErrands.Services
{
    public class LiteDbService
    {
        private readonly LiteDatabase _database;

        public LiteDbService()
        {
            _database = new LiteDatabase("Filename=ScheduledJobs.db; Connection=shared");
        }

        public ILiteCollection<Job> ScheduledJobs => _database.GetCollection<Job>("jobs");

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
