using AutoMapper;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutluGunlerFirini.WebAPI.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();
            CreateMap<Menu, MenuAllDto>();
            CreateMap<MenuAllDto, Menu>();
        }
    }
}