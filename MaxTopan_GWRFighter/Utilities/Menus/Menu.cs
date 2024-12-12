namespace MaxTopan_GWRFighter.Utilities.Menus
{
    /// <summary>
    /// An interactive choice presentable to the user
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Text to be displayed before presenting the choices
        /// </summary>
        string Header { get; }
        
        /// <summary>
        /// Array of text for the options to be displayed to the user
        /// </summary>
        string[] Options { get; }

        /// <summary>
        /// Dictionary of option numbers and delegates for the behaviour resulting from choosing that option
        /// </summary>
        Dictionary<int, Action> Results { get; }

        public Menu(string header, string[] options, Dictionary<int, Action> results)
        {
            Header = header;
            Options = options;
            Results = results;
        }


        /// <summary>
        /// Iterate through the option text with option numbers for each choice and display it to the user
        /// </summary>
        public void DisplayChoices()
        {
            Console.WriteLine(Header);
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Options[i]}");
            }
        }

        /// <summary>
        /// Gets and validates an int from the user
        /// </summary>
        /// <returns>The validated chosen int</returns>
        public int GetChoice()
        {
            int optionChoice;
            do
            {
                Console.Write($"Please choose (1 - {Options.Length}): ");
                if (int.TryParse(Console.ReadLine(), out optionChoice))
                {
                    continue;
                }
            } while (1 > optionChoice || optionChoice > Options.Length);

            return optionChoice;
        }

        /// <summary>
        /// Invokes the behaviour of a chosen option
        /// </summary>
        /// <param name="optionChoice">Which option's behaviour to invoke</param>
        /// <exception cref="Exception">Triggers on an attempt to invoke an option that doesn't exist</exception>
        public void InvokeResult(int optionChoice)
        {
            if (!Results.ContainsKey(optionChoice))
            {
                throw new Exception("Attempted to invoke invalid choice.");
            }

            Console.Clear();

            Results[optionChoice].Invoke();
        }
    }
}