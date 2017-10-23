using System;
using MvvmApp.Model.Interfaces;

namespace MvvmApp.Model
{
    public enum JobPosition
    {
        Excecutive,
        Operator,
        Supervisor,
        TechnicalSupport,
        Developer
    }

    public class Employee 
        : ObservableObject, IKeyObject
    {
      
        [SQLite.PrimaryKey]
        public string Id
        {
            get;
            set;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Email = name.Replace(" ", "") + "@mycompany.com";
                OnPropertyChanged();
            }
        }

        private byte[] photo;
        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

        private JobPosition position;
        public JobPosition Position
        {
            get;
            set;
        }

        private string email;


        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }


        public Employee(string name, byte[] photo, JobPosition position, string email)
        {
            Name = name;
            Id = name;
            Photo = photo;
            Position = position;
            Email = email;
        }

        public Employee()
        {

        }
    }
}
