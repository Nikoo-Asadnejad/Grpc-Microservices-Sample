using Microsoft.EntityFrameworkCore;
using ProductGrpc.Data;
using ProductGrpc.Interfaces;
using ProductGrpc.Models;
using System.ComponentModel;

namespace ProductGrpc.Services;
public class ProductRepository : IProductRepository
{
  private readonly ProductContext _context;
  public ProductRepository(ProductContext context)
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

  public async Task<List<Product>> GetAllAsync()
    => await _context.Products.ToListAsync();

}

