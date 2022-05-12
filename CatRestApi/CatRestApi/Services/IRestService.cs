using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CatRestApi.Model;

namespace CatRestApi.Services
{
    public interface IRestService
    {
        Task<List<Cat>> GetTodoItemAsync();
        Task SaveTodoItemAsync(Cat item, bool isNewItem);
        Task DeleteTodoItemAsync(Cat item);
    }
}
