using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmApp.ViewModel
{
    public class SignUpViewModel: INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged
            = delegate { };

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string user;

        public string User
        {
            get { return user; }
            set
            {
                if (user != value)
                    OnPropertyChanged();
                user = value;
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                    OnPropertyChanged();
                password = value;
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

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public Command SignUpCommand
        {
            get;
            set;
        }

        public SignUpViewModel()
        {
            SignUpCommand =
                new Command(async () => await SignUp());
            //
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        async Task SignUp()
        {
            if (!IsBusy)
            {
                Navigation = Application.Current.MainPage.Navigation;
                IsBusy = true;
                await Task.Delay(3000);
                await Application.Current.MainPage.DisplayAlert
                 ("Bienvenido!!", $"Usuario: {user}", "Ok");
                //await Navigation.PushAsync(new MainPage());
                IsBusy = false;
            }
        }
    }
}
