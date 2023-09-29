using System;
namespace textApp
{
	public class userSettings
	{
		public string UserName; 
        public string UserAge;
        public string ProfLevel;
        public string Text;

		public userSettings(string userName, string userAge, string profLevel,string text)
		{
			UserName = userName;
			UserAge = userAge;
			ProfLevel = profLevel;
            Text = text;
		}

        public virtual void manualProfChanger()
        {

            string prior = ProfLevel;

            Console.WriteLine("What would you like to select the proficency level to?" +
                "\n 1. Basic english speaker, not using complex words and simple sentece structre" +
                "\n 2. Medium english speaker, highschool years 10-12" +
                "\n 3. Competent english speaker, university level after first year");

            Console.WriteLine($"Current prof level {ProfLevel}");
            string changed = "fail";
            while (changed == "fail")
            {
                try
                {
                    ProfLevel = Console.ReadLine();

                    if (int.Parse(ProfLevel) <= 3 && int.Parse(ProfLevel) >= 1)
                    {
                        Console.WriteLine($"Thank you the proficiceny level for {UserName} is {ProfLevel}");
                        changed = "pass";
                    }
                    else
                    {
                        ProfLevel = prior;
                        Console.WriteLine($"That is not a valid proficiceny leve for {UserName}, it has been set back to {ProfLevel}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"That is not a valid proficiceny level for {UserName}, it has been set back to {ProfLevel}");

                }
            }

        }
        public string ProflevelReturn()
        {


            return ProfLevel;
        }

        public void inputText()
        {
            // this will only be used if the user chooses to.
            string choice = "";
            int correct = 0;
            string inputText = "";

            List<string> temp = new List<string>();

            while (correct == 0)
            {

                Console.WriteLine("Would you like to draw from a file or input into the console\nPlease enter console or file");
                choice = Console.ReadLine();

                if (choice == "file" || choice == "console")
                {
                    correct = 1;
                }
                else
                {
                    correct = 0;
                }

            }
            string line = " ";

            if (choice == "file" || choice == "File") // if the user wants to use a file.
            {
                
                 temp = File.ReadAllLines("../../../InputText/text.txt").ToList();

                inputText = string.Join(" ",temp);
              
            }
            else if (choice == "console" || choice == "Choice")
            {
                Console.WriteLine("Please keep typing, enter an empty line when complete");

                while (line != null)
                {
                    line = Console.ReadLine();

                    if (line == null || line == string.Empty)
                    {
                        break;
                    }

                    temp.Add(line);
                    
                }

                for (int i = 0; i < temp.Count; i++)
                {

                    inputText = string.Join(" ", temp[i]);

                }

            }

            


            //its not a list, its one entire string.
            Text = inputText;
        }


        public void editUserText(List<string> newText)
        {
            Text = "";
            foreach (var item in newText)
            {
                Text += item;
            }

        }
    }
}

