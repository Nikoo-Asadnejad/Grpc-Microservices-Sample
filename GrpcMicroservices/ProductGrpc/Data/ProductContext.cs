using Microsoft.EntityFrameworkCore;
using ProductGrpc.Models;

namespace ProductGrpc.Data;
  public class ProductContext : DbContext
  {
     public DbSet<Product> Products { get; set; }

  public ProductContext(DbContextOptions<ProductContext> options) : base(options)
  {

  }
  }
 
