using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Repository.Interfaces;
using TodoAPI.Services.Interfaces;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoService.GetAll();
            if (todos == null) return BadRequest();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _todoService.GetById(id));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            if (todo == null) return BadRequest();
            await _todoService.Create(todo);
            return Ok(todo);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Todo todo)
        {
            if (todo == null) return BadRequest();
            await _todoService.Update(todo);
            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> GDeleteet(int id)
        {
            await _todoService.Delete(id);
            return Ok("Deletado com sucesso");

        }
    }
}
