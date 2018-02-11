using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// MVC Controller class
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private bool _usingApplication;
        private Salesperson _salesperson;
        private ConsoleView _consoleView;
        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        // Note: There is no need for a Salesperson or ConsoleView property given only the Controller 
        //       will access the ConsoleView object and will pass the Salesperson object to the ConsoleView.
        //


        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// constructor for the controller class
        /// </summary>
        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleView = new ConsoleView();

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuChoice;

            _consoleView.DisplayWelcomeScreen();
            
            //
            //
            // application loop
            //
            while (_usingApplication)
            {
                //
                // get a menu choice from the user
                //
                userMenuChoice = _consoleView.DisplayGetUserMenuChoice();

                //
                // choose an action based on the user menu choice
                //
                switch (userMenuChoice)
                {
                    case MenuOption.None:
                        {
                            break;
                        }
                    case MenuOption.SetupAccount:
                        {
                            SetupAccount();
                            break;
                        }
                    case MenuOption.SetupProduct:
                        {
                            SetupProduct();
                            break;
                        }
                    case MenuOption.Travel:
                        {
                            Travel();
                            break;
                        }
                    case MenuOption.Buy:
                        {
                            Buy();
                            break;                        
                        }
                    case MenuOption.Sell:
                        {
                            Sell();
                            break;
                        }
                    case MenuOption.DisplayInventory:
                        {
                            DisplayInventory();
                            break;
                        }
                    case MenuOption.DisplayCities:
                        {
                            DisplayCities();
                            break;
                        }
                    case MenuOption.DisplayAccountInfo:
                        {
                            DisplayAccountInfo();
                            break;
                        }
                    case MenuOption.SaveAccountInfo:
                        {
                            DisplaySaveAccountInfo();
                            break;
                        }
                    case MenuOption.LoadAccountInfo:
                        {
                            DisplayLoadAccountInfo();
                            break;
                        }
                    case MenuOption.Exit:
                        {
                           _consoleView.DisplayExitPrompt();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            // close the application
            //
            Environment.Exit(1);
        }


        // <summary>
        // setup initial salesperson account
        // </summary>
        private void SetupAccount()
        {
            _salesperson = _consoleView.DisplaySetupAccount();
        }
        
        /// <summary>
        /// setup the product
        /// </summary>
        private void SetupProduct()
        {
            _consoleView.DisplayProductUserSelection(_salesperson);
        }

        /// <summary>
        /// calls the ConsoleView.DisplayGetNumberOfUnitsToBuy method and the AddProduct method if a valid integer is returned
        /// </summary>
        private void Buy()
        {
            int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToBuy(_salesperson.CurrentStock);
            _salesperson.CurrentStock.AddProducts(numberOfUnits);
        }

        /// <summary>
        /// calls the ConsoleView.DisplayGetNumberOfUnitsToSell method and the SubtractProduct method if a valid integer is returned
        /// </summary>
        private void Sell()        
        {
            if (_salesperson.CurrentStock != null)
            {
                int numberOfUnits = _consoleView.DisplayGetNumberOfUnitsToSell(_salesperson.CurrentStock);
                _salesperson.CurrentStock.SubtractProducts(numberOfUnits);

                if (_salesperson.CurrentStock.OnBackorder)
                {
                    _consoleView.DisplayBackOrderNotification(_salesperson.CurrentStock, numberOfUnits);
                }
            }
            else
            {
                _consoleView.DisplayObjectError("product");
            }
        }

        /// <summary>
        /// display current inventory
        /// </summary>
        private void DisplayInventory()
        {
            _consoleView.DisplayInventory(_salesperson.CurrentStock);
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        private void Travel()
        {
            string nextCity = _consoleView.DisplayGetNextCity(_salesperson);
            _salesperson.CitiesVisited.Add(nextCity);
        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {
            _consoleView.DisplayCitiesTraveled(_salesperson);
        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {
            _consoleView.DisplayAccountInfo(_salesperson);
        }

        /// <summary>
        /// save account information
        /// </summary>
        private void DisplaySaveAccountInfo()
        {
            bool maxAttemptsExceeded =  false;
            bool saveAccountInfo = false;

            saveAccountInfo = _consoleView.DisplaySaveAccountInfo(_salesperson, out maxAttemptsExceeded);
            
            if (saveAccountInfo && !maxAttemptsExceeded)
            {
                XmlServices xmlServices = new XmlServices(DataSettings.dataFilePathXml);

                xmlServices.WriteSalespersonToDataFile(_salesperson);

                _consoleView.DisplayConfirmSaveAccountInfo();
            }
        }

        /// <summary>
        /// load account information
        /// </summary>
        private void DisplayLoadAccountInfo()
        {
            bool maxAttemptsExceeded = false;
            bool loadAccountInfo = false;

            //
            // note: rather than pass null value, method is overloaded
            //
            if (_salesperson.AccountID != "")
            {
                loadAccountInfo = _consoleView.DisplayLoadAccountInfo(_salesperson, out maxAttemptsExceeded);
            }
            else
            {
                loadAccountInfo = _consoleView.DisplayLoadAccountInfo(out maxAttemptsExceeded);
            }
            if (loadAccountInfo && !maxAttemptsExceeded)
            {
                XmlServices xmlServices = new XmlServices(DataSettings.dataFilePathXml);

                _salesperson = xmlServices.ReadSalespersonFromDataFile();

                _consoleView.DisplayConfirmLoadAccountInfo(_salesperson);
            }
        }
        #endregion
    }
}
