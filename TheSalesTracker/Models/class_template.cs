using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{

    public class class_template
    {
        #region FIELDS

        private bool _property1;
        private int _property2;
        private string _property3;
        private List<string> _property4;
        private decimal _property5;


        #endregion

        #region PROPERTIES

        public bool Property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }

        public int Property2
        {
            get { return _property2; }
            set { _property2 = value; }
        }

        public string Property3
        {
            get { return _property3; }
            set { _property3 = value; }
        }

        public List<string> Property4
        {
            get { return _property4; }
            set { _property4 = value; }
        }

        public decimal Property5
        {
            get { return _property5; }
            set { _property5 = value; }
        }


        #endregion

        #region CONSTRUCTORS

        public class_template()
        {
           
        }

        #endregion

        #region METHODS

        /// <summary>
        ///  
        /// </summary>
        private void MethodOne()
        {
            
        }

        #endregion
    }
}
