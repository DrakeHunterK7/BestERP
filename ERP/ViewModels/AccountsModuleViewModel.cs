using ERP.Models;
using ReactiveUI;
using System.Reactive.Concurrency;
using System.Collections.ObjectModel;
using System.Linq;

namespace ERP.ViewModels
{
    public class AccountsModuleViewModel: ViewModelBase
    {
        public ObservableCollection<Person> People { get; }
        public Person? SelectedPerson { get; set; }

        public AccountsModuleViewModel()
        {
            People = new ObservableCollection<Person>();

            RxApp.MainThreadScheduler.Schedule(LoadUsers);
        }

        private async void LoadUsers()
        {
            var users = await Person.LoadCachedAsync();

            foreach (var user in users)
            {
                People.Add(user);
            }
        }
    }
}
