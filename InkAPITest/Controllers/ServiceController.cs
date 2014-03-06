using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InkAPITest.Models;
using InkAPITest.Ink;
using System.Web.Script.Serialization;

namespace InkAPITest.Controllers
{
    public class ServiceController : ApiController
    {
        // GET api/service
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/service/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/service
        public void Post([FromBody]string value)
        {
        }


        // POST api/service
        public string PostFlight(FlightRequest req)
        {
            BookingClient bk = new BookingClient();
            AvailabilityRequest ar = new AvailabilityRequest();         
            ar.DepartureDate = req.DepartureDate;
            ar.ReturnDate = req.ReturnDate;
            ar.Destination =req.Destination;
            ar.Origin = req.Origin;
            AvailabilityResponse TAr = bk.GetAvailability(ar);
            var inbound = TAr.InboundJourneys.Select(m => new { DepartureStation = m.DepartureStation.Name, m.DepartureTime, ArrivalStation = m.ArrivalStation.Name, m.ArrivalTime }).ToList();
            var outBound = TAr.OutoundJourneys.Select(m => new { DepartureStation = m.DepartureStation.Name, m.DepartureTime, ArrivalStation = m.ArrivalStation.Name, m.ArrivalTime }).ToList();
            var result = inbound.Concat(outBound);
            var jvs = new JavaScriptSerializer();
            string jsondata = jvs.Serialize(result);
            return jsondata;
        }


        // PUT api/service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/service/5
        public void Delete(int id)
        {
        }
    }
}
