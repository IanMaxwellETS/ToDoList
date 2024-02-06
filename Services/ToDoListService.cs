using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public abstract class ToDoListService
    {
        public abstract IEnumerable<ToDoItem> GetItems();
    }

    internal class MockToDoListService : ToDoListService
    {
        private readonly ToDoItem[] _items =
            [
                new("Walk the dog"),
                new("Buy some milk"),
                new("Learn Avalonia"),
            ];

        public override IEnumerable<ToDoItem> GetItems() => _items;
    }
}
