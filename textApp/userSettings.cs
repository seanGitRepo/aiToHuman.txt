using System;
namespace textApp
{
	public class userSettings
	{
		protected string UserName;
        protected string UserAge;
        protected string ProfLevel;

		public userSettings(string userName, string userAge, string profLevel)
		{
			UserName = userName;
			UserAge = userAge;
			ProfLevel = profLevel;
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

    }
}

