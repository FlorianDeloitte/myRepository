using DeloitteCoreWebAppMVC_NoAuth.CAL.Entities;
using DeloitteCoreWebAppMVC_NoAuth.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DeloitteCoreWebAppMVC_NoAuth.CAL
{
    public class HomeDataService : IHomeDataService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<HomeDataService> _logger;

        public HomeDataService(ILogger<HomeDataService> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public void GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAllTasks()
        {
        }

        public void AddTask(int id, string description, bool isChecked)
        {
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveTasks(int userId, List<TodoTask> tasks)
        {
            _cache.Set(userId.ToString(), tasks.ToByteArray());
        }

        public List<TodoTask> GetTasks(int userId)
        {
            byte[] serializedData = _cache.Get(userId.ToString());
            List<TodoTask> tasks = null;
            if (serializedData != null)
                tasks = serializedData.FromByteArray<List<TodoTask>>();

            return tasks;
        }
    }
}