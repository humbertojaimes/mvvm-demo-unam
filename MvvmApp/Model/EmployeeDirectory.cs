using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmApp.Model.Storage;

namespace MvvmApp.Model
{
    public class EmployeeDirectory
    {

        public EmployeeDirectory()
        {

        }

        public async Task GenerateRandomDirectory()
        {
            try
            {
                SQLiteAsyncManager database = new SQLiteAsyncManager();
                Employees = new ObservableCollection<Employee>();
                Random rdn = new Random();

                for (int i = 0; i < 16; i++)
                {
                    var name = "Nombre" + rdn.Next(0, 1000);
                    var newEmployee = new Employee(
                        name,
                        null,
                        (JobPosition)rdn.Next(0, 4),
                        name + "@mycompany.com"
                    );
                    Employees.Add(newEmployee);
                    await database.SaveValue<Employee>(newEmployee, true);
                }
            }catch(Exception e)
            {
                
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get;
            set;
        }

    }
}
