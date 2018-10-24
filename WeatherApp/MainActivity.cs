using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherApp.Core;
using System.Drawing;
using Android;
using System;
using Android.Content;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView1;
        TextView textView2;
        TextView textView3;
        SearchView searchView;
        Button button;
        TextView textAvg;
        ImageView weatherIcon;
        Button button2;


        protected  override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            button = FindViewById<Button>(Resource.Id.button1);
            button2 = FindViewById<Button>(Resource.Id.button2);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView2= FindViewById<TextView>(Resource.Id.textView2);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);
            searchView = FindViewById<SearchView>(Resource.Id.searchView1);
            textAvg = FindViewById<TextView>(Resource.Id.textTempavg);
            weatherIcon = FindViewById<ImageView>(Resource.Id.weatherIcon);


            button.Click += Button_Click;
            button2.Click += button2_ClickAsync;
        }

        private async void Button_Click(object sender, System.EventArgs e)
        {
            var weather = await Core.Core.GetWeather(searchView.Query);
            textView1.Text = weather.Temperature;
            textView2.Text = weather.Pressure;
            textView3.Text = weather.Wind;
            textAvg.Text = weather.Tempavg;
            weatherIcon.SetImageResource(Resources.GetIdentifier(weather.ImageName, "drawable", PackageName));
        }
        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            await GetForecast();
            Intent intent = new Intent(this, typeof(FiveDayActivity));
            StartActivity(intent);
        }


            private async Task<List<Weather>> GetForecast()
            {
                List<Core.Weather> weather = await Core.FiveDayCore.GetWeather(FindViewById<SearchView>(Resource.Id.searchView1).Query);
                Core.Weathers.weathers = weather;

                return weather;
            }

        }
    }
     