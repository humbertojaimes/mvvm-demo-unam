using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmApp.Model;
using MvvmApp.View;
using Xamarin.Forms;

namespace MvvmApp.ViewModel
{
    public class LoginViewModel : ObservableObject
    {

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

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public Command LoginCommand
        {
            get;
            set;
        }

        public LoginViewModel()
        {
            LoginCommand =
                new Command(async () => await Login());
            //
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        async Task Login()
        {
            if (!IsBusy)
            {
                Navigation = Application.Current.MainPage.Navigation;
                IsBusy = true;
                await Task.Delay(1000);
                await Application.Current.MainPage.DisplayAlert
                 ("Bienvenido!!", $"Usuario: {user}","Ok");
                await Navigation.PushAsync(new DirectoryPage());
                IsBusy = false;
            }
        }
    }
}
