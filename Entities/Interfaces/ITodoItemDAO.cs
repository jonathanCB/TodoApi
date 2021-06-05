using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ITodoItemDAO
    {
        public Task<ActionResult<IEnumerable<TodoItemDTO>>> ListaTodoItems();
        public Task<ActionResult<TodoItemDTO>> ListaTodoItemsId(long id);
        public Task<IActionResult> TodoItemUpdate(long id, TodoItemDTO todoItemDTO);
        public Task<ActionResult<TodoItemDTO>> Create(TodoItemDTO todoItemDTO);
        public Task<IActionResult> Delete(long id);
    }
}
