using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
    public class TodoItemEF : ITodoItemDAO
    {
        private readonly TodoContext _context;
        public TodoItemEF(TodoContext context)
        {
            _context = context;
        }

        //Listar todos os produtos do banco:
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> ListaTodoItems()
        {
            return await _context.TodoItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        public async Task<ActionResult<TodoItemDTO>> ListaTodoItemsId(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }
            return ItemToDTO(todoItem);
        }

        public async Task<IActionResult> TodoItemUpdate(long id, TodoItemDTO todoItemDTO)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return null;
            }
            return null;
        }
        public async Task<ActionResult<TodoItemDTO>> Create(TodoItemDTO todoItemDTO)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDTO.IsComplete,
                Name = todoItemDTO.Name
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return ItemToDTO(todoItem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return null;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return null;
        }

        // ----------------------------------------------------------------------------
         
        //TodoItemExists verifica se o item com aquele id existe no banco.
        private bool TodoItemExists(long id) =>
             _context.TodoItems.Any(e => e.Id == id);

        //Converte um TodoItem em um TodoItemDTO.
        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }    
}
