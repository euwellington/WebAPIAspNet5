using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repository.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<Todo> GetById(int Id);
        Task<bool> Create(Todo todo);
        Task<bool> Update(Todo todo);
        Task<bool> Delete(int Id);
    }
}
