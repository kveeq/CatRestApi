using System;
using System.Collections.Generic;
using CatRestApi.Model;
using System.Text;
using System.Threading.Tasks;

namespace CatRestApi.Services
{
    public class TodoManager
    {
        IRestService service;

        public TodoManager(IRestService restService)
        {
            service = restService;
        }
        public Task<List<Cat>> GetTodoItemModels()
        {
            return service.GetTodoItemAsync();
        }

        public Task DeleteTodoAsync(Cat item)
        {
            return service.DeleteTodoItemAsync(item);
        }
        public Task SaveItemAsync(Cat todoItem, bool isNewItem = false)
        {
            return service.SaveTodoItemAsync(todoItem, isNewItem);
        }
    }
}
