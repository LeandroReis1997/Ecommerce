using AutoMapper;
using Product.Web.Api.DTO.Product;
using Product.Web.Info;

namespace Product.Web.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Produto

            CreateMap<ProductDTO, ProductInfo>();

            CreateMap<ProductListDTO, ProductInfo>().ReverseMap();

            #endregion
        }
    }
}
