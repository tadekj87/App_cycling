using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using System.Diagnostics;

using App2.Helper;
using App2.Models;
using Newtonsoft.Json;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Teren : ContentPage
    {
        Stopwatch czasomierz = new Stopwatch();
        int i = 0;
        double moc = 0, DoPomiaruMocySredniej=0, DoPomiaruKadencjiSredniej=0, kadencja=0;
        string Location = "Wrocław";

        public Teren()
        {
            InitializeComponent();
            GetWeatherInfo();

            czasomierz.Start();


            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CzasTreningu.Text = String.Format("{0:HH:mm:ss}", czasomierz.Elapsed.ToString());
                i++;
                moc = moc + DoPomiaruMocySredniej;
                kadencja = kadencja + DoPomiaruKadencjiSredniej;
                MocSrednia.Text = String.Format("Średnia: {0} W", (moc/i).ToString("F02"));
                KadencjaSrednia.Text = String.Format("Średnia {0} obr/min",(kadencja/i).ToString("F02"));
                return true;
            });

         }
        int count = 0;
        void Koniec_Button(object sender, System.EventArgs e)
        { Navigation.PopAsync(); }

        private void Slider_value_changed(object sender, ValueChangedEventArgs e)
        {
            MocChwilowa.Text = String.Format("Chwilowa: {0:F1} W", e.NewValue);
            DoPomiaruMocySredniej = e.NewValue;
            Location = Lokalizacja.Text;
            GetWeatherInfo();
        }

        private void Slider_value_changed2(object sender, ValueChangedEventArgs e)
        {
            KadencjaChwilowa.Text = String.Format("Chwilowa: {0:F1} obr/min", e.NewValue);
            DoPomiaruKadencjiSredniej = e.NewValue;
            Location = Lokalizacja.Text;
            GetWeatherInfo();
        }

        private async void GetWeatherInfo()
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={Location}&APPID=af0a2f55ea1c08a014e9ac44776623c1&units=metric";

            var result = await ApiCaller.Get(url);

            if (result.Successful)
            {
                try
                {
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(result.Response);
                    Temperatura.Text = $"Temperatura: {weatherInfo.main.temp.ToString("0")} °C";
                    PredkoscWiatru.Text = $"Wiatr: {weatherInfo.wind.speed} m/s";
                    
                    var dt = new DateTime().ToUniversalTime().AddSeconds(weatherInfo.dt);
                    
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Weather Info", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Weather Info", "No weather information found", "OK");
            }
        }
    }
}