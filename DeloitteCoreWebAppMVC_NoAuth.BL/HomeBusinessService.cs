using DeloitteCoreWebAppMVC_NoAuth.BL.Models;
using DeloitteCoreWebAppMVC_NoAuth.CAL;
using DeloitteCoreWebAppMVC_NoAuth.CAL.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DeloitteCoreWebAppMVC_NoAuth.BL
{
    public class HomeBusinessService : IHomeBusinessService
    {
        private readonly IHomeDataService _homeDataService;
        private readonly ILogger<HomeBusinessService> _logger;

        public HomeBusinessService(ILogger<HomeBusinessService> logger, IHomeDataService homeDataService)
        {
            _homeDataService = homeDataService;
            _logger = logger;
        }

        public void AddTask(int id, string description, bool isChecked)
        {
            _homeDataService.AddTask(id, description, isChecked);
        }

        public void DeleteTask(int id)
        {
            _homeDataService.DeleteTask(id);
        }

        public List<TodoTaskModel> GetTasks(int userId)
        {
            List<TodoTask> tasks = _homeDataService.GetTasks(userId);
            if (tasks == null)
                return null;
            else
                return tasks.Select(t => new TodoTaskModel() { Description = t.Description, Id = t.Id, IsChecked = t.IsChecked, LastUpdate = t.LastUpdate })
                            .ToList();
        }

        public void SaveTasks(int userId, List<TodoTaskModel> tasks)
        {
            _homeDataService.SaveTasks(userId, tasks.Select(t => new TodoTask() { Description = t.Description, Id = t.Id, IsChecked = t.IsChecked, LastUpdate = t.LastUpdate }).ToList());
        }
    }
}