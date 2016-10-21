using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Microsoft.SqlServer.Server;


namespace MyHypemediaWebApi.Model
{
    public interface IOffice
    {
        /// <summary>
        ///  Returns the list of all Offices with the corresponding status of the beer Keg
        /// </summary>
        /// <returns></returns>
        List<Office> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Office GetInfo(int? id);
    }

    //public class Office: IStatefulResource<PlaceState>, IIdentifiable<string>, IStatefulPlace
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Office : BeerTap, IStatefulResource<BeerKegState>, IIdentifiable<string>, IOffice
    {

        /// <summary>
        /// Returns the list of all Offices with the corresponding status of the beer Keg
        /// </summary>
        /// <returns></returns>
        public List<Office> GetAll()
        {
            var result = new List<Office>();

            using (var context = new IQOfficeBeerInventoryEntities())
            {

                var data = from t in context.OfficeBeerInventories select t;

                foreach (var item in data)
                {
                    var office = new Office()
                    {
                        Id = item.Id.ToString(),
                        Name = item.OfficeLocation,
                        BeerKegCurrentContent = item.BeerKegCurrentContent
                    };

                    office.UpdateBeerKegState();

                    result.Add(office);

                }
            }
            return result;
        }

        /// <summary>
        /// Used to pull all the information of an Office.
        /// </summary>
        /// <returns></returns>
        public Office GetInfo(int? id)
        {
            var result = new Office();

            id = id ?? Int32.Parse(this.Id);

            using (var context = new IQOfficeBeerInventoryEntities())
            {
                var data = context.OfficeBeerInventories.SingleOrDefault(b => b.Id == id);

                if (data != null)
                {
                    result = new Office()
                    {
                        Id = id.ToString(),
                        Name = data.OfficeLocation,
                        BeerKegCurrentContent = data.BeerKegCurrentContent
                    };

                    result.UpdateBeerKegState();
                }
                else
                {
                    result = new Office() { Id = id.ToString(), Name = "", BeerKegCurrentContent = 0 };

                }
            }
            return result;
        }
    }

}
