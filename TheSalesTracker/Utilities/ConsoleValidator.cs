using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TheSalesTracker
{
    /// <summary>
    /// This class provided by John Velis, NMC Instructor
    /// Adapted to include methods for validating "Y/N" responses
    /// </summary>
    public static class ConsoleValidator
    {
        /// <summary>
        /// helper method to get a valid integer from the user within a range
        /// </summary>
        /// <param name="minValue">inclusive minimum value</param>
        /// <param name="maxValue">inclusive maximum value</param>
        /// <param name="maxAttempts">maximum number of attempts</param>
        /// <param name="pluralName">plural name of item</param>
        /// <param name="userInteger">return integer</param>
        /// <returns></returns>
        public static bool TryGetIntegerFromUser(int minValue, int maxValue, int maxAttempts, string pluralName, out int userInteger)
        {
            bool validInput = false;
            bool maxAttemptsExceeded = false;
            string userResponse;
            string feedbackMessage = "";
            int attempts = 1;

            userInteger = 0;

            while (!validInput && !maxAttemptsExceeded)
            {
                //
                // more attempts available
                //
                if (attempts <= maxAttempts)
                {
                    ConsoleUtil.DisplayPromptMessage($"Enter the number, between {minValue} and {maxValue}, of {pluralName}:");
                    userResponse = Console.ReadLine();
                    ConsoleUtil.DisplayMessage("");

                    //
                    // input is an Integer
                    //
                    if (int.TryParse(userResponse, out userInteger))
                    {
                        //
                        // input is in range
                        //
                        if (userInteger >= minValue && userInteger <= maxValue)
                        {
                            validInput = true;
                        }
                        //
                        // input is not in range
                        //
                        else
                        {
                            feedbackMessage = $"The number {userInteger} is not in the specified range.";
                        }
                    }
                    //
                    // input is not an Integer
                    //
                    else
                    {
                        feedbackMessage = $"{userResponse} is not an integer.";
                    }

                    if (!validInput && attempts <= maxAttempts)
                    {
                        ConsoleUtil.DisplayMessage($"You entered: {userResponse}");
                        ConsoleUtil.DisplayMessage(feedbackMessage);

                        if (attempts < maxAttempts)
                        {
                            ConsoleUtil.DisplayMessage($"Please enter an integer between {minValue} and {maxValue}.");
                            ConsoleUtil.DisplayMessage("Press any key to try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("It appears you have exceeded the maximum number of attempts allowed.");
                            ConsoleUtil.DisplayMessage("Press any key to continue.");
                            Console.ReadKey();
                        }

                        Console.Clear();
                    }
                    else
                    {
                        ConsoleUtil.DisplayMessage("");
                    }

                    attempts++;
                }
                else
                {
                    maxAttemptsExceeded = true;
                }
            }

            return validInput;
        }

        /// <summary>
        /// helper method to get a valid "Yes" or "No" response from the user
        /// </summary>
        /// <param name="maxAttempts">maximum number of attempts</param>
        /// <param name="userPrompt">user prompt</param>
        /// <param name="maxAttemptsExceeded">indicates whether maximum number of attempts has been reached</param>
        /// <returns></returns>
        public static string GetYesNoFromUser(int maxAttempts, string userPrompt, out bool maxAttemptsExceeded)
        {
            bool validInput = false;
            maxAttemptsExceeded = false;
            string userResponse = "";
            int attempts = 1;

            while (!validInput && !maxAttemptsExceeded)
            {
                Console.Write($"{userPrompt} [Yes / No] ");
                userResponse = Console.ReadLine().ToUpper();
                ConsoleUtil.DisplayMessage("");

                //
                // input is valid
                //
                if (userResponse == "YES" || userResponse.ToUpper() == "NO")
                {
                    validInput = true;
                }
                //
                // input is invalid, but more attempts available
                //
                else
                {
                    ConsoleUtil.DisplayMessage($"You entered: {userResponse}");
                    ConsoleUtil.DisplayMessage($"\"{userResponse}\" is not a valid response.");

                    //
                    // more attempts available 
                    //
                    if (attempts < maxAttempts)
                    {
                        ConsoleUtil.DisplayMessage($"Please enter either \"Yes\" or \"No\".");
                        ConsoleUtil.DisplayMessage("Press any key to try again.");
                    }
                    //
                    // all attempts used
                    //
                    else
                    {
                        ConsoleUtil.DisplayMessage("It appears you have exceeded the maximum number of attempts allowed.");
                        ConsoleUtil.DisplayMessage("Press any key to continue.");
                        maxAttemptsExceeded = true;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                attempts++;
            }

            return userResponse;
        }

        /// <summary>
        /// helper method to get a valid string response from the user
        /// based on John Velis' GetYesNoFromUser method
        /// </summary>
        /// <param name="maxAttempts">maximum number of attempts</param>
        /// <param name="userPrompt">user prompt</param>
        /// <param name="maxAttemptsExceeded">indicates whether maximum number of attempts has been reached</param>
        /// <returns></returns>
        public static string TestForEmpty(int maxAttempts, string userPrompt, out bool maxAttemptsExceeded)
        {
            bool validInput = false;
            maxAttemptsExceeded = false;
            string userResponse = "";
            int attempts = 1;

            while (!validInput && !maxAttemptsExceeded)
            {
                //Console.Write(userPrompt);
                ConsoleUtil.DisplayPromptMessage(userPrompt);
                userResponse = Console.ReadLine();
                ConsoleUtil.DisplayMessage("");

                //
                // input is valid
                //
                if (!string.IsNullOrEmpty(userResponse))
                {
                    validInput = true;
                }
                //
                // input is invalid, but more attempts available
                //
                else
                {
                    //
                    // more attempts available 
                    //
                    if (attempts < maxAttempts)
                    {
                        ConsoleUtil.DisplayMessage("Please enter a non-empty value.");
                        ConsoleUtil.DisplayMessage("Press any key to try again.");
                    }
                    //
                    // all attempts used
                    //
                    else
                    {
                        ConsoleUtil.DisplayMessage("It appears you have exceeded the maximum number of attempts allowed.");
                        ConsoleUtil.DisplayMessage("Press any key to continue.");
                        maxAttemptsExceeded = true;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                attempts++;
            }

            return userResponse;
        }

        /// <summary>
        /// helper method to get a valid decimal response from the user
        /// based on John Velis's GetYesNoFromUser method
        /// </summary>
        /// <param name="maxAttempts">maximum number of attempts</param>
        /// <param name="userPrompt">user prompt</param>
        /// <param name="maxAttemptsExceeded">indicates whether maximum number of attempts has been reached</param>
        /// <returns>double</returns>
        public static double TestForDouble(int maxAttempts, string userPrompt, out bool maxAttemptsExceeded)
        {
            bool validInput = false;
            maxAttemptsExceeded = false;
            double dub = 0.00;
            string userResponse;
            int attempts = 1;

            while (!validInput && !maxAttemptsExceeded)
            {
                ConsoleUtil.DisplayPromptMessage(userPrompt);
                userResponse = Console.ReadLine();
                ConsoleUtil.DisplayMessage("");
            
                //
                // input is valid
                //
                if (double.TryParse(userResponse, out dub))
                {
                   validInput = true;
                }
                else
                {
                    //
                    // more attempts available 
                    //
                    if (attempts < maxAttempts)
                    {
                        ConsoleUtil.DisplayMessage("Please enter a monetary value without a currency symbol");
                        ConsoleUtil.DisplayMessage("Press any key to try again.");
                    }
                    //
                    // all attempts used
                    //
                    else
                    {
                        ConsoleUtil.DisplayMessage("It appears you have exceeded the maximum number of attempts allowed.");
                        ConsoleUtil.DisplayMessage("Press any key to continue.");
                        maxAttemptsExceeded = true;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                attempts++;
            }

            return dub;
        }



        /// <summary>
        /// helper method to get a valid "Y" or "N" response from the user
        /// </summary>
        /// <param name="maxAttempts">maximum number of attempts</param>
        /// <param name="userPrompt">user prompt</param>
        /// <param name="maxAttemptsExceeded">indicates whether maximum number of attempts has been reached</param>
        /// <returns></returns>
        public static string GetYNFromUser(int maxAttempts, string userPrompt, out bool maxAttemptsExceeded)
        {
            bool validInput = false;
            maxAttemptsExceeded = false;
            string userResponse = "";
            int attempts = 1;

            while (!validInput && !maxAttemptsExceeded)
            {
                Console.Write($"{userPrompt} [Y / N] ");
                userResponse = Console.ReadLine();
                ConsoleUtil.DisplayMessage("");

                //
                // input is valid
                //
                if (userResponse.ToUpper() == "Y" || userResponse.ToUpper() == "N")
                {
                    validInput = true;
                }
                //
                // input is invalid, but more attempts available
                //
                else
                {
                    ConsoleUtil.DisplayMessage($"You entered: {userResponse}");
                    ConsoleUtil.DisplayMessage($"\"{userResponse}\" is not a valid response.");

                    //
                    // more attempts available 
                    //
                    if (attempts < maxAttempts)
                    {
                        ConsoleUtil.DisplayMessage($"Please enter either \"Y\" or \"N\".");
                        ConsoleUtil.DisplayMessage("Press any key to try again.");
                    }
                    //
                    // all attempts used
                    //
                    else
                    {
                        ConsoleUtil.DisplayMessage("It appears you have exceeded the maximum number of attempts allowed.");
                        ConsoleUtil.DisplayMessage("Press any key to continue.");
                        maxAttemptsExceeded = true;
                    }

                    Console.ReadKey();
                    Console.Clear();
                }

                attempts++;
            }

            return userResponse;
        }
    }
}