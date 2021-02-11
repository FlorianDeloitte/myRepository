using DeloitteCoreWebAppMVC_NoAuth.BL.Models;
using System.Collections.Generic;

namespace DeloitteCoreWebAppMVC_NoAuth.BL
{
    public interface IHomeBusinessService
    {
        List<TodoTaskModel> GetTasks(int userId);

        void SaveTasks(int userId, List<TodoTaskModel> tasks);

        void DeleteTask(int id);

        void AddTask(int id, string description, bool isChecked);
    }
}