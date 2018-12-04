using iExpenseApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iExpenseApi.Services
{
    public interface ICategoryService
    {
        int UserId { get; }
        Task<Category> CreateCategory(Category category);
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetAllCategories();
        Task<Category> UpdateCategory(int id, Category category);
        Task<Category> DeleteCategory(int id);
    }
}
