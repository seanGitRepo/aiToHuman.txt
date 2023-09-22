namespace textApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome!");

        Console.WriteLine("Please start with you're name and age.");
        // age is a fantastic way to gauge the ability of someones english.
        // Are you esl?
        // how long have you been learning english
        string userName = Console.ReadLine();
        string userAge = Console.ReadLine();

        string programRun = "";

        while (programRun != "exit")
        {
            Console.WriteLine("Select from the following menu:\n1. Proficiency Calculator\n2. Conversion of selected text\n3. Manual Proficency Selector\n4. How the app works\n type exit to exit");
            programRun = Console.ReadLine();
        }
     
      
    }
}

