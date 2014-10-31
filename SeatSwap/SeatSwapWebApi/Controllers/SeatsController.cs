using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeatSwapWebService;
using Twilio;

namespace SeatSwapWebApi.Controllers
{
    public class SeatsController : ApiController
    {
        // Get api/seats
        public IEnumerable<Seat> Get()
        {
            SeatSwapWebService.SeatCollection.Initialize();
            return SeatSwapWebService.SeatCollection.Seats;
        }

        // Get api/seats/14a
        [ActionName("DefaultApi")]
        public Seat Get(string id)
        {
            Seat yourSeat = null;
            SeatSwapWebService.SeatCollection.Initialize();
            List<Seat> seats = SeatCollection.Seats;
            foreach(Seat seat in seats)
            {
                if(seat.SeatId.ToLower().Equals(id.ToLower()))
                {
                    yourSeat = seat;
                    break;
                }
            }
            return yourSeat;
        }

        [Route("api/seats/{id}/offers")]
        public string GetOffer(string id)
        {
            return "your offer on seat" + id;
        }

        [Route("api/seats/{id}/bid")]
        public void GetBid(string id)
        {
            string AccountSid = "AC4570e6b0b210cf295101b6fb82ae623d";
            string AuthToken = "315d68d84e41a1c2e35c510cd32a557c";
            string AcctFromPhone = "+19073122887";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);


            var msg = twilio.SendMessage(AcctFromPhone, "+12063030802", "Your seat has been swapped");
            if (msg.RestException != null)
            {
                throw new Exception(msg.RestException.Message);
            }
        }

            
            /*
            // Create a connection string for the master database
            SqlConnectionStringBuilder connString1Builder;
            connString1Builder = new SqlConnectionStringBuilder();
            connString1Builder.DataSource = "tcp:iskdpcbkcx.database.windows.net,1433";
            connString1Builder.InitialCatalog = "seatswap";
            connString1Builder.Encrypt = true;
            connString1Builder.TrustServerCertificate = false;
            connString1Builder.UserID = "seatswapapi";
            connString1Builder.Password = "s3atsw@p";   
    
            // Connect to the master database and create the sample database
            using (SqlConnection conn = new SqlConnection(connString1Builder.ToString()))
            {
                using (SqlCommand command = conn.CreateCommand())
                {

                    conn.Open();

                    // Create the sample database
                    string cmdText = "Select * from Seats;";
                    command.CommandText = cmdText;
                    command.ExecuteReader();
                    conn.Close();
                }
            }
            return "bids";
        }
        */

        
    }
}
