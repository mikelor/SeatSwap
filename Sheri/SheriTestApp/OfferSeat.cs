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
   [Activity(Label = "Seat Swap", MainLauncher = false, Icon = "@drawable/seatswap_logo")]
    public class OfferSeat : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.OfferSeat);
            // Create your application here

            Button bt_send = this.FindViewById<Button>(Resource.Id.btnPost);
            bt_send.Click += (object sender, EventArgs e) =>
            {
                var builder = new AlertDialog.Builder(this)
                    .SetMessage("Your seat has been posted as available")
                    .SetTitle("Thank you")
                    .SetPositiveButton("Ok", (s, args) =>
                    {
                        // Do something when this button is clicked.
                    });
                builder.Create().Show();
            };

        }
    }
}