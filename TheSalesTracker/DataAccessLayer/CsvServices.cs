using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    class CsvServices
    {
        #region FIELDS

        private string _dataFilePath;

        #endregion

        #region CONSTRUCTORS

        public CsvServices(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        #endregion

        #region METHODS

        public Salesperson ReadSalespersonFromDataFile()
        {
            Salesperson salesperson = new Salesperson();

            return salesperson;
        }

        #endregion
    }
}
