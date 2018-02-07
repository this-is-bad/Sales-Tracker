using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheSalesTracker
{
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

        public void WriteSalespersonToDataFile(Salesperson salespesron)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Salesperson), new XmlRootAttribute("Salesperson"));

            StreamWriter sWriter = new StreamWriter(_dataFilePath);

            using (sWriter)
            {
                serializer.Serialize(sWriter, salespesron);
            }
        }

        #endregion
    }
}
