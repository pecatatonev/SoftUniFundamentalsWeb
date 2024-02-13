using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _data;

        public HomeController(ApplicationDbContext context)
        {
            _data = context;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = await _data.Boards
                .Select(b => b.Name)
                .Distinct()
                .ToListAsync();

            var tasksCounts = new List<HomeBoardModel>();
            foreach (var boardName in taskBoards) 
            {
                var tasksInBoard = _data.Tasks.Where(t => t.Board.Name == boardName).Count();
                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TaskCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated) 
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = _data.Tasks.Count(),
                BoardsWithTaskCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }

    }
}