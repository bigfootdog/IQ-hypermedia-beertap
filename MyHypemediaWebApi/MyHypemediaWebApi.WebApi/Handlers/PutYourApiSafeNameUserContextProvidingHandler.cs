using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using MyHypemediaWebApi.ApiServices.Security;

namespace MyHypemediaWebApi.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<MyHypemediaWebApiApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<MyHypemediaWebApiApiUser> apiUserInRequestStore)
            : base(new MyHypemediaWebApiUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<MyHypemediaWebApiApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<MyHypemediaWebApiApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}