using norm_calc.Data;
using norm_calc.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace norm_calc.Services
{
    public class CategoryServices
    {
        private readonly AppDbContext _context;

        public CategoryServices(AppDbContext context)
        {
            _context = context;
        }

        public List<GetCategoriesDto> GetAllCategories()
        {
            var categoriesFromDB = _context.Categories.Select(i => new GetCategoriesDto()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToList();

            return categoriesFromDB;

        }
    }
}
