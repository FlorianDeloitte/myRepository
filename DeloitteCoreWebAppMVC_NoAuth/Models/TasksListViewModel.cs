using System;
using System.Collections.Generic;

namespace DeloitteCoreWebAppMVC_NoAuth.Models
{
    public class TasksListViewModel
    {
        public List<TodoTaskViewModel> Tasks { get; set; }
    }

    public class TodoTaskViewModel
    {
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Id { get; set; }
    }
}