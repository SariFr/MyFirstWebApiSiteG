using AutoMapper;
using DTO;
using Entity;

namespace MyFirstWebApiSite
{
    public class Mapper:Profile
    {
        protected Mapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

        }


    }
}
