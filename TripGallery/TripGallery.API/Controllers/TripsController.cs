using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TripGallery.API.Helpers;
using TripGallery.API.UnitOfWork.Trip;

namespace TripGallery.API.Controllers
{
    [EnableCors("https://localhost:44316", "*", "GET, POST, PATCH")]
    [Authorize]
    public class TripsController : ApiController
    {
        // anyone can get trips
        [Route("api/trips")]
        [HttpGet]
        public IHttpActionResult Get()
        {   
            string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

            using (var uow = new GetTrips(ownerId))
            {
                var uowResult = uow.Execute();

                switch (uowResult.Status)
                {
                    case UnitOfWork.UnitOfWorkStatus.Ok:
                        return Ok(uowResult.Result);
                    default:
                        return InternalServerError();
                }
            }
        }   
     
        [Route("api/trips")]
        [HttpPost]
        [Authorize(Roles="PayingUser")]
        public IHttpActionResult Post([FromBody]DTO.TripForCreation tripForCreation)
        {           
            string ownerId = TokenIdentityHelper.GetOwnerIdFromToken();

            using (var uow = new CreateTrip(ownerId))
            {
                var uowResult = uow.Execute(tripForCreation);

                switch (uowResult.Status)
                {
                    case UnitOfWork.UnitOfWorkStatus.Ok:
                        return Created<DTO.Trip>
                        (Request.RequestUri + "/" + uowResult.Result.Id.ToString(), uowResult.Result);
                    case UnitOfWork.UnitOfWorkStatus.Forbidden:
                        return StatusCode(HttpStatusCode.Forbidden);
                    case UnitOfWork.UnitOfWorkStatus.Invalid:
                        return BadRequest();
                    default:
                        return InternalServerError();
                }
            }
        }         
    }
}