using ERP.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private AccountsModuleViewModel amViewModel;

        public int SelectedTab { get; set; }

        public MainViewModel() {

            amViewModel = new AccountsModuleViewModel();
            SelectedTab = 0;
        }

        public AccountsModuleViewModel AMViewModel
        {
            get => amViewModel;
            private set => this.RaiseAndSetIfChanged(ref amViewModel, value);
        }

    }
}
