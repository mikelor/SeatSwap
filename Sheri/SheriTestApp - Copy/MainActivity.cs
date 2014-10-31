using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace SheriTestApp
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/seatswap_logo")]
    public class MainActivity : Activity
    {

        string[] web = {"", "", "", ""};

        //// references to our images
        int[] thumbIds = {
            
            Resource.Drawable.green_seat,
            Resource.Drawable.blue_seat,            
            Resource.Drawable.red_seat, 
            Resource.Drawable.orange_seat
        };
        
        GridView grid;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            
            CustomGrid adapter = new CustomGrid(this, web, thumbIds);
            grid = FindViewById<GridView>(Resource.Id.grid);
            grid.SetAdapter(adapter);
            grid.ItemClick += (sender, args) => Toast.MakeText(this, args.Position.ToString(), ToastLength.Short).Show();

        }
    }
}


