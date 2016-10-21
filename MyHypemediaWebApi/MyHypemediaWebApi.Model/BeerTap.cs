using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyHypemediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public enum BeerKegState
    {
        /// <summary>
        /// 
        /// </summary>
        New,
        /// <summary>
        /// 
        /// </summary>
        GoingDown,
        /// <summary>
        /// 
        /// </summary>
        AlmostEmpty,
        /// <summary>
        /// 
        /// </summary>
        HeIsDryMate

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IStatefulBeerKeg
    {
        /// <summary>
        /// 
        /// </summary>
        BeerKegState BeerKegState { get; set; }

    }

    
    /// <summary>
    /// This class contains all information of an Office's current beer content.
    /// </summary>
    public class BeerTap : IStatefulBeerKeg
    {
        /// <summary>
        /// Unique Identifier for the Office
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name for the Office
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BeerKegState BeerKegState { get; set; }

        /// <summary>
        /// Current beer content  (ml)
        /// </summary>
        public int BeerKegCurrentContent { get; set; }

        /// <summary>
        /// Indicator if it's advisable that the Keg should be immediately replaced
        /// </summary>
        public bool ReplaceKeg
        {
            get;
            set;


        }


        /// <summary>
        /// Used to provide the status of the remaining Beer content of an office
        /// </summary>
        public void UpdateBeerKegState()
        {
            var beerKegContent = int.Parse(ConfigurationManager.AppSettings["beerKegContent"]);
            var beerGlassContent = int.Parse(ConfigurationManager.AppSettings["beerGlassContent"]);

            if (this.BeerKegCurrentContent < beerGlassContent)
            {
                this.BeerKegState = BeerKegState.HeIsDryMate;
            }
            else if (this.BeerKegCurrentContent <= (2 * beerGlassContent))
            {
                this.BeerKegState = BeerKegState.AlmostEmpty;
            }
            else if (this.BeerKegCurrentContent < beerKegContent)
            {
                this.BeerKegState = BeerKegState.GoingDown;
            }
            else
            {
                this.BeerKegState = BeerKegState.New;
            }

            this.ReplaceKeg = (this.BeerKegState == BeerKegState.AlmostEmpty ||
                      this.BeerKegState == BeerKegState.HeIsDryMate);

        }

    }
}
