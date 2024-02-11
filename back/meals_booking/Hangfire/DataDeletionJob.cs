using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace API.Hangfire
{
    public class DataDeletionJob
    {
        private readonly StoreContext _storeContext;

        public DataDeletionJob(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void Execute()
        {
            _storeContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [MealsBooking]");
        }
    }
}