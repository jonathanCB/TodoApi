using Entities.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using PL.Context;
using PL.DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class BusinesFacade
    {
        private readonly ITodoItemDAO dao;
        public BusinesFacade(ITodoItemDAO todoEF)
        {
            this.dao = todoEF;
        }

        //Todos os produtos do banco:
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> ListaTodoItems()
        {
            return await dao.ListaTodoItems();
        }

        public async Task<ActionResult<TodoItemDTO>> ListaTodoItemsId(long id)
        {
            return await dao.ListaTodoItemsId(id);
        }

        public async Task<IActionResult> TodoItemUpdate(long id, TodoItemDTO todoItemDTO)
        {
            return await dao.TodoItemUpdate(id, todoItemDTO);
        }
        public async Task<ActionResult<TodoItemDTO>> Create(TodoItemDTO todoItemDTO)
        {
            return await dao.Create(todoItemDTO);
        }
        public async Task<IActionResult> Delete(long id)
        {
            return await dao.Delete(id);
        }
    }
}
