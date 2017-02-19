using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExchangeRate
{
    public partial class DateView : ContentPage
    {
        public DateView()
        {
            InitializeComponent();
        }
        private void OnContinueClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RateView(datePicker.Date, ""));
        }
    }
}
