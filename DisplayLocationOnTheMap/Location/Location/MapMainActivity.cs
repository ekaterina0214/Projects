using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Json;
using Newtonsoft.Json;

namespace Location
{
    [Activity(Label = "Location")]
    public class MapMainActivity : Activity,IOnMapReadyCallback
    {
        private GoogleMap mMap;
        MapFragment _myMapFragment;
        JsonObject json;
        JsonObject json1;

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            LatLng latLng = new LatLng(json1["lat"], json1["lon"]);
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latLng,10);
            mMap.MoveCamera(camera);
            MarkerOptions options = new MarkerOptions()
            .SetPosition(latLng)
            .SetTitle("Xamarin Task")
            .SetSnippet("IP: " + json["ip"]+", Country: " + json1["country"]+", City: " + json1["city"]);
            mMap.AddMarker(options);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MapMain);
            json = JsonConvert.DeserializeObject<JsonObject>(Intent.GetStringExtra("IP"));
            json1 = JsonConvert.DeserializeObject<JsonObject>(Intent.GetStringExtra("Location"));
            _myMapFragment = MapFragment.NewInstance();
            FragmentTransaction tx = FragmentManager.BeginTransaction();
            tx.Add(Resource.Id.my_mapfragment_container, _myMapFragment);
            tx.Commit();

            SetUpMap();
        }
        
        private void SetUpMap()
        {
            if(mMap==null)
            {
                _myMapFragment.GetMapAsync(this);
            }
        }
    }
}

