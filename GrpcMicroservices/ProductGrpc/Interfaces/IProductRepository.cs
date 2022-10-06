using ProductGrpc.Models;

namespace ProductGrpc.Interfaces;
public interface IProductRepository
{
  Task<bool> AddAsync(Product product);
  Task<Product> GetAsync(int id);
  Task<List<Product>> GetAllAsync();
}

