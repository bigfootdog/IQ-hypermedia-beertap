using System;
using System.Linq;
using System.Configuration;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace MyHypemediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class GlassOfBeer : BeerTap, IStatelessResource, IIdentifiable<string>
    {
        /// <summary>
        /// Constructor for ReplaceKeg
        /// </summary>
        /// <param name="id"></param>
        public GlassOfBeer(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Used to update the content of the Keg
        /// </summary>
        /// <returns></returns>
        public void PourOneGlass()
        {
            var beerGlassContent = int.Parse(ConfigurationManager.AppSettings["beerGlassContent"]);
  
            using (var context = new IQOfficeBeerInventoryEntities())
            {
                var officeId = Int32.Parse(this.Id);
                var data = context.OfficeBeerInventories.SingleOrDefault(b => b.Id == officeId);

                if (data != null)
                {
                    var remainingContent = data.BeerKegCurrentContent;

                    if (remainingContent > 0)
                    {
                        remainingContent -= beerGlassContent;

                        data.BeerKegCurrentContent = remainingContent;
                        context.SaveChanges();
                    }

                    this.Name = data.OfficeLocation;
                    this.BeerKegCurrentContent = remainingContent;
                    this.UpdateBeerKegState();
                }
            }

        }
    }
}
