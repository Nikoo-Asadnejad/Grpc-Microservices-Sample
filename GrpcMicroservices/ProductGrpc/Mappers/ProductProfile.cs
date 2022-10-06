using AutoMapper;
using ProductGrpc.Models;
using ProductGrpc.Protos;

namespace ProductGrpc.Mappers
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      CreateMap<Product, ProductModel>().ReverseMap();
    }
  }
}
