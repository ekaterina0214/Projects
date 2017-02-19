using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExchangeRate
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }        
        private void OnPeriodOfDateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PeriodOfDateView());
        }
        private void OnDateClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DateView());
        }
    }
}
