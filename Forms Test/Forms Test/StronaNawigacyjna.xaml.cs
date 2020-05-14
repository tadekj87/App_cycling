using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace FormsTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StronaNawigacyjna : ContentPage
    {
        public StronaNawigacyjna()
        {
            InitializeComponent();
        }

        int count = 0;
        void Dom_Button(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("NawigacjaDom", new Dictionary<string, string> { { "od", "StronaNaw" }, { "do", "Dom" } });
            Navigation.PushAsync(new Dom());
        }

        void Teren_Button(object sender, System.EventArgs e)
        {
            Analytics.TrackEvent("NawigacjaTeren", new Dictionary<string, string> { { "od", "StronaNaw" }, { "do", "Teren" } });

            Navigation.PushAsync(new Teren());

        }

        void Wyloguj_Button(object sender, System.EventArgs e)
        {

            count++;
            ((Button)sender).Text = $"{count}";

        }

        void Crash_Button(object sender, System.EventArgs e)
        {
            Crashes.GenerateTestCrash();

        }

        void Exception_Button(object sender, System.EventArgs e)
        {
            try
            {
                Crashes.GenerateTestCrash();
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }

        }
    }
}