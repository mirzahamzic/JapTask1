using AutoMapper;
using norm_calc.Dtos;
using norm_calc.Models;

namespace norm_calc
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<Ingredient, AddIngredientToRecipeDto>();
            CreateMap<AddRecipeDto, Recipe>();
        }
    }
}
