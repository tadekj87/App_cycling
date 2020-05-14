using FormsTest.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Forms_Test
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            int jakisczas = 12;

            InitializeComponent();


            CzasTreningu.Text = $"{jakisczas}:{jakisczas}:{jakisczas}";

            Temperatura.Text = $"{jakisczas} °C";

            MocSrednia.Text = $"Średnia: {jakisczas} W";

            MocChwilowa.Text = $"Chwilowa: {jakisczas} W";

            KadencjaSrednia.Text = $"Kadencja: {jakisczas} obr/min";

            KadencjaChwilowa.Text = $"Kadencja: {jakisczas} obr/min";
        }
        int count = 0;
        void Koniec_Button(object sender, System.EventArgs e)
        {

            count++;
            ((Button)sender).Text = $"Kliknąłeś {count} razy";
        }
    }
}
