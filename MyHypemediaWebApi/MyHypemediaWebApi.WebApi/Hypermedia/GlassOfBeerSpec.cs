using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace MyHypemediaWebApi.WebApi.Hypermedia
{
    public class GlassOfBeerSpec: SingleStateResourceSpec<GlassOfBeer, string>
    {
        public static ResourceUriTemplate UriGlassOfBeer = ResourceUriTemplate.Create("GetOneGlassOfBeer({id})");


        public override string EntrypointRelation
        {
            get { return LinkRelations.GlassOfBeer; }
        }
        
        protected override IEnumerable<ResourceLinkTemplate<GlassOfBeer>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriGlassOfBeer, c => c.Id);

        }

        public override IResourceStateSpec<GlassOfBeer, NullState, string> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<GlassOfBeer, string>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.GlassOfBeer , GlassOfBeerSpec.UriGlassOfBeer, r => r.Id),
                      },
                      Operations = new StateSpecOperationsSource<GlassOfBeer, string>
                      {
                          Get = ServiceOperations.Get,
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update,
                          Delete = ServiceOperations.Delete,
                      },
                  };
            }
        }
    }
}