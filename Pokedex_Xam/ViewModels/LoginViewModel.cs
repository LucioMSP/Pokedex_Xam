using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;
using Pokedex_Xam.Views;

namespace Pokedex_Xam.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public async void OnSubmit()
        {
            if (email != "demo@demo.com" || password != "demo1234")
            {
                DisplayInvalidLoginPrompt();
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new PokemonsPage());
            }
        }
    }
}