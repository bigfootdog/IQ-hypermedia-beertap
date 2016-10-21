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
    public class ReplaceKegApiServices : IReplaceKegApiServices
    {
        readonly IApiUserProvider<MyHypemediaWebApiApiUser> _userProvider;

        public ReplaceKegApiServices(IApiUserProvider<MyHypemediaWebApiApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var id = context.UriParameters.GetByName<string>("id").EnsureValue(() => context.CreateHttpResponseException<ReplaceKeg>("The Id must be supplied in the URI",  HttpStatusCode.BadRequest));

            var replaceKeg = new ReplaceKeg(id);
            replaceKeg.ReplaceBeerKeg();
            return Task.FromResult(replaceKeg);
        }


        public Task<ReplaceKeg> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReplaceKeg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<ReplaceKeg, string>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<ReplaceKeg, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
