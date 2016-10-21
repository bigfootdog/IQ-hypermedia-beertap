using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace MyHypemediaWebApi.WebApi.Hypermedia
{

    public class OfficeSpec : ResourceSpec<Office, BeerKegState, string>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }



        protected override IEnumerable<IResourceStateSpec<Office, BeerKegState, string>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Office, BeerKegState, string>(BeerKegState.New)
            {
                Links =
                {
                   CreateLinkTemplate(LinkRelations.GlassOfBeer, GlassOfBeerSpec.UriGlassOfBeer, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Office, string>()
                {
                    Get = ServiceOperations.Get
                }
            };

            yield return new ResourceStateSpec<Office, BeerKegState, string>(BeerKegState.AlmostEmpty)
            {
                Links =
                {
                   CreateLinkTemplate(LinkRelations.ReplaceKeg, GlassOfBeerSpec.UriGlassOfBeer, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Office, string>()
                {
                    Get = ServiceOperations.Get
                }
            };
            yield return new ResourceStateSpec<Office, BeerKegState, string>(BeerKegState.GoingDown)
            {
                Links =
                {
                   CreateLinkTemplate(LinkRelations.GlassOfBeer, GlassOfBeerSpec.UriGlassOfBeer, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Office, string>()
                {
                    Get = ServiceOperations.Get
                }
            };
            yield return new ResourceStateSpec<Office, BeerKegState, string>(BeerKegState.HeIsDryMate)
            {
                Links =
                {
                   CreateLinkTemplate(LinkRelations.ReplaceKeg, ReplaceKegSpec.UriReplaceKeg, c => c.Id)
                },
                Operations = new StateSpecOperationsSource<Office, string>()
                {
                    Get = ServiceOperations.Get
                }
            };
            //yield return new ResourceStateSpec<Office, PlaceState, string>(PlaceState.Full)
            //{
            //    Links =
            //    {
            //        CreateLinkTemplate(LinkRelations.Places.RemovePeople, BeerTapSpec.UriBeerTapAtOffice.Many, c => c.Id)
            //    },
            //    Operations =
            //    {
            //        Delete = ServiceOperations.Delete,
            //    }
            //};
        }

    }

}