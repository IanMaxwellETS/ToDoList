using ReactiveUI;
using System;
using System.Reactive.Linq;
using ToDoList.DataModel;
using ToDoList.Services;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;
        
        // dependency on ToDoListService

        public MainWindowViewModel()
		{
			ToDoListService _service = new MockToDoListService();
            ToDoList = new ToDoListViewModel(_service.GetItems());
			_contentViewModel = ToDoList;
		}

		public ViewModelBase ContentViewModel
		{
			get => _contentViewModel;
			private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
		}

		public ToDoListViewModel ToDoList { get; }

        public void AddItem()
        {
            AddItemViewModel addItemViewModel = new();

			Observable.Merge(addItemViewModel.OkCommand,
			                 addItemViewModel.CancelCommand.Select(_ => null as ToDoItem))
				.Take(1)
				.Subscribe(ReturnToList);

			ContentViewModel = addItemViewModel;
		}

		private void ReturnToList(ToDoItem? item)
		{
			if (item is not null)
				ToDoList.ListItems.Add(item);

			ContentViewModel = ToDoList;
		}
	}
}
