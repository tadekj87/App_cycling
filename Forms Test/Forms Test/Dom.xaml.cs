using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormsTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dom : ContentPage
    {
        int jakisczas = 12, count = 0;
        Color Dobrykolor = Color.LightGreen, Niedobrykolor = Color.OrangeRed;
        int mocZadana = 200;
        int kadencjaZadana = 90;
        CancellationTokenSource _CancellationTokenSource;
        public Dom()
        {
            InitializeComponent();
            _CancellationTokenSource = new CancellationTokenSource();
            MocZadana.Text = "Moc: 0 W";
            KadencjaZadana.Text = "Kadencja: 0 obr/min";

            int Min = 60;
            int Sec = 0;
            int TotalSec = (Min * 60) + Sec;
            CancellationTokenSource CTS = _CancellationTokenSource;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (CTS.IsCancellationRequested)
                {
                    return false;
                }
                else
                {
                    if (TotalSec == 0)
                    {
                        return false;
                    }
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        TotalSec = TotalSec - 1;
                        TimeSpan _TimeSpan = TimeSpan.FromSeconds(TotalSec);
                        CzasDoKonca.Text = String.Format("{0:00}:{1:00}", _TimeSpan.Minutes, _TimeSpan.Seconds);
                    });
                    return true;
                }
            });
        }
        void Rogrzewka_Button(object sender, System.EventArgs e)
        {
            mocZadana = 150;
            kadencjaZadana = 90;
            MocZadana.Text = $"Moc: {mocZadana} W";
            KadencjaZadana.Text = $"Kadencja: {kadencjaZadana} obr/min";
        }

        void Sila_Button(object sender, System.EventArgs e)
        {
            mocZadana = 300;
            kadencjaZadana = 80;
            MocZadana.Text = $"Moc: {mocZadana} W";
            KadencjaZadana.Text = $"Kadencja: {kadencjaZadana} obr/min";
        }

        void Koniec_Button(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }


        private void Slider_value_changed(object sender, ValueChangedEventArgs e)
        {
            label_moc.Text = String.Format("Wartosc mocy [W]: {0:F1}", e.NewValue);
            MocPomiar.Text = String.Format("{0:F1} W", e.NewValue);


            if (Convert.ToInt32(e.NewValue) < 1.1 * mocZadana && Convert.ToInt32(e.NewValue) > 0.9 * mocZadana)
            {
                MocPomiar.TextColor = Dobrykolor;
            }
            else
            {
                MocPomiar.TextColor = Niedobrykolor;
            }
        }

        private void Slider_value_changed2(object sender, ValueChangedEventArgs e)
        {
            label_kadencja.Text = String.Format("Wartosc kadencji [rpm]: {0:F0}", e.NewValue);
            KadencjaPomiar.Text = String.Format("{0:F1} obr/min", e.NewValue);

            if (Convert.ToInt32(e.NewValue) < 1.1 * kadencjaZadana && Convert.ToInt32(e.NewValue) > 0.9 * kadencjaZadana)
            {
                KadencjaPomiar.TextColor = Dobrykolor;
            }
            else
            {
                KadencjaPomiar.TextColor = Niedobrykolor;
            }
        }


    }

}