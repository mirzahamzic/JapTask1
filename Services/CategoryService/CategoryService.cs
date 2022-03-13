using Microsoft.EntityFrameworkCore;
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
        public async Task<List<GetCategoriesDto>> GetAllCategories(int limit)
        {
            var categoriesFromDB = await _context.Categories.Select(i => new GetCategoriesDto()
            {
                Id = i.Id,
                Name = i.Name,
            }).OrderBy(c => c.Name).Skip(limit).Take(4).ToListAsync();

            return categoriesFromDB;

        }

        public async Task<List<GetCategoriesDto>> GetAllCategories()
        {
            var categoriesFromDB = await _context.Categories.Select(i => new GetCategoriesDto()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToListAsync();

            return categoriesFromDB;
        }
    }
}
