using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// Product MVC Model class
    /// </summary>
    public class Product
    {
        #region FIELDS

        private int _numberOfUnits;
        private bool _onBackorder;
        private ProductType _type;
        private double _cost;

        #endregion

        #region PROPERTIES
        /// <summary>
        /// quantity of units on hand
        /// </summary>
        public int NumberOfUnits
        {
            get { return _numberOfUnits; } 
        }

        /// <summary>
        /// indicates whether inventory is on back order
        /// </summary>
        public bool OnBackorder
        {
            get { return _onBackorder; }
            set { _onBackorder = value; }
        }

        /// <summary>
        /// the type of product
        /// </summary>
        public ProductType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// the defined list of available product types
        /// </summary>
        public enum ProductType
        {
            /// <summary>default value</summary>
            None,
            /// <summary>Furry ProductType</summary>
            Furry,
            /// <summary>Spotted ProductType</summary>
            Spotted,
            /// <summary>Dancing ProductType</summary>
            Dancing
        }

        /// <summary>
        /// the product cost
        /// </summary>
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// the default constructor for the Product class
        /// </summary>
        public Product()
        {
            
        }

        /// <summary>
        /// overloaded constructor for the Product class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numberOfUnits"></param>
        public Product(ProductType type, int numberOfUnits)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
        }

        /// <summary>
        /// overloaded constructor for the Product class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numberOfUnits"></param>
        /// <param name="onBackorder"></param>
        public Product(ProductType type, int numberOfUnits, bool onBackorder)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
            _onBackorder = onBackorder;
        }

        /// <summary>
        /// overloaded constructor for the Product class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="numberOfUnits"></param>
        /// <param name="onBackorder"></param>
        /// <param name="cost"></param>
        public Product(ProductType type, int numberOfUnits, bool onBackorder, double cost)
        {
            _type = type;
            _numberOfUnits = numberOfUnits;
            _onBackorder = onBackorder;
            _cost = cost;
        }

        #endregion

        #region METHODS
        /// <summary>
        /// add a value to the numberOfUnits
        /// </summary>
        /// <param name="unitsToAdd"></param>
        public void AddProducts(int unitsToAdd)
        {

            if (_numberOfUnits > unitsToAdd)
            {
                _onBackorder = false;
            }

            _numberOfUnits += unitsToAdd;

        }

        /// <summary>
        /// subtract a value from the numberOfUnits
        /// </summary>
        /// <param name="unitsToSubtract"></param>
        public void SubtractProducts(int unitsToSubtract)
        {
            if (_numberOfUnits < unitsToSubtract)
            {
                _onBackorder = true;
            }

            _numberOfUnits -= unitsToSubtract;
        }

        #endregion
    }
}
