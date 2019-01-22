using BusinessLayer.EMS;
using Mappers.EMS.DtoToDomain;
using Microsoft.AspNetCore.Mvc;
using Models.EMS.Dto.Contract;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace Controllers.EMS
{
    public class EMSController : Controller
    {
        IEMSManager _manager;
        public EMSController()
        {
            _manager = new EMSManager();
        }

        [HttpGet]
        [Route("/events")]
        [Produces("application/json")]
        public GetEventResponse GetEventsByDate([FromQuery] GetEventRequest request)
        {
            try
            {
                if (request.FromDate <= DateTime.MinValue  || request.ToDate <= DateTime.MinValue)
                {
                    throw new Exception($"invalid fromDate {request.FromDate} or toDate {request.ToDate}");
                }

                var result = _manager.GetEventDetails(request.FromDate.ToString("d"), request.ToDate.ToString("d"));
                if (result == null)
                {
                    throw new Exception($"Event details not found {HttpStatusCode.NotFound}");
                }

                var response = result.Select(x => x.ToDto()).ToList();
                return new GetEventResponse()
                {
                    Events = response
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get event details with error code : {HttpStatusCode.InternalServerError}", ex.InnerException);
            }
        }

        [HttpPost]
        [Route("/events")]
        [Produces("application/json")]
        public CreateEventResponse CreateEvent([FromBody] CreateEventRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception($"invalid request {JsonConvert.SerializeObject(request)}");
                }

                var result = _manager.CreateEvent(request.ToDomain());
                if (result == null)
                {
                    throw new Exception($"Failed to save event details  {HttpStatusCode.BadRequest}");
                }

                return new CreateEventResponse()
                {
                    EventResponse = result.ToDto()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get event details with error code : {HttpStatusCode.InternalServerError}", ex.InnerException);
            }
        }
    }
}
