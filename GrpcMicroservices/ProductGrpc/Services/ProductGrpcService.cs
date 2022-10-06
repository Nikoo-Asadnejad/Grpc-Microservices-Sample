using Grpc.Core;
using ProductGrpc.Interfaces;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Services;
public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
{
  private readonly IProductRepository _productRepository;
  public ProductGrpcService(IProductRepository productRepository)
  {
    _productRepository = productRepository;
  }
  public override async Task<AddProductResponse> AddAsync(ProductModel request, ServerCallContext context)
  {
    bool isSuccessful = await _productRepository.AddAsync(new Product(request));
    AddProductResponse addProductResponse = new() { Result = isSuccessful };
    return addProductResponse;

  }
  
  public override async Task<ProductModel> GetAsync(GetProductRequest request, ServerCallContext context)
  {
    var result =await _productRepository.GetAsync(request.Id);
    ProductModel productModel = new()
    {
      Id = result.Id,
      Price = result.Price,
      Status = (ProductStatus)result.Status,
      Title = result.Title
    };

    return productModel;
  }
  public override async Task GetAllAsync(GetAllProductsRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
  {
    var result = await _productRepository.GetAll();

    List<ProductModel> productModels = new();
    productModels.AddRange(result.Select(x=> new ProductModel
    {
      Id=x.Id,
      Price=x.Price,
      Status = (ProductStatus)x.Status,
      Title = x.Title

    }));

  }


}

