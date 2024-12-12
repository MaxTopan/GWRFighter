namespace MaxTopan_GWRFighter.Utilities.Menus
{
    public class Menu
    {
        string Header { get; }
        string[] Choices { get; }
        Dictionary<int, Action> Results { get; }

        public Menu(string header, string[] choices, Dictionary<int, Action> results)
        {
            Header = header;
            Choices = choices;
            Results = results;
        }

        /// <summary>
        /// Displays menu choices, awaits selection, and invokes result
        /// </summary>
        public void Use()
        {
            DisplayChoices();
            int choice = GetChoice();
            InvokeResult(choice);
        }

        public void DisplayChoices()
        {
            Console.WriteLine(Header);
            for (int i = 0; i < Choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Choices[i]}");
            }
        }

        /// <summary>
        /// Gets and validates an int from the user
        /// </summary>
        /// <returns>The validated chosen int</returns>
        public int GetChoice()
        {
            int choice;
            do
            {
                Console.Write($"Please choose (1 - {Choices.Length}): ");
            } while (int.TryParse(Console.ReadLine(), out choice) && 1 > choice || choice > Choices.Length);

            return choice;
        }

        public void InvokeResult(int choice)
        {
            if (!Results.ContainsKey(choice))
            {
                throw new Exception("Attempted to invoke invalid choice.");
            }



            Results[choice].Invoke();
        }
    }
}