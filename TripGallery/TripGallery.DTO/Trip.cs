using System;

namespace TripGallery.DTO
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainPictureUri { get; set; }
        public bool IsPublic { get;set;}
        public string OwnerId { get; set; }

        public Trip()
        {          
        }
    }
}
