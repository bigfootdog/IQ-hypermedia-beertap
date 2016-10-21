using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi;


namespace MyHypemediaWebApi.ApiServices
{
    public  interface IReplaceKegApiServices :
        IGetAResourceAsync<ReplaceKeg, string>,
        IGetManyOfAResourceAsync<ReplaceKeg, string>,
        ICreateAResourceAsync<ReplaceKeg, string>,
        IUpdateAResourceAsync<ReplaceKeg, string>,
        IDeleteResourceAsync<ReplaceKeg, string>
    {
    }
}
