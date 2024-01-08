using ERP.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.ViewModels
{
    public class AddNewUserViewModel : ViewModelBase
    {
        public string newFirstName { get; set; }
        public string newLastName { get; set; }
        public decimal newSalary { get; set; }
        public int newID { get; set; }
        public DateTime createdDate { get; set; }

        public string newDepartment { get; set; }

        public AddNewUserViewModel() {

            newFirstName = "";
            newLastName = "";
            newSalary = 100.00m;
            newID = 0;
            createdDate = System.DateTime.Today;
            newDepartment = "IT";

            AddUserCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                Random rand = new Random();
                await SaveToDiskAsync(new Person(newFirstName, newLastName, rand.Next(99999999, int.MaxValue), newDepartment, newSalary, createdDate));


            });
        }

        public ICommand AddUserCommand { get; }

        public async Task SaveToDiskAsync(Person newUser)
        {
            await newUser.SaveAsync();
        }
    }
}
