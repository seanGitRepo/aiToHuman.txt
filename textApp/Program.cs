namespace textApp;

 class Program
 {
    public static void Main(string[] args)
    {

        Console.WriteLine("Welcome!");
        Console.WriteLine("Please start with your name and age.");
        Console.WriteLine("Name:");
        string userName = Console.ReadLine();
        Console.WriteLine("Age:");
        string userAge = Console.ReadLine();
        string profLevel = "Not Set";
        string Text = "Not Set";

         userSettings a = new userSettings(userName, userAge, profLevel,Text);

        string programRun = "";

        while (programRun != "exit")
        {
            Console.WriteLine("Select from the following menu:" +
                "\n1. Proficiency Test" +
                "\n2. Text for Program" +
                "\n3. Spell Check" +
                "\n4. Thesauras" +
                "\n5. Manual Proficency Selector" +
                "\n6. User Current Text" +
                "\n7. Save user Text" +
                "\n8. How the app works\n type exit to exit");

            programRun = Console.ReadLine();

            if (programRun == "2")
            {
                a.inputText();// sets the text for what the user wants to change.

            }
            else if (programRun == "5")
            {
                a.manualProfChanger();//changes the complexity of the word.

            } else if (programRun == "4")
            {

                if (a.Text == "Not Set")
                {
                    Console.WriteLine("Sorry there has not been not text selected to be used to run the program, please go to input text.");
                }
                else
                {
                    a.GeneralRun();
                }
            } else if (programRun == "3") {
                if (a.Text == "Not Set")
                {
                    Console.WriteLine("Sorry there has not been not text selected to be used to run the program, please go to input text.");
                }
                else
                {
                    a.theSmallerDictionary();
                }
               
            }else if( programRun == "6")
            {

                Console.WriteLine(a.Text);
            }else if (programRun == "7")
                 
            {
                if (a.Text == "Not Set")
                {
                    Console.WriteLine("Sorry there has not been not text selected to be used to run the program, please go to input text.");
                }
                else
                {
                    a.saveFile();
                }
            }


            // thought of a new challenge how do i know which tense the words are in for it to make sense.
         

        }


    }

    
}
