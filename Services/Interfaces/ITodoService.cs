using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<Todo> GetById(int Id);
        Task Create(Todo todo);
        Task Update(Todo todo);
        Task Delete(int Id);
    }
}
