using System.Collections.Generic;
using System.Threading.Tasks;
using iExpenseApi.Models;
using Microsoft.AspNetCore.Identity;

namespace iExpenseApi.Services
{
    public class CategoryService : ICategoryService
    {
        public int UserId { get; private set; }
        public CategoryService(UserManager<User> userManager)
        {
        }

        public Task<Category> CreateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> UpdateCategory(int id, Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
