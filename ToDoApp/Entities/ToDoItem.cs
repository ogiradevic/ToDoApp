﻿namespace ToDoApp.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDelete { get; set; }
    }
}
