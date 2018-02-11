using System.Collections.Generic;

namespace TheSalesTracker
{
    /// <summary>
    /// Salesperson MVC Model class
    /// </summary>
    public class Salesperson
    {
        #region FIELDS

        private string _firstName;
        private string _lastName;
        private string _accountID;
        private List<string> _citiesVisited;
        private Product _currentStock;
        
        #endregion
        
        #region PROPERTIES

        /// <summary>
        /// Salesperson first name
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Salesperson last name
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Salesperson account ID
        /// </summary>
        public string AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }
      
        /// <summary>
        /// Salesperson list of cities visited
        /// </summary>
        public List<string> CitiesVisited
        {
            get { return _citiesVisited; }
            set { _citiesVisited = value; }
        }

        /// <summary>
        /// Salesperson product
        /// </summary>
        public Product CurrentStock
        {
            get { return _currentStock; }
            set { _currentStock = value; }
        }
        #endregion
        
        #region CONSTRUCTORS
        /// <summary>
        /// default constructor for 
        /// </summary>
        public Salesperson()
        {
            _citiesVisited = new List<string>();
            _currentStock = new Product();
        }

        /// <summary>
        /// overloaded constructor for Salesperson
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="acountID"></param>
        public Salesperson(string firstName, string lastName, string acountID)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountID = acountID;

            _citiesVisited = new List<string>();
            _currentStock = new Product();
        }

        /// <summary>
        /// overloaded constructor for Salesperson
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="acountID"></param>
        /// <param name="citiesVisited"></param>
        public Salesperson(string firstName, string lastName, string acountID, List<string> citiesVisited)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountID = acountID;

            _citiesVisited = citiesVisited;
            _currentStock = new Product();
        }

        /// <summary>
        /// overloaded constructor for Salesperson
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="acountID"></param>
        /// <param name="citiesVisited"></param>
        /// <param name="currentStock"></param>
        public Salesperson(string firstName, string lastName, string acountID, List<string> citiesVisited, Product currentStock)
        {
            _firstName = firstName;
            _lastName = lastName;
            _accountID = acountID;
            _citiesVisited = citiesVisited;
            _currentStock = currentStock;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
