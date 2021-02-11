using System;

namespace DeloitteCoreWebAppMVC_NoAuth.CAL.Entities
{
    [Serializable]
    public class TodoTask
    {
        public bool IsChecked { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Id { get; set; }
    }
}