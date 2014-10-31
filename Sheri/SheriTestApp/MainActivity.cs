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

            Button bt_send = this.FindViewById<Button>(Resource.Id.btnSelect);
            bt_send.Click += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(SwapableSeat));
                StartActivity(intent);
            };


            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
            
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            
            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            //CustomGrid adapter = new CustomGrid(MainActivity.this, web, imageId);
            //GridView gridview = FindViewById <GridView>(Resource.Id.gridview);
            //gridview.SetAdapter(IListAdapter(this);
           // gridview.SetAdapter(new ImageAdapter (this));
            

        }
    }
}


