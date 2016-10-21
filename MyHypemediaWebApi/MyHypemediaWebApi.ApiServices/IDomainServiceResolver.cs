using System;
using MyHypemediaWebApi.Services;

namespace MyHypemediaWebApi.ApiServices
{
    public interface IDomainServiceResolver
    {
        IDomainService Resolve(Type requestedServiceType);

        TService Resolve<TService>()
            where TService : IDomainService;
    }
}

namespace MyHypemediaWebApi.Services
{
    /// <summary> 
    /// Represents a specific domain service / repository used in IApiApplicationService implementations 
    /// </summary> 
    public interface IDomainService
    {
    }
}
