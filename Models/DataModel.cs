using System;

namespace ToDoList.DataModel
{
    public class ToDoItem(string description, bool isChecked = false)
    {
        public string Description { get; set; } = description;
        public bool IsChecked { get; set; } = isChecked;
    }
}
