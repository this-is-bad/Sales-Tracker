﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalesTracker
{
    /// <summary>
    /// MVC View class
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        #endregion

        #region PROPERTIES

        int MAXIMUM_ATTEMPTS = 5;
        int MAXIMUM_BUYSELL_AMOUNT = 20;
        int MINIMUM_BUYSELL_AMOUNT = 5;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView()
        {
            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();

            DisplayAccountDetail(salesperson);

            DisplayContinuePrompt();
        }

        /// <summary>
        ///  display the salesperson account details
        /// </summary>
        /// <param name="salesperson"></param>
        public void DisplayAccountDetail(Salesperson salesperson)
        {
            ConsoleUtil.DisplayMessage("First Name: " + salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + salesperson.LastName);
            ConsoleUtil.DisplayMessage("Account ID: " + salesperson.AccountID);
        }

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "CIT 195 Sales Tracker Project";
            ConsoleUtil.HeaderText = "The Sales Tracker Application";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            ConsoleUtil.DisplayMessage("");

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            ConsoleUtil.DisplayMessage("");

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {              
            ConsoleUtil.DisplayReset();

            Console.WriteLine("Do you wish to exit the application?  Y/N:");
            //response = ConsoleValidator.ValidateYN();

            ConsoleKeyInfo userResponse = Console.ReadKey(true);

            switch (userResponse.KeyChar)
            {
                case 'Y':
                case 'y':
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage("Thank you for using The Sales Tracker Application.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                    break;
                case 'N':
                case 'n':
                    DisplayContinuePrompt();
                    break;
                default:
                    ConsoleUtil.DisplayMessage("Invalid entry.  Please try again.");
                    DisplayContinuePrompt();
                    break;
            }
        }

        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            Console.Clear();

            ConsoleUtil.DisplayMessage("Written by Shayne Jones");
            ConsoleUtil.DisplayMessage("Northwestern Michigan College");
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("You are a traveling salesperson buying and selling widgets ");
            sb.AppendFormat("around the country. You will be prompted regarding which city ");
            sb.AppendFormat("you wish to travel to and will then be asked whether you wish to buy ");
            sb.AppendFormat("or sell widgets.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            ConsoleUtil.DisplayMessage("");

            sb.Clear();
            sb.AppendFormat("Your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        public Salesperson DisplaySetupAccount()
        {
            Salesperson salesperson = new Salesperson();
            int maxAttempts = 3;
            string firstName;
            string lastName;
            string accountId;
            string city;
            bool maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();

            firstName = ConsoleValidator.TestForEmpty(maxAttempts, "First Name:", out maxAttemptsExceeded);
            
            if (!string.IsNullOrEmpty(firstName))
            {
                salesperson.FirstName = firstName;
                maxAttemptsExceeded = false;
            }
            else
            {
                return salesperson;
            }

            lastName = ConsoleValidator.TestForEmpty(maxAttempts, "Last Name:", out maxAttemptsExceeded);

            if (!string.IsNullOrEmpty(lastName))
            {
                salesperson.LastName = lastName;
                maxAttemptsExceeded = false;
            }
            else
            {
                return salesperson;
            }

            accountId = ConsoleValidator.TestForEmpty(maxAttempts, "Account ID:", out maxAttemptsExceeded);

            if (!string.IsNullOrEmpty(accountId))
            {
                salesperson.AccountID =  accountId;
                maxAttemptsExceeded = false;
            }
            else
            {
                return salesperson;
            }

            city = ConsoleValidator.TestForEmpty(maxAttempts, "City:", out maxAttemptsExceeded);

            if (!string.IsNullOrEmpty(city))
            {
                salesperson.CitiesVisited.Add(city);
                maxAttemptsExceeded = false;
            }
            else
            {
                return salesperson;
            }

            return salesperson;
        }

        /// <summary>
        /// display a list of product types and return the selected product with cost
        /// </summary>
        public void DisplayProductUserSelection(Salesperson salesperson)
        {
            bool usingMenu = true;
            int maxAttempts = 3;
            bool maxAttemptsExceeded = false;
            
            Product product = new Product();

            Product.ProductType productType = new Product.ProductType();

            productType = Product.ProductType.None;

            //
            // set up display area
            //
            ConsoleUtil.DisplayReset();
            ConsoleUtil.HeaderText = "Select a Product";
            Console.CursorVisible = false;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                ConsoleUtil.DisplayMessage("");
                Console.Write(
                    "\t" + "1. Furry" + Environment.NewLine +
                    "\t" + "2. Spotted" + Environment.NewLine +
                    "\t" + "3. Dancing" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        productType = Product.ProductType.Furry;
                        usingMenu = false;
                        break;
                    case '2':
                        productType = Product.ProductType.Spotted;
                        usingMenu = false;
                        break;
                    case '3':
                        productType = Product.ProductType.Dancing;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
                product.Type = productType;
            }
            Console.Clear();

            if (!string.IsNullOrEmpty(product.Type.ToString()))
            product.Cost = ConsoleValidator.TestForDouble(maxAttempts, $"{product.Type} Product Cost:", out maxAttemptsExceeded);

            Console.CursorVisible = true;
            salesperson.CurrentStock = product;
            //return product;
        }

        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();

            Console.WriteLine("Do you wish to exit the application?  Y/N:");
            Console.ReadLine();
            ConsoleUtil.DisplayMessage("Thank you for using The Traveling Salesperson Application.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            ConsoleUtil.HeaderText = "Main Menu";

            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                ConsoleUtil.DisplayMessage("");

                Console.Write(
                 "\t" + "0. Create an account" + Environment.NewLine +
                 "\t" + "1. Select a product" + Environment.NewLine +
                 "\t" + "2. Travel" + Environment.NewLine +
                 "\t" + "3. Buy" + Environment.NewLine +
                 "\t" + "4. Sell" + Environment.NewLine +
                 "\t" + "5. Display Inventory" + Environment.NewLine +
                 "\t" + "6. Display Cities" + Environment.NewLine +
                 "\t" + "7. Display Account Info" + Environment.NewLine +
                 "\t" + "8. Save Account Info" + Environment.NewLine +
                 "\t" + "9. Load Account Info" + Environment.NewLine +
                 "\t" + "E. Exit" + Environment.NewLine);


                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '0':
                        userMenuChoice = MenuOption.SetupAccount;
                        usingMenu = false;
                        break;
                    case '1':
                        userMenuChoice = MenuOption.SetupProduct;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case '8':
                        userMenuChoice = MenuOption.SaveAccountInfo;
                        usingMenu = false;
                        break;
                    case '9':
                        userMenuChoice = MenuOption.LoadAccountInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        ConsoleUtil.DisplayMessage(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }

        /// <summary>
        /// get the number of units to buy for a product
        /// </summary>
        /// <returns>int numberOfUnitsToBuy</returns>
        public int DisplayGetNumberOfUnitsToBuy(Product product)
        {
            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();

            //
            // get number of units to buy
            //
            ConsoleUtil.DisplayMessage("Buying " + product.Type.ToString() + " products.");
            ConsoleUtil.DisplayMessage("");

            if (!ConsoleValidator.TryGetIntegerFromUser(MINIMUM_BUYSELL_AMOUNT, MAXIMUM_BUYSELL_AMOUNT, MAXIMUM_ATTEMPTS, "products", out int numberOfUnitsToBuy))
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products to buy.");
                ConsoleUtil.DisplayMessage("By default, the number of products to buy will be set to zero.");
                numberOfUnitsToBuy = 0;
                DisplayContinuePrompt();
            }
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage(numberOfUnitsToBuy + " " + product.Type.ToString() + " products have been added to the Inventory.");

            DisplayContinuePrompt();

            return numberOfUnitsToBuy;
        }

        /// <summary>
        /// notify user when units sold exceed units on hand
        /// </summary>
        public void DisplayBackOrderNotification(Product product, int numberOfUnitsSold)
        {
            ConsoleUtil.HeaderText = "Inventory Backorder Notification";
            ConsoleUtil.DisplayReset();

            int numberOfUnitsBackordered = Math.Abs(product.NumberOfUnits);
            int numberOfUnitsShipped = numberOfUnitsSold - numberOfUnitsBackordered;

            ConsoleUtil.DisplayMessage("Products Sold: " + numberOfUnitsSold);
            ConsoleUtil.DisplayMessage("Products Shipped: " + numberOfUnitsShipped);
            ConsoleUtil.DisplayMessage("Products on Backorder: " + numberOfUnitsBackordered);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the number of units to sell for a product
        /// </summary>
        /// <returns>int numberOfUnitsToSell</returns>
        public int DisplayGetNumberOfUnitsToSell(Product product)
        {
            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();

            if (product == null)
            {
                ConsoleUtil.DisplayMessage("No product has been selected");
                DisplayContinuePrompt();
                return 0;
            }
            else
            {
                //
                // get number of units to buy
                //
                ConsoleUtil.DisplayMessage("Selling " + product.Type.ToString() + " products.");
                ConsoleUtil.DisplayMessage("");

                if (!ConsoleValidator.TryGetIntegerFromUser(MINIMUM_BUYSELL_AMOUNT, MAXIMUM_BUYSELL_AMOUNT, MAXIMUM_ATTEMPTS, "products", out int numberOfUnitsToSell))
                {
                    ConsoleUtil.DisplayMessage("It appears you are having difficulty setting the number of products to sell.");
                    ConsoleUtil.DisplayMessage("By default, the number of products to sell will be set to zero.");
                    numberOfUnitsToSell = 0;
                    DisplayContinuePrompt();
                }
                ConsoleUtil.DisplayReset();

                ConsoleUtil.DisplayMessage(numberOfUnitsToSell + " " + product.Type.ToString() + " products have been subtracted from the Inventory.");

                DisplayContinuePrompt();

                return numberOfUnitsToSell;
            }
        }

        /// <summary>
        /// displays the status of the current inventory
        /// </summary>
        public void DisplayInventory(Product product)
        {
            ConsoleUtil.HeaderText = "Current Inventory";
            ConsoleUtil.DisplayReset();
           // if(product)
            ConsoleUtil.DisplayMessage("Product type: " + product.Type.ToString());
            ConsoleUtil.DisplayMessage("Number of units: " + product.NumberOfUnits.ToString());
            ConsoleUtil.DisplayMessage("Cost per unit: " + product.Cost.ToString());
            ConsoleUtil.DisplayMessage("Total cost of units: $" + (product.NumberOfUnits * product.Cost).ToString("0.00"));
            ConsoleUtil.DisplayMessage("");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string nextCity</returns>
        public string DisplayGetNextCity(Salesperson salesperson)
        {

            string nextCity = "";
            ConsoleUtil.HeaderText = "Travel";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Where would you like to travel to?");
            salesperson.CitiesVisited.Add(Console.ReadLine());


            return nextCity;
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Cities Visited";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Cities Visited:");
            Console.WriteLine();
            foreach (var city in salesperson.CitiesVisited)
            {
                ConsoleUtil.DisplayMessage(city);
            } 
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display confirmation that a salesperson account was successfully loaded
        /// </summary>
        public void DisplayConfirmLoadAccountInfo(Salesperson salesperson)
        {
            ConsoleUtil.HeaderText = "Load Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Account information loaded");

            DisplayAccountDetail(salesperson);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display confirmation that a salesperson account was successfully loaded
        /// </summary>
        public void DisplayConfirmSaveAccountInfo()
        {
            ConsoleUtil.HeaderText = "Save Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("Account information saved");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display confirmation that a salesperson account was successfully loaded
        /// </summary>
        public bool DisplayLoadAccountInfo(Salesperson salesperson, out bool maxAttemptsExceeded)
        {
            string userResponse;
            maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Load Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            userResponse = ConsoleValidator.GetYesNoFromUser(MAXIMUM_ATTEMPTS, 
                "Load the account information?", out maxAttemptsExceeded);

            if (maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty.  You will " +
                         "return to the main menu.");
                return false;

            }
            else
            {
                //
                // note use of ternary operator
                //
                return userResponse == "YES" ? true : false;
            }
        }

        /// <summary>
        /// display confirmation that a salesperson account was successfully loaded
        /// </summary>
        /// <param name="maxAttemptsExceeded"></param>
        /// <returns>bool</returns>
        public bool DisplayLoadAccountInfo(out bool maxAttemptsExceeded)
        {
            string userResponse;
            maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Load Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("");
            userResponse = ConsoleValidator.GetYesNoFromUser(MAXIMUM_ATTEMPTS,
                "Load the account information?", out maxAttemptsExceeded);

            if (maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty.  You will " +
                         "return to the main menu.");
                return false;

            }
            else
            {
                //
                // note use of ternary operator
                //
                return userResponse == "YES" ? true : false;
            }
        }

        /// <summary>
        /// display confirmation that a salesperson account was successfully loaded
        /// </summary>
        public bool DisplaySaveAccountInfo(Salesperson salesperson, out bool maxAttemptsExceeded)
        {
            string userResponse;
            maxAttemptsExceeded = false;

            ConsoleUtil.HeaderText = "Save Account";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("The current account information.");
            DisplayAccountDetail(salesperson);

            ConsoleUtil.DisplayMessage("");
            userResponse = ConsoleValidator.GetYesNoFromUser(MAXIMUM_ATTEMPTS,
                "Save the account information?", out maxAttemptsExceeded);

            if (maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayMessage("It appears you are having difficulty.  You will " +
                         "return to the main menu.");
                return false;

            }
            else
            {
                //
                // note use of ternary operator
                //
                return userResponse.ToUpper() == "YES" ? true : false;
            }
        }

        /// <summary>
        /// changes string to lowercase with first letter response
        /// adapted from: https://www.dotnetperls.com/uppercase-first-letter
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string</returns>
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concatenation substring.
            return char.ToUpper(s[0]) + s.Substring(1).ToLower();
        }

        /// <summary>
        /// display an error message when an object is null
        /// </summary>
        public void DisplayObjectError(string objectName)
        {
            ConsoleUtil.HeaderText = "Error";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage($"No {objectName} has been selected");

            DisplayContinuePrompt();
        }

        #endregion

    }
}
