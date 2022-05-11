using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<bool> Create(Todo todo)
        {
            try
            {
                _todoContext.Todos.Add(todo);
                await _todoContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                var TodoId = await _todoContext.Todos.FindAsync(Id);
                _todoContext.Todos.Remove(TodoId);
                await _todoContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                return await _todoContext.Todos.ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Todo> GetById(int Id)
        {
            try
            {
                return await _todoContext.Todos.FindAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(Todo todo)
        {
            try
            {
                _todoContext.Entry(todo).State = EntityState.Modified;
                await _todoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
