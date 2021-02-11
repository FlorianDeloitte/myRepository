using DeloitteCoreWebAppMVC_NoAuth.CAL.Entities;
using System.Collections.Generic;

namespace DeloitteCoreWebAppMVC_NoAuth.CAL
{
    public interface IHomeDataService
    {
        List<TodoTask> GetTasks(int userId);

        void SaveTasks(int userId, List<TodoTask> tasks);

        void DeleteTask(int id);

        void AddTask(int id, string description, bool isChecked);
    }
}