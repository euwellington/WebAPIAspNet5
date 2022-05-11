using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Repository.Interfaces;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task Create(Todo todo)
        {
            await _todoRepository.Create(todo);
        }

        public async Task Delete(int Id)
        {
            await _todoRepository.Delete(Id);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
           return await _todoRepository.GetAll();
        }

        public async Task<Todo> GetById(int Id)
        {
            return await _todoRepository.GetById(Id);
        }

        public async Task Update(Todo todo)
        {
            await _todoRepository.Update(todo);
        }
    }
}
