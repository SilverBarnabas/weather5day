using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherApp
{
    public class CustomAdapter : BaseAdapter<Core.Weather>
    {
        List<Core.Weather> weathers;
        Activity context;

        public CustomAdapter(Activity context, List<Core.Weather> items) : base()
        {
            this.context = context;
            this.weathers = items;
        }

        public override Core.Weather this[int position]
        {
            get { return weathers[position]; }
        }

        public override int Count { get { return weathers.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);
            }


            ImageView Icon = view.FindViewById<ImageView>(Resource.Id.Layout1Image);

            switch (weathers[position].ImageName)
            {
                case "01d":
                case "01n":
                    Icon.SetImageResource(Resource.Drawable._01d);
                    break;
                case "02d":
                case "02n":
                    Icon.SetImageResource(Resource.Drawable._02d);
                    break;
                case "03d":
                case "03n":
                    Icon.SetImageResource(Resource.Drawable._03d);
                    break;
                case "04d":
                case "04n":
                    Icon.SetImageResource(Resource.Drawable._04d);
                    break;
                case "09d":
                case "09n":
                    Icon.SetImageResource(Resource.Drawable._09d);
                    break;
                case "10d":
                case "10n":
                    Icon.SetImageResource(Resource.Drawable._10d);
                    break;
                case "11d":
                case "11n":
                    Icon.SetImageResource(Resource.Drawable._11d);
                    break;
                case "13d":
                case "13n":
                    Icon.SetImageResource(Resource.Drawable._13d);
                    break;
                case "50d":
                case "50n":
                    Icon.SetImageResource(Resource.Drawable._50d);
                    break;
                default:
                    break;
            }
            
            view.FindViewById<TextView>(Resource.Id.input).Text = weathers[0].City;
            view.FindViewById<TextView>(Resource.Id.tempHigh).Text = (weathers[position].Temperature);
            //view.FindViewById<TextView>(Resource.Id.humidity).Text = weathers[position].humidity;
            view.FindViewById<TextView>(Resource.Id.date).Text = Convert.ToDateTime(weathers[position].Date).ToString("dddd");
            return view;
        }
    }
}