using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyHypemediaWebApi.ApiServices.Security;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace MyHypemediaWebApi.ApiServices
{
    public class GlassOfBeerApiServices : IGlassOfBeerApiServices
    {
        readonly IApiUserProvider<MyHypemediaWebApiApiUser> _userProvider;

        public GlassOfBeerApiServices(IApiUserProvider<MyHypemediaWebApiApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<GlassOfBeer> UpdateAsync(GlassOfBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            var id = context.UriParameters.GetByName<string>("id").EnsureValue(() => context.CreateHttpResponseException<GlassOfBeer>("The Id must be supplied in the URI", HttpStatusCode.BadRequest));

            var glassOfBeer = new GlassOfBeer(id);
            glassOfBeer.PourOneGlass();

            return Task.FromResult(glassOfBeer);
        }


        public Task<GlassOfBeer> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GlassOfBeer>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<GlassOfBeer, string>> CreateAsync(GlassOfBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<GlassOfBeer, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
