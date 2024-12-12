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

        public Menu(string header, string[] options)
        {
            Header = header;
            Options = options;
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
            Console.Clear();
            Console.WriteLine();
            return optionChoice;
        }
    }
}