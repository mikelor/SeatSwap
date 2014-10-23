using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeatSwapWebService;

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
        public string Get(string id)
        {
            return "you requested seat" + id;
        }

        [Route("api/seats/{id}/offers")]
        public string GetOffer(string id)
        {
            return "your offer on seat" + id;
        }
    }
}
