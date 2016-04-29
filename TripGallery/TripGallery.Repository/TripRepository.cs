using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripGallery.Repository.Entities;

namespace TripGallery.Repository
{
    public class TripRepository : ITripRepository, IDisposable
    {
        TripContext _ctx;

        public TripRepository(TripContext tripContext)
        {
            _ctx = tripContext;
        }


        public bool TripExists(Guid tripId)
        {
            return _ctx.Trips.Any(t => t.Id == tripId);
        }

        public bool CanGetTrip(Guid tripId, string ownerId)
        {
            return _ctx.Trips.Any(t => t.Id == tripId && (t.IsPublic || t.OwnerId == ownerId));
        }
           
        public IQueryable<Trip> GetTrips()
        {
            return _ctx.Trips.AsQueryable();
        }
        
        public IQueryable<Trip> GetTrips(string ownerId)
        {
            var trips = _ctx.Trips.Where(t => t.OwnerId == ownerId || t.IsPublic);
            return trips.AsQueryable();          
        }
        
        public Trip GetTrip(Guid id)
        {
            var trip = _ctx.Trips.FirstOrDefault(t => t.Id == id);
            return trip;

        }

        public void InsertTrip(Trip trip)
        {
            _ctx.Trips.Add(trip);
        }

        public void UpdateTrip(Trip trip)
        {
            // no code required
        }

        public bool DeleteTrip(Guid tripId)
        {
            var trip = _ctx.Trips.FirstOrDefault(t => t.Id == tripId);

            if (trip != null)
            {
                _ctx.Trips.Remove(trip);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_ctx != null)
                {
                    _ctx.Dispose();
                    _ctx = null;
                }
            }
        }
    }
}
