using Microsoft.EntityFrameworkCore;

namespace Sample
{
  public class NorthwindContext : DbContext
  {
    public NorthwindContext(DbContextOptions<NorthwindContext> options):base(options)
    {
    }

    public NorthwindContext()
    {
    }

    public DbSet<Product> Products
    {
      get;
      set;
    }
  }
}
