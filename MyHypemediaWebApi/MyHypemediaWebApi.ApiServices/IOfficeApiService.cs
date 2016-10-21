using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace MyHypemediaWebApi.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, string>,
        IGetManyOfAResourceAsync<Office, string>,
        ICreateAResourceAsync<Office, string>,
        IUpdateAResourceAsync<Office, string>,
        IDeleteResourceAsync<Office, string>
    {
    }
}
