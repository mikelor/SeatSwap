using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheriTestApp;
//using Xamarin.Forms;

namespace SheriTestApp
{
    class SeatPage //: ContentView
    {
        public List<Seat> getAllSeats()
        {
            List<Seat> allseats = new List<Seat>();
            for (int i = 6; i < 32; i++)
            {
                for (int ii = 0; ii <= 5; ii++)
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
            foreach(Seat seat in allseats)
            {
                switch (seat.SeatId)
                {
                    case "7A":
                    case "8B":
                    case "15F":
                        seat.SeatStatus = SeatInfo.STATUS_AVAILABLE;
                        break;

                    case "9E":
                    case "22E":
                    case "18B":
                    case "11D":
                    case "6A":
                    case "9C":
                    case "10D":
                    case "11F":
                        seat.SeatStatus = SeatInfo.STATUS_OFFERED;
                        break;

                    case "19B":
                        seat.SeatStatus = SeatInfo.STATUS_MINE;
                        break;

                    default:
                        seat.SeatStatus = SeatInfo.STATUS_OCCUPIED;
                        break;
                }
            }
            
            return allseats;

        }

        public class SeatInfo
        {
            public const int STATUS_AVAILABLE = 0;
            public const int STATUS_OCCUPIED = 1;
            public const int STATUS_OFFERED = 2;
            public const int STATUS_MINE = 3;

            public SeatInfo()
            {
                SeatId = String.Empty;
                SeatStatus = Seat.STATUS_OCCUPIED;
                SeatPassenger = new Passenger();
            }
            public SeatInfo(string _seatid)
            {
                SeatId = _seatid;
                SeatStatus = Seat.STATUS_OCCUPIED;
            }
            public SeatInfo(string _seatid, int _seatstatus)
            {
                SeatId = _seatid;
                SeatStatus = _seatstatus;
            }
            public SeatInfo(string _seatid, int _seatstatus, string _passengerid)
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
                sb.AppendFormat("SeatId: {0}{1}", this.SeatId, NL);
                sb.AppendFormat("SeatStatus: {0}", this.SeatStatus, NL);
                return sb.ToString();
            }

        }
    }
}