using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Ingredients;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Ingredient
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientEditDto, Ingredient>();
        }
    }
}
