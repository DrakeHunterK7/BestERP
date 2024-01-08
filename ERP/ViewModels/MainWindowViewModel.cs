using ERP.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERP.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        public MainWindowViewModel()
        {
            _contentViewModel = new LogInViewModel();
        }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public void LogIn()
        {
            ContentViewModel = new MainViewModel();
        }

        public void AddNewUser()
        {
            ContentViewModel = new AddNewUserViewModel();
        }
    }
}