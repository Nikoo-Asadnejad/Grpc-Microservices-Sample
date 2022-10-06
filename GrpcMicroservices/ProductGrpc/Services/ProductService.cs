using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Models;
using System.ComponentModel;

namespace ProductGrpc.Services;
public class ProductService
{
  private readonly ProductContext _context;
  public ProductService(ProductContext context)
  {
    _context = context;
  }

  public async Task<bool> AddAsync(Product product)
  {
    try
    {
      await _context.AddAsync(product);
      await _context.SaveChangesAsync();

      return true;
    }
    catch (Exception ex)
    {
      return false;
    }

  }

  public async Task<Product> GetAsync(int id)
  => await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

  public async Task<List<Product>> GetAll()
    => await _context.Products.ToListAsync();

}

