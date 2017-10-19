using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MvvmApp.Model
{
    public class EmployeeDirectory
    {
        
        public EmployeeDirectory()
        {

        }

        public async Task GenerateRandomDirectory()
        {
                Employees = new ObservableCollection<Employee>();
                Random rdn = new Random();

                for (int i = 0; i < 16; i++)
                {
                    var name = "Nombre" + i;
                    var newEmployee = new Employee(
                        name,
                        null,
                        (JobPosition)rdn.Next(0, 4),
                        name + "@mycompany.com"
                    );
                    Employees.Add(newEmployee);
                   
                }
        }

        public ObservableCollection<Employee> Employees
        {
            get;
            set;
        }

    }
}
