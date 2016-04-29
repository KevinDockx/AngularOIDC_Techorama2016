using AutoMapper;
using IdentityServer3.AccessTokenValidation;
using Owin;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using TripGallery.API.Helpers;

namespace TripGallery.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = WebApiConfig.Register();

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(
             new IdentityServerBearerTokenAuthenticationOptions
             {
                 Authority = "https://localhost:44317/identity",
                 RequiredScopes = new[] { "gallerymanagement" }
             });

            app.UseWebApi(config);

            InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            Mapper.CreateMap<Repository.Entities.Trip,
                DTO.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(InjectImageBaseForTripResolver)));

            Mapper.CreateMap<DTO.Trip,
                Repository.Entities.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(RemoveImageBaseForTripResolver))); ;

            Mapper.CreateMap<DTO.TripForCreation,
                Repository.Entities.Trip>()
                    .ForMember(o => o.Id, o => o.Ignore())
                    .ForMember(o => o.MainPictureUri, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore());

            Mapper.AssertConfigurationIsValid();
        }
    }
}
