using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using IQ.Platform.Framework.Common;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace MyHypemediaWebApi.WebApi.Hypermedia
{
    public class OfficeStateProvider : OfficeStateProvider<Office>
    {
    }
    public abstract class OfficeStateProvider<TPlaceResource> : ResourceStateProviderBase<TPlaceResource, BeerKegState>
    where TPlaceResource : IStatefulResource<BeerKegState>, IStatefulBeerKeg
    {
        public override BeerKegState GetFor(TPlaceResource resource)
        {
            return resource.BeerKegState;
        }
        protected override IDictionary<BeerKegState, IEnumerable<BeerKegState>> GetTransitions()
        {
            return new Dictionary<BeerKegState, IEnumerable<BeerKegState>>
        {
            // from, to
            {
                BeerKegState.New, new[]
                {
                    BeerKegState.HeIsDryMate
                }
            },
        };
        }
        public override IEnumerable<BeerKegState> All
        {
            get { return EnumEx.GetValuesFor<BeerKegState>(); }
        }
    }
}