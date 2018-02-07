using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// Data connection class, CSV
    /// </summary>
    class InitializeDataFileCsv
    {
        #region METHODS

        private Salesperson InitializeSalesperson()
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

        public void seedDataFile()
        {
            //CsvServices csvService = new CsvServices(DataSettings.dataFilePathCsv);

            //csvService.WriteSalespersonToDataFile(InitializeSalesperson());
        }

        #endregion
    }
}
