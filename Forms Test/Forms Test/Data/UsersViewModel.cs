using Forms_Test;
using FormsTest.Data;
using FormsTest.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FormsTest
{
   public class UsersViewModel : INotifyPropertyChanged
    { private readonly IUsersRepository _usersRepository;
        private IEnumerable<Users> _users;

        public IEnumerable<Users> UsersL
        {
            get
            {
                return _users;
            }
            set 
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    UsersL = await _usersRepository.GetUsersAsync();
                });
            }
        }
  
        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var users = new Users
                    {
                        Name = UserName,
                        Password = UserPassword,
                    };
                   await _usersRepository.AddUser(users);
                });
            }
        }

        public ICommand BackToPage
        {
            get
            {
                return new Command(async () =>
                {


                    
                    await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage(_usersRepository));
                });
            } }
        public ICommand BackToLogin
        {
            get
            {
                return new Command(async () =>
                {

                   

                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage(_usersRepository));
                });
            }
        }

        public ICommand Validate
        {
            get
            {
                return new Command(async () =>
                {

                    // var e = await _usersRepository.GetUsersAsync();
                    //var e= UsersL.FirstOrDefault(c => c.Name.Equals($"UserName"));
                    //var pass = await _usersRepository.GetUserByIdAsync(UserPassword);
                  
                    if (true)
                    {
                        await Application.Current.MainPage.DisplayAlert("sukces", "zalogowano pomyslnie", "Ok");
                        await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new StronaNawigacyjna()));
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("blad", "zle dane", "ok");


                });
            }
        }
        


        public UsersViewModel(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
