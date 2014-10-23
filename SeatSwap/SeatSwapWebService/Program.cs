using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatSwapLib
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Running ...\n\n");
            Program p = new Program();
            p.Run();
            Console.WriteLine("\n\nDone ...hit return");

        }

        private void Run()
        { 
        }
    }
    class Passenger
    {
        public Passenger()
        {
            PassengerId = Guid.NewGuid().ToString();
            SeatID = String.Empty;
            Name = String.Empty;
            ContactInfo = String.Empty;
        }
        public Passenger(string _passengerid,string _seatid,string _name, string _contactinfo)
        {
            PassengerId = _passengerid;
            SeatID = _seatid;
            Name = _name;
            ContactInfo = _contactinfo;
        }


        public string PassengerId { get; set; }
        public string SeatID { get; set; } // eg. 12C
        public string Name { get; set; }
        public string ContactInfo { get; set; } // mailto:2063030802.att.com

        static string[] fnames = new string[] { "Mary", "Bob", "Jane", "Bill", "Kirk", "Sandy", "Jerome", "Shelly", "Mike", "Mark", "Satie", "Jack", "Jim", "Eddy" };
        static string[] minitials = new string[] { "M", "B", "J", "K", "S", "E", "A", "Z" };
        static string[] lnames = new string[] { "Kraus", "Weber", "Nijjar", "Johnson", "Wilson", "Marks", "Obama", "King", "Doe", "Bowin", "Kelley" };

        static public Passenger CreateDummyPassenger()
        {

            Random r = new Random();
            int fnamesNdx = r.Next(0, fnames.Length - 1);
            int minitialsNdx = r.Next(0, minitials.Length - 1);
            int lnamesNdx = r.Next(0, lnames.Length - 1);

            string fullname = String.Format("{0} {1} {2}",fnames[fnamesNdx],minitials[minitialsNdx],lnames[lnamesNdx])
            return new Passenger(Guid.NewGuid().ToString(),null,fullname,null);
        }
        static public Passenger CreateDummyPassenger(string _passengerid)
        {

            Random r = new Random();
            int fnamesNdx = r.Next(0, fnames.Length - 1);
            int minitialsNdx = r.Next(0, minitials.Length - 1);
            int lnamesNdx = r.Next(0, lnames.Length - 1);

            string fullname = String.Format("{0} {1} {2}",fnames[fnamesNdx],minitials[minitialsNdx],lnames[lnamesNdx])
            return new Passenger(_passengerid,null,fullname,null);
        }


    }
    // simulates database of current seat assignments
    static class SeatCollection
    {
        static private List<Seat> Seats;

        static public void Initialize()
        {
            Seats = getAllSeats();
        }

        static public void SetSeat(Seat _seat)
        {
            foreach (Seat s in Seats)
            {
                if (s.SeatId.Equals(_seat.SeatId))
                {
                    s.SeatStatus = _seat.SeatStatus;
                    return;
                }
            }
            throw new Exception(String.Format("seatid:{0} is invalid",_seat.SeatId));
        }

        static public bool Validate(string _seatid)
        {
            foreach (Seat s in Seats)
            {
                if (s.SeatId.Equals(_seatid))
                    return true;
            }
            return false;
        }

        static public Seat GetSeat(string _seatid)
        {
            Seat seat = null;
            foreach(Seat s in Seats)
            {
                if(s.SeatId.Equals(_seatid))
                    return s;
            }
            return seat; 
        }


        private static List<Seat> getAllSeats()
        {
            List<Seat> allseats = new List<Seat>();
            for (int i = 6; i < 32; i++)
            {
                for (int ii = 1; i < 5; i++)
                {
                    switch (ii)
                    {
                        case 0: allseats.Add(new Seat(String.Format("{0}A", i))); break;
                        case 1: allseats.Add(new Seat(String.Format("{0}B", i))); break;
                        case 2: allseats.Add(new Seat(String.Format("{0}C", i))); break;
                        case 3: allseats.Add(new Seat(String.Format("{0}D", i))); break;
                        case 4: allseats.Add(new Seat(String.Format("{0}E", i))); break;
                        case 5: allseats.Add(new Seat(String.Format("{0}F", i))); break;
                        default: new Exception("SeatNot Implemented"); break;
                    }
                }
            }
                return allseats;
 
        }

        public static string Dump()
        {
            StringBuilder sb = new StringBuilder()
            foreach(Seat s in Seats)
            {
                sb.AppendFormat("{0}",s.ToString());
            }
            return sb.ToString();

        }

        private List<string> getAllSeatIDs()
        {
            List<string> allseatids = new List<string>();
            foreach (Seat s in Seats)
            {
                allseatids.Add(s.SeatId);
            }
            return allseatids;
        }
    }

    class Compensation
    {
        public const string DRINK = "Drink"; // default
        public const string FRUITBASKET = "Fruit Basket";
        public const string WIFI = "WiFi Voucher";
        public const string ALLDAYPREPAIDPARKING = "24-Hour Prepaid Parking";
        public const string DIGIPLAYER = "Digi Player";

        public Compensation()
        {
            Type = Compensation.DRINK;
            Quantity = 1;
        }
        public Compensation(string _type)
        {
            if (!Validate(_type))
                throw new Exception("Invalid compensation type");

            Type = _type;
            Quantity = 1;
        }

        public string Type { get; set; }
        public int Quantity { get; set; }

        public List<string> GetCompensationOptions()
        {
            List<string> options = new List<string>();
            options.Add(Compensation.DRINK);
            options.Add(Compensation.FRUITBASKET);
            options.Add(Compensation.WIFI);
            options.Add(Compensation.ALLDAYPREPAIDPARKING);
            options.Add(Compensation.DIGIPLAYER);

            return options;
        }
        public bool Validate(string _compensationtype)
        {
            switch (_compensationtype)
            {
                case DRINK: return true;
                case FRUITBASKET: return true;
                case WIFI: return true;
                case ALLDAYPREPAIDPARKING: return true;
                case DIGIPLAYER: return true;
                default: return false;
            }
        }
    }

    class Offer
    {
        public Offer(string _compensationtype,string _seatid)
        {
            SeatOffered = SeatCollection.GetSeat(_seatid);
            CompensationOffered = new Compensation(_compensationtype);
            SeatOffered.SeatStatus = Seat.STATUS_OFFERED;
            Id = Guid.NewGuid().ToString();
        }

        public string Id {get; set;}
        public Seat SeatOffered { get; set; }
        public Compensation CompensationOffered { get; set; }
    }


    class Seat
    {
        public const int STATUS_AVAILABLE = 0;
        public const int STATUS_OCCUPIED = 1;
        public const int STATUS_OFFERED = 2;

        public Seat()
        {
            SeatId = String.Empty;
            SeatStatus = Seat.STATUS_OCCUPIED;
            SeatPassenger = new Passenger();
        }
        public Seat(string _seatid)
        {
            SeatId = _seatid;
            SeatStatus = Seat.STATUS_OCCUPIED;
        }
        public Seat(string _seatid, int _seatstatus)
        {
            SeatId = _seatid;
            SeatStatus = _seatstatus;
        }
        public Seat(string _seatid, int _seatstatus, string _passengerid)
        {
            SeatId = _seatid;
            SeatStatus = _seatstatus;
            SeatPassenger = Passenger.CreateDummyPassenger(_passengerid);
        }

        public string SeatId { get; set; }  // eg. 12C
        public int SeatStatus { get; set; }
        public Passenger SeatPassenger { get; set; } 

        public override string ToString()
        {
            string NL = Environment.NewLine;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SeatId: {0}{1}",this.SeatId,NL);
            sb.AppendFormat("SeatStatus: {0}",this.SeatStatus,NL);
 	        return sb.ToString();
        }
        public override string ToJSON()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{SeatId = {0};", this.SeatId);
            sb.AppendFormat("SeatStatus = {0};}", this.SeatStatus);
            return sb.ToString();
        }




    }

}
