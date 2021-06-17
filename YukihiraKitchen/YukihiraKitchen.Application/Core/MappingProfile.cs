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
            CreateMap<Recipe, Recipe>()
                .ForMember(d => d.RecipeIngredients, o => o.MapFrom(s => s.RecipeIngredients))
                .ForMember(d => d.Photo, o => o.MapFrom(s => s.Photo));
            CreateMap<Recipe, RecipeDto>()
                .ForMember(d => d.RecipeIngredients, o => o.MapFrom(s => s.RecipeIngredients))
                .ForMember(d => d.Photo, o => o.MapFrom(s => s.Photo.Url))
                .ForMember(d => d.Directions, o => o.MapFrom(s => s.Directions));

            CreateMap<RecipeIngredient, RecipeIngredientDto>()
                .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.IngredientName))
                .ForMember(d => d.Measurement, o => o.MapFrom(s => s.IngredientMeasurement))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.IngredientQuantity));

            CreateMap<Direction, DirectionDto>()
                .ForMember(d => d.CookingDirection, o => o.MapFrom(s => s.CookingDirection))
                .ForMember(d => d.CookingStepNumber, o => o.MapFrom(s => s.CookingStepNumber))
                .ForMember(d => d.DirectionId, o => o.MapFrom(s => s.DirectionId));
        }
    }
}
