using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Location
{
    
    [Activity(Label = "Xamarin2Task", MainLauncher = true, Icon = "@drawable/icon")]
    public class Main : Activity
    {
        Button button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            button = FindViewById<Button>(Resource.Id.button1);
            string url0 = "https://api.ipify.org/?format=json";
            string url1 = "http://ip-api.com/json/103.101.100.110";

            button.Click += async (sender, e) =>
            {
                
                JsonValue json = await GetDataAsync(url0);
                JsonValue json1 = await GetDataAsync(url1);
                Button_Click(json, json1);
                button.Enabled = false;
            };
        }

        void Button_Click(JsonValue json1, JsonValue json2)
        {
            Intent intent = new Intent(this, typeof(MapMainActivity));
            intent.PutExtra("IP", json1.ToString());
            intent.PutExtra("Location", json2.ToString());
            this.StartActivity(intent);
            button.Enabled = true;
        }

        private async Task<JsonValue> GetDataAsync(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    return jsonDoc;
                }
            }
        }

    }
}