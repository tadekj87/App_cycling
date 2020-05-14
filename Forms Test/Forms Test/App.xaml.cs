
using FormsTest;
using FormsTest.Data;
using FormsTest.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Forms_Test
{
    public partial class App : Application
    {
        public App(IUsersRepository usersRepository)
        {
            InitializeComponent();

            //MainPage = new LoginPage();
            //MainPage = new NavigationPage(new MainPage());
            //  MainPage = new NavigationPage(new LoginPage());
            /* MainPage = new RegisterPage()
             {
                 BindingContext= new UsersViewModel(usersRepository),

             };  */
            //var registerPage = new RegisterPage()
            //{
            //    BindingContext=new UsersViewModel(usersRepository)
            //};
            //var loginPage = new LoginPage();
            MainPage = new NavigationPage(new LoginPage(usersRepository));
            // {
            //   BindingContext = new UsersViewModel(usersRepository)
            // };

            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=4c043098-2329-4536-a8b5-b8ccfd60d4e7", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
