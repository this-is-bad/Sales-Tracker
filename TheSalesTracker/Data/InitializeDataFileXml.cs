using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// Data connection class, XML
    /// </summary>
    public class InitializeDataFileXml
    {
        #region METHODS

        /// <summary>
        /// create a dummy Salesperson 
        /// </summary>
        /// <returns>Salesperson</returns>
        private static Salesperson InitializeSalesperson()
        {
            Salesperson salesperson = new Salesperson()
            {
                FirstName = "Charles",
                LastName = "Koop",
                CurrentStock = new Product(Product.ProductType.Spotted, 20, false),
                CitiesVisited = new List<string>()
                {
                    "Detroit",
                    "Grand Rapids",
                    "Traverse City"
                }
            };

            return salesperson;
        }

        /// <summary> 
        /// save a dummy Salesperson to the persistent data file
        /// </summary>
        public static void SeedDataFile()
        {
            XmlServices xmlService = new XmlServices(DataSettings.dataFilePathXml);

            xmlService.WriteSalespersonToDataFile(InitializeSalesperson());
        }

        #endregion
    }
}
