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

namespace SheriTestApp
{
    [Activity(Label = "", MainLauncher = false, Icon = "@drawable/seatswap_logo")]
    public class SwapableSeat : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.SwapableSeat);
            // Create your application here
            Button bt_send = this.FindViewById<Button>(Resource.Id.btnOffer);
             bt_send.Click += (object sender, EventArgs e) =>
             {
                 var intent = new Intent(this, typeof(OfferSeat));
                 StartActivity(intent);
             };
        }
    }
}