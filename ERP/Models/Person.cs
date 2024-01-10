using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ERP.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        public DateTime StartingDate { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            Id = 0;
            Department = "IT";
            Salary = 100.00m;
            StartingDate = DateTime.Now;    
        }

        public Person(string firstName, string lastName, int id, string department, decimal salary, DateTime startingDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Department = department;
            Salary = salary;
            StartingDate = startingDate.Date;
        }

        private string CachePath => $"./Cache/{FirstName}-{LastName}";

        public async Task SaveAsync()
        {
            if (!Directory.Exists("./Cache"))
            {
                Directory.CreateDirectory("./Cache");
            }

            using (var fs = File.OpenWrite(CachePath))
            {
                await SaveToStreamAsync(this, fs);
            }
        }

        private static async Task SaveToStreamAsync(Person data, Stream stream)
        {
            await JsonSerializer.SerializeAsync(stream, data).ConfigureAwait(false);
        }

        public static async Task<Person> LoadFromStream(Stream stream)
        {
            return (await JsonSerializer.DeserializeAsync<Person>(stream).ConfigureAwait(false))!;
        }

        public static async Task<IEnumerable<Person>> LoadCachedAsync()
        {
            if (!Directory.Exists("./Cache"))
            {
                Directory.CreateDirectory("./Cache");
            }

            var results = new List<Person>();

            foreach (var file in Directory.EnumerateFiles("./Cache"))
            {
                if (!string.IsNullOrWhiteSpace(new DirectoryInfo(file).Extension)) continue;

                await using var fs = File.OpenRead(file);
                results.Add(await Person.LoadFromStream(fs).ConfigureAwait(false));
            }

            return results;
        }
    }
}
