﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOListDomainModel.Classes;
using TODOListDomainModel.Context;
using TODOListDomainModel.Interfaces;

namespace TODOListDomainModel.Repositories
{
    /// <summary>
    /// Repository for <see cref="ToDoItem"/> object in database.
    /// </summary>
    public class ToDoItemRepository : IRepository<ToDoItem>
    {
        private readonly IApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToDoItemRepository"/> class.
        /// </summary>
        /// <param name="context"><see cref="IApplicationContext"/> object.</param>
        /// <exception cref="ArgumentNullException">Thrown if context is null.</exception>
        public ToDoItemRepository(IApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context), "Context must not be null.");
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Thrown if object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if there is no such <see cref="ToDoItem"/> in database.</exception>
        public void Delete(ToDoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "ToDoItem object must not be null.");
            }

            if (!this.context.Items.Contains(item))
            {
                throw new ArgumentException("There is no such ToDoItem in database.");
            }

            this.context.Items.Remove(item);
            this.context.SaveChanges();
        }

        /// <inheritdoc />
        public async Task<List<ToDoItem>> GetAll()
        {
            return await this.context.Items.Include(i => i.TodoList).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<ToDoItem> GetByID(int id)
        {
            return await this.context.Items.Include(i => i.TodoList).SingleOrDefaultAsync(i => i.Id == id);
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Thrown if object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if object has no assigned <see cref="ToDoList"/>,
        /// if <see cref="ToDoItem.ToDoListID"/> and <see cref="ToDoList.Id"/> does not match,
        /// if <see cref="ToDoItem"/> is assigned to non-existing <see cref="ToDoList"/>,
        /// if there is no such <see cref="ToDoItem"/> in database.</exception>
        public void Update(ToDoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "ToDoItem object must not be null.");
            }

            if (item.TodoList == null)
            {
                throw new ArgumentException("ToDoItem must have ToDoList object assigned.");
            }

            if (item.ToDoListID != item.TodoList.Id)
            {
                throw new ArgumentException("ToDoListId and ToDoList.Id does not match.");
            }

            if (!this.context.ToDoLists.Contains(item.TodoList))
            {
                throw new ArgumentException("ToDoItem is assigned to non-existing ToDoList.");
            }

            var entryFound = this.context.Items.SingleOrDefault(t => t.Id == item.Id);

            if (entryFound == null)
            {
                throw new ArgumentException("There is no such ToDoItem in database.");
            }

            entryFound.Title = item.Title;
            entryFound.Description = item.Description;
            entryFound.Deadline = item.Deadline;
            entryFound.Status = item.Status;
            entryFound.IsHidden = item.IsHidden;
            entryFound.Remind = item.Remind;
            entryFound.Starred = item.Starred;
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Thrown if object is null.</exception>
        /// <exception cref="ArgumentException">Thrown if object has no assigned <see cref="ToDoList"/>,
        /// if <see cref="ToDoItem.ToDoListID"/> and <see cref="ToDoList.Id"/> does not match,
        /// if <see cref="ToDoItem"/> is assigned to non-existing <see cref="ToDoList"/>,
        /// if there is no such <see cref="ToDoItem"/> in database.</exception>
        public Task<ToDoItem> Insert(ToDoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "ToDoItem object must not be null.");
            }

            if (item.TodoList == null)
            {
                throw new ArgumentException("ToDoItem must have ToDoList object assigned.");
            }

            if (item.ToDoListID != item.TodoList.Id)
            {
                throw new ArgumentException("ToDoListId and ToDoList.Id does not match.");
            }

            if (!this.context.ToDoLists.Contains(item.TodoList))
            {
                throw new ArgumentException("ToDoItem is assigned to non-existing ToDoList.");
            }

            if (this.context.Items.SingleOrDefault(e => e.Id == item.Id) != null)
            {
                throw new ArgumentException("ToDoItem is already in database.");
            }

            return this.InsertAsync(item);
        }

        /// <summary>
        /// Method for async inserting to database if <see cref="ToDoItemRepository.Insert(ToDoItem)"/> checks passed.
        /// </summary>
        /// <param name="item"><see cref="ToDoItem"/> to be inserted.</param>
        /// <returns>Task.</returns>
        private async Task<ToDoItem> InsertAsync(ToDoItem item)
        {
            await this.context.Items.AddAsync(item);
            this.context.SaveChanges();
            return item;
        }
    }
}
