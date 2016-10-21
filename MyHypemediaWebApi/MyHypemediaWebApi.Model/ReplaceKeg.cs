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
    public class ReplaceKeg : BeerTap, IStatelessResource, IIdentifiable<string>
    {
        /// <summary>
        /// Constructor for ReplaceKeg
        /// </summary>
        /// <param name="id"></param>
        public ReplaceKeg(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReplaceBeerKeg()
        {
            var beerKegContent = int.Parse(ConfigurationManager.AppSettings["beerKegContent"]);

            using (var context = new IQOfficeBeerInventoryEntities())
            {
                var officeId = Int32.Parse(this.Id);
                var data = context.OfficeBeerInventories.SingleOrDefault(b => b.Id == officeId);

                if (data != null)
                {
                    data.BeerKegCurrentContent = beerKegContent;
                    context.SaveChanges();

                    this.Name = data.OfficeLocation;
                    this.BeerKegCurrentContent = beerKegContent;
                    this.UpdateBeerKegState();
                }
            }

        }
    }
}
