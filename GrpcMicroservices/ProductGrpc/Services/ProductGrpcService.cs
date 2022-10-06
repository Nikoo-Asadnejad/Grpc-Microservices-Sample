using AutoMapper;
using Grpc.Core;
using ProductGrpc.Interfaces;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Services;
public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
{
  private readonly IProductRepository _productRepository;
  private readonly IMapper _mapper;
  public ProductGrpcService(IProductRepository productRepository, IMapper mapper)
  {
    _productRepository = productRepository;
    _mapper = mapper;
  }
  public override async Task<AddProductResponse> AddAsync(ProductModel request, ServerCallContext context)
  {
    bool isSuccessful = await _productRepository.AddAsync(_mapper.Map<Product>(request));
    AddProductResponse addProductResponse = new() { Result = isSuccessful };
    return addProductResponse;

  }
  
  public override async Task<ProductModel> GetAsync(GetProductRequest request, ServerCallContext context)
  {
    var result =await _productRepository.GetAsync(request.Id);
    ProductModel productModel = _mapper.Map<ProductModel>(result);
    return productModel;
  }
  public override async Task GetAllAsync(GetAllProductsRequest request, IServerStreamWriter<ProductModel> responseStream, ServerCallContext context)
  {
    var result = await _productRepository.GetAllAsync();

    List<ProductModel> productModels = new();

    productModels.ForEach(async x => await responseStream.WriteAsync(_mapper.Map<ProductModel>(x)));

  }


}

