using DeloitteCoreWebAppMVC_NoAuth.BL;
using DeloitteCoreWebAppMVC_NoAuth.BL.Models;
using DeloitteCoreWebAppMVC_NoAuth.Helpers;
using DeloitteCoreWebAppMVC_NoAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace DeloitteCoreWebAppMVC_NoAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeBusinessService _homeBusinessService;

        public HomeController(ILogger<HomeController> logger, IHomeBusinessService homeBusinessService)
        {
            _logger = logger;
            _homeBusinessService = homeBusinessService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TasksList()
        {
            var tasksListViewModel = new TasksListViewModel();
            var tasks = _homeBusinessService.GetTasks(UserManager.UserTestId);
            tasksListViewModel.Tasks = tasks != null
                ? tasks.Select(t => new TodoTaskViewModel { Description = t.Description, Id = t.Id, IsChecked = t.IsChecked, LastUpdate = t.LastUpdate }).ToList()
                : new List<TodoTaskViewModel>();

            return View(tasksListViewModel);
        }

        [HttpPost]
        public void SaveTasks([FromBody] JsonElement data)
        {
            var tasks = data.EnumerateArray();

            var tasksList = new List<TodoTaskModel>();
            while (tasks.MoveNext())
            {
                var task = tasks.Current;

                string description = task.GetProperty("Description").GetString();
                bool isChecked = task.GetProperty("IsChecked").GetBoolean();
                int id = Int32.Parse(task.GetProperty("Id").GetString());
                tasksList.Add(new TodoTaskModel { Description = description, IsChecked = isChecked, Id = id, LastUpdate = DateTime.Now });
            }

            _homeBusinessService.SaveTasks(UserManager.UserTestId, tasksList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}