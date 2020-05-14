using FormsTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class RegisterPage : ContentPage
{
    public RegisterPage(IUsersRepository usersRepository)
    {
        InitializeComponent();
        BindingContext = new UsersViewModel(usersRepository);
    }
        private async void RegisterProcedure(object sender, EventArgs e)
        {
            await DisplayAlert("Register", "Register completed", "Okey");
        }


        public void ShowPass(object sender, EventArgs args)
        {
            Entry_Password.IsPassword = Entry_Password.IsPassword ? false : true;
        }



    }
}