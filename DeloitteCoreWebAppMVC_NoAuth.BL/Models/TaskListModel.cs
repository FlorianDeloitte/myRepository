using System;

namespace DeloitteCoreWebAppMVC_NoAuth.BL.Models
{
    public class TodoTaskModel
    {
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Id { get; set; }
    }
}