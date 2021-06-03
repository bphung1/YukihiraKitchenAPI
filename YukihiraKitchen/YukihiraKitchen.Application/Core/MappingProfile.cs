using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Application.DTOs;
using YukihiraKitchen.Application.Recipes;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, Recipe>();
            CreateMap<Recipe, RecipeDto>()
                .ForMember(d => d.RecipeIngredients, o => o.MapFrom(s => s.RecipeIngredients));

            CreateMap<RecipeIngredient, RecipeIngredientDto>()
                .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.IngredientName))
                .ForMember(d => d.Measurement, o => o.MapFrom(s => s.IngredientMeasurement))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.IngredientQuantity));
        }
    }
}
