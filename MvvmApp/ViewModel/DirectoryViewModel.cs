using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmApp.Model;
using MvvmApp.Model.Storage;

namespace MvvmApp.ViewModel
{
    public class DirectoryViewModel : ObservableObject
    {

        private EmployeeDirectory directory;

        public EmployeeDirectory Directory
        {
            get { return directory; }
            set { directory = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged(); }
        }


        public DirectoryViewModel()
        {
            LoadDirectory();
        }

        async Task LoadDirectory()
        {
            SQLiteAsyncManager database = new SQLiteAsyncManager();
            Employees = new ObservableCollection<Employee>
                (await database.GetAllItems<Employee>());
            

            if (!Employees.Any())
            {
                Directory = new EmployeeDirectory();
                await Directory.GenerateRandomDirectory();
                Employees = Directory.Employees;
            }
        }

    }
}
