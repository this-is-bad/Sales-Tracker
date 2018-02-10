using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheSalesTracker
{
    /// <summary>
    /// class for managing read/write operations to a persistent data file
    /// </summary>
    class XmlServices
    {
        #region FIELDS

        private string _dataFilePath;

        #endregion

        #region CONSTRUCTORS

        public XmlServices(string dataFilePath)
        {
            _dataFilePath = dataFilePath;
        }

        #endregion

        #region METHODS
        /// <summary>
        /// retrieve a Salesperson from the persistent data file
        /// </summary>
        /// <returns>Salesperson</returns>
        public Salesperson ReadSalespersonFromDataFile()
        {
            Salesperson salesperson = new Salesperson();

            // initialize a FileStream object for reading
            StreamReader sReader = new StreamReader(_dataFilePath);

            // initialize an XML serializer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Salesperson));

            using (sReader)
            {
                object xmlObject = deserializer.Deserialize(sReader);
                Console.WriteLine(xmlObject);
                salesperson = (Salesperson)xmlObject;
            }

            return salesperson;
        }

        /// <summary>
        /// save a Salesperson to the persistent data file
        /// </summary>
        /// <param name="salesperson"></param>
        public void WriteSalespersonToDataFile(Salesperson salesperson)
        {
            if (salesperson.FirstName == null & salesperson.LastName == null)
            {
                InitializeDataFileXml.SeedDataFile();
            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Salesperson), new XmlRootAttribute("Salesperson"));

                StreamWriter sWriter = new StreamWriter(_dataFilePath);

                using (sWriter)
                {
                    serializer.Serialize(sWriter, salesperson);
                }
            }
        }

        #endregion
    }
}
