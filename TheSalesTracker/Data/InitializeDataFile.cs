using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// Data connection class
    /// </summary>
    class InitializeDataFile
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

        public void seedDataFile(string fileType)
        {
            //if(fileType.ToLower() == "csv")
            //{
            //    CsvServices csvService = new CsvServices(DataSettings.dataFilePathCsv);

            //    csvService.WriteSalespersonToDataFile(InitializeSalesperson());
            //}

            if (fileType.ToLower() == "xml")
            {

                XmlServices xmlServices = new XmlServices(DataSettings.dataFilePathXml);

                xmlServices.WriteSalespersonToDataFile(InitializeSalesperson());

                
            }
        }

        #endregion
    }
}
