using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExchangeRate
{
    public partial class PeriodOfDateView : ContentPage
    {
        public PeriodOfDateView()
        {
            InitializeComponent();
        }
        private void OnContinueClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RateView(datePicker.Date, datePicker2.Date.ToString("MM.dd.yyyy")));
        }
    }
}
