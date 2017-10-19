using System;
using MvvmApp.Model;

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

        public DirectoryViewModel()
        {

            Directory = new EmployeeDirectory();
            Directory.GenerateRandomDirectory();
        }

    }
}
