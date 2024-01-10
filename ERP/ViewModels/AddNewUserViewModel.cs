using Avalonia.Controls;
using ERP.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels
{
    public class AddNewUserViewModel : ViewModelBase
    {
        public Person newUser { get; set; }

        public MainWindowViewModel MWViewModel { get; set; }

        public ComboBoxItem SelectedDepartment { get; set; }

        public AddNewUserViewModel(MainWindowViewModel mw) {

            SelectedDepartment = new ComboBoxItem
            {
                Content = "IT"
            };

            MWViewModel = mw;

            newUser = new Person();

            AddUserCommand = ReactiveCommand.CreateFromTask(async () =>
            {

                newUser.Department = SelectedDepartment.Content.ToString();
                
                Random rand = new();
                await SaveToDiskAsync(new Person(newUser.FirstName, newUser.LastName, rand.Next(99999999, int.MaxValue), newUser.Department, newUser.Salary, newUser.StartingDate));

                MWViewModel.OpenMainView(0);

            });
        }

        public ICommand AddUserCommand { get; }

        public async Task SaveToDiskAsync(Person newUser)
        {
            await newUser.SaveAsync();
        }
    }
}
