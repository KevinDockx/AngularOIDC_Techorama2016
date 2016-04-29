using System;
using System.Linq;
using TripGallery.Repository.Entities;

namespace TripGallery.Repository
{
    public interface ITripRepository
    {
        bool TripExists(Guid tripId);
        bool CanGetTrip(Guid tripId, string ownerId);
        IQueryable<Trip> GetTrips();
        IQueryable<Trip> GetTrips(string ownerId);
        Trip GetTrip(Guid id);
        void InsertTrip(Trip trip);
        void UpdateTrip(Trip trip);
        bool DeleteTrip(Guid tripId);
        
        void Dispose();
    }
}
