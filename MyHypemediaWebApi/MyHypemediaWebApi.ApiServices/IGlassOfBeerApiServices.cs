using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi;


namespace MyHypemediaWebApi.ApiServices
{
    public  interface IGlassOfBeerApiServices :
        IGetAResourceAsync<GlassOfBeer, string>,
        IGetManyOfAResourceAsync<GlassOfBeer, string>,
        ICreateAResourceAsync<GlassOfBeer, string>,
        IUpdateAResourceAsync<GlassOfBeer, string>,
        IDeleteResourceAsync<GlassOfBeer, string>
    {
    }
}
