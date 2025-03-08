using AutoMapper;
using Data.Entities;
using DTO;

namespace BAL.AutoMapper
{
    public class MyMapperProfile :Profile
    {
        
        public MyMapperProfile()
        {

            CreateMap<Category, CategoryModel>().ReverseMap();
        
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
