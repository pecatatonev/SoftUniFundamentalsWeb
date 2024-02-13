﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _data;

        public TaskController(ApplicationDbContext context)
        {
            _data = context;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
                Boards = await GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel) 
        {
            if (!(await GetBoards()).Any(b => b.Id == taskModel.BoardId)) 
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), DataConstants.ErrorMessages.BoardDoesntExist);
            }

            string currentUserId = GetUserId();


            if (!ModelState.IsValid) 
            {
                taskModel.Boards = await GetBoards();
                return View(taskModel);
            }

            var task = new Data.Models.Task()
            {
                Title = taskModel.Title,
                BoardId = taskModel.BoardId,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                OwnerId = currentUserId
            };

            await _data.Tasks.AddAsync(task);
            await _data.SaveChangesAsync();
            
            var boards = _data.Boards;

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            var task = await _data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel() 
                {
                   CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                   Description = t.Description,
                   Id = t.Id,
                   Board = t.Board.Name,
                   Owner = t.Owner.UserName,
                   Title = t.Title,
                })
                .FirstOrDefaultAsync();

            if (task == null) 
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null) 
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId) 
            {
                return Unauthorized();
            }

            TaskFormModel model = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetBoards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskFormModel model, int id) 
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!(await GetBoards()).Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), DataConstants.ErrorMessages.BoardDoesntExist);
            }

            if (!ModelState.IsValid)
            {
                model.Boards = await GetBoards();
                return View(model);
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel model = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel model)
        {
            var task = await _data.Tasks.FindAsync(model.Id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            _data.Tasks.Remove(task);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }
        private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private async Task<IEnumerable<TaskBoardModel>> GetBoards() {
            return await _data.Boards
               .Select(x => new TaskBoardModel()
               {
                   Id = x.Id,
                   Name = x.Name,
               })
           .ToListAsync();
        }
    }
}
