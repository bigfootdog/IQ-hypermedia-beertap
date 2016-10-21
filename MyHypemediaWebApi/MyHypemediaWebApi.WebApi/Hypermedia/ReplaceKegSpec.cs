using System.Runtime.Remoting.Messaging;
using System.Collections.Generic;
using MyHypemediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace MyHypemediaWebApi.WebApi.Hypermedia
{
    public class ReplaceKegSpec: SingleStateResourceSpec<ReplaceKeg, string>
    {
        public static ResourceUriTemplate UriReplaceKeg = ResourceUriTemplate.Create("ReplaceKeg({id})");


        public override string EntrypointRelation
        {
            get { return LinkRelations.ReplaceKeg; }
        }
        
        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriReplaceKeg, c => c.Id);

        }

        public override IResourceStateSpec<ReplaceKeg, NullState, string> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<ReplaceKeg, string>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.ReplaceKeg , ReplaceKegSpec.UriReplaceKeg, r => r.Id),
                      },
                      Operations = new StateSpecOperationsSource<ReplaceKeg, string>
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