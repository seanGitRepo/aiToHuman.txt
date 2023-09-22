namespace textApp;

 class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Welcome!");
        Console.WriteLine("Please start with you're name and age.");

        string userName = Console.ReadLine();
        string userAge = Console.ReadLine();
        string profLevel = "Not Set";

         userSettings a = new userSettings(userName, userAge, profLevel);

        string programRun = "";

        while (programRun != "exit")
        {
            Console.WriteLine("Select from the following menu:\n1. Proficiency Calculator\n2. Conversion of selected text\n3. Manual Proficency Selector\n4. How the app works\n type exit to exit");
            programRun = Console.ReadLine();


            if (programRun == "3")
            {

                a.manualProfChanger();

            }

        }


    }

    
}
