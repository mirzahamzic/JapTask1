using norm_calc.Data;
using norm_calc.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace norm_calc.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoriesDto>> GetAllCategories()
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
