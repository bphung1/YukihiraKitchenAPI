using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Recipes;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, Recipe>();
            //CreateMap<Recipe, RecipeDto>()
            //    .ForMember(d => d.Id)
        }
    }
}
