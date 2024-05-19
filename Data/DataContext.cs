using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


    }
}
