using ProductGrpc.Protos;

namespace ProductGrpc.Models;
public class Product 
{
  public int Id { get; set; }
  public string Title { get; set; }
  public int Price { get; set; }

  public ProductStatus Status { get; set; }

  public long CreateDate { get; set; }

  public Product()
  {
    CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
  }

  public Product(int id, string title, int price, ProductStatus status)
  {
    Id = id;
    Title = title;
    Price = price;
    Status = status;
    CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
  }
  public Product(ProductModel productModel)
  {
    Id = productModel.Id;
    Title = productModel.Title;
    Price = productModel.Price;
    Status = (ProductStatus)productModel.Status;
    CreateDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
  }


  public enum ProductStatus
  {
    Low =0,
    InStock=1,
    None =2
  }
}

