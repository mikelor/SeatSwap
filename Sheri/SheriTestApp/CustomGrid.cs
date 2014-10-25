using Android.Content;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace SheriTestApp
{
    public class CustomGrid : BaseAdapter
    {
        private int[] imageID;
        private string[] web;
        private Context context;
        
        public CustomGrid(Context c, string [] web, int[] imageID)
        {
            context = c;
            this.imageID = imageID;
            this.web = web;
        }

        public override int Count
        {
            get { return GetSeatCount(); }
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

                textView.SetText(web[position].ToString(), TextView.BufferType.Normal);
                imageView.SetImageResource(imageID[position]); 
            }
            else
            {
                grid = (View) convertView;
            }
           
            return grid;
        }

        private int GetSeatCount()
        {
            int count = 4;
            return count;
        }
  
        private int GetSeatImage(int seatID)
        {
            int imageID = 0;

            return imageID;
        }
    }

   
}