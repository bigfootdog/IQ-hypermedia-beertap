using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyHypemediaWebApi.ApiServices.Security;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace MyHypemediaWebApi.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<MyHypemediaWebApiApiUser> _userProvider;

        public OfficeApiService(IApiUserProvider<MyHypemediaWebApiApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }


        public Task<Office> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            var result = new Office().GetInfo(Int32.Parse(id));

            return Task.FromResult(result);

        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var result = new Office().GetAll();

            return Task.FromResult(result.AsEnumerable());
        }

        public Task<ResourceCreationResult<Office, string>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
