using norm_calc.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace norm_calc.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<GetCategoriesDto>> GetAllCategories();
    }
}
