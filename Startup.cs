using bookstore.Database;
using Microsoft.EntityFrameworkCore;

namespace bookstore
{
    public class Startup
    {
        public static void InitializeDB(IServiceProvider serviceProvider, BookstoreDbContext context)
        {
            context.Database.Migrate();  // Apply migrations
        }
    }
}
