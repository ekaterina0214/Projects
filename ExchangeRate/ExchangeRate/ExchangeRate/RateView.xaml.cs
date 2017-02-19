using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ExchangeRate
{
    public partial class RateView : ContentPage
    {
        DateTime _dateTime;
        string _dateTime2;
        public RateView(DateTime dateView, string dateView2)
        {
            InitializeComponent();
            _dateTime = dateView;
            _dateTime2 = dateView2;
            NavigationPage.SetHasNavigationBar(this, true);
            GetData();
        }
        private async void GetData()
        {
            Service _service = new Service();
            List<InnerModel> list = new List<InnerModel>();
            if(String.IsNullOrWhiteSpace(_dateTime2))
            {
                var l = await _service.GetExchangeRateByDate(_dateTime.ToString("dd.MM.yyyy"));
                list.Add(l[0]);
                foreach (var item in l)
                {                    
                    if (item.currency == "EUR" || item.currency == "RUB" || item.currency == "CAD" || item.currency == "USD")
                    {
                        list.Add(item);
                    }
                }
            }
            else
            {
                var d = _dateTime.ToString("dd.MM.yyyy");
                string temp = Convert.ToDateTime(_dateTime2).AddDays(1).ToString("dd.MM.yyyy");
                while (d != temp)
                {
                    var l = await _service.GetExchangeRateByDate(d);
                    _dateTime = _dateTime.AddDays(1);
                    d = _dateTime.ToString("dd.MM.yyyy");
                    list.Add(l[0]);
                    foreach (var item in l)
                    {
                        if (item.currency == "EUR" || item.currency == "RUB" || item.currency == "CAD" || item.currency == "USD")
                        {
                            list.Add(item);
                        }                        
                    }
                }                
            }
            listView.ItemsSource = list;
        }
    }
}
