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

  public enum ProductStatus
  {
    Low =1,
    InStock=2,
    None =3
  }
}

