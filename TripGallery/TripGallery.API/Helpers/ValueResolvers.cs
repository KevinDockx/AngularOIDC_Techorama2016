using AutoMapper;

namespace TripGallery.API.Helpers
{
    public class InjectImageBaseForTripResolver : ValueResolver<Repository.Entities.Trip, string>
    {
        protected override string ResolveCore(Repository.Entities.Trip source)
        {
            string fullUri = "https://localhost:44315/" + source.MainPictureUri;
            return fullUri;
        }
    }

    public class RemoveImageBaseForTripResolver : ValueResolver<DTO.Trip, string>
    {
        protected override string ResolveCore(DTO.Trip source)
        {
            string partialUri = source.MainPictureUri;
            // find
            var indexOfUri = partialUri.IndexOf("https://localhost:44315/");
            if (indexOfUri > -1)
            {
                partialUri = partialUri.Substring("https://localhost:44315/".Length);
            }
           
            return partialUri;
        }
    }    
}