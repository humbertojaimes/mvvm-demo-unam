using System;
using Newtonsoft.Json;

namespace MvvmApp.Model
{
    public class Account : ObservableObject
    {
        public Account()
        {
        }

        private string password;
        //[JsonProperty("Password")]
        public string Password 
        {
            get { return password; }
            set 
            {
                if(password!=value)
                    OnPropertyChanged();
                password = value;  
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (confirmPassword != value)
                    OnPropertyChanged();
                confirmPassword = value;
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                    OnPropertyChanged();
                email = value;
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                    OnPropertyChanged();
                name = value;
            }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                if (address != value)
                    OnPropertyChanged();
                address = value;
            }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                    OnPropertyChanged();
                phoneNumber = value;
            }
        }
    }
}
