using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SeatSwapWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SeatSwap" in code, svc and config file together.
    public class SeatSwap : ISeatSwap
    {


        public List<Seat> Seats()
        {

            SeatSwapWebService.SeatCollection.Initialize();
            return SeatSwapWebService.SeatCollection.Seats;

        }

        public string Seat(string id)
        {
            return "You requested seat " + id;
        }


        public string SeatOffer(string id)
        {
            return "You offered seat " + id;
        }

        public string SeatBid(string id)
        {
            return "You bid on seat " + id;
        }
    }
}
