using Microsoft.EntityFrameworkCore;

namespace odata
{
  public class Product
  {
    public int ProductID
    {
      get;
      set;
    }

    public string ProductName
    {
      get;
      set;
    }
  }

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
