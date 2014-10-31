using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;
using System.Collections.Generic;

namespace SheriTestApp
{
    public class CustomGrid : BaseAdapter
    {
        private int[] imageID;
        private int[] seatID;
        private string[] web;
        private Context context;
        private SeatPage seatsPage = new SeatPage();
        private List<Seat> seats;
        private int x = 0;
        
        public CustomGrid(Context c, string [] web, int[] imageID)
        {
            context = c;
            this.imageID = imageID;
            this.web = web;
            seats = seatsPage.getAllSeats();
        }

        public override int Count
        {
            get { return seats.Count; }
        }

        public override Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {                           
            View grid;
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);

            if (convertView == null)
            {
                grid = new View(context);
                grid = inflater.Inflate(Resource.Layout.grid, null);
                TextView textView = (TextView)grid.FindViewById(Resource.Id.grid_text);
                ImageView imageView = (ImageView)grid.FindViewById(Resource.Id.grid_image);

                //textView.SetText("", TextView.BufferType.Normal);
                textView.SetText(GetSeatID(position), TextView.BufferType.Normal);
                imageView.SetImageResource(imageID[GetSeatImage(position)]);
            }
            else
            {
                grid = (View) convertView;
            }
           
            return grid;
        }

        private string GetSeatID(int seatID)
        {
            string imageText = string.Empty;
            imageText = seats[seatID].SeatId;
            return imageText;
        }
                        
        private int GetSeatImage(int seatID)
        {            
            //Resource.Drawable.green_seat, 0
            //Resource.Drawable.blue_seat,  1           
            //Resource.Drawable.red_seat,   2
            //Resource.Drawable.orange_seat

            int imageID = 0;

            int status = seats[seatID].SeatStatus;
            imageID = status;

            return imageID;
        }
       
    }

   
}