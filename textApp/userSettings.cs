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
            else if (choice == "console" || choice == "Console")
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

                inputText = string.Join(" ", temp);

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

        public virtual void theSmallerDictionary()
        {
            Console.WriteLine("Welcome to the spell checker:");
            int numOfWords = 0;
            int incorrectWords = 0;
            List<string> incorrect = new List<string>();
            List<string> words = new List<string>();
            words = convertText.splitUserText(Text);



            string searching;
            bool found = false;

            List<string> allLines = File.ReadAllLines("../../../Dic/word.txt").ToList();



            foreach (string word in words)
            {

                for (int i = 0; i < allLines.Count; i++)
                {

                    if (word == allLines[i])
                    {

                        //words has been found and is correctly spelt.
                        found = true;

                    }
                    else if (allLines[i] == "OneWordAwayFromReadingAllWords" && !found)
                    {
                        incorrect.Add(word);
                        incorrectWords++;
                        break;
                    }

                }

                Console.WriteLine($"{word}: checked");
                found = false;

            }

            Console.WriteLine("Here is a list of the words spelt in correctly: ");
            for (int i = 0; i < incorrect.Count; i++)
            {
                //wanting to create a way to show the index of the word to find it easily in the program.
                Console.WriteLine($"- {incorrect[i]}");
            }
            Console.WriteLine($"Word Count: {words.Count}");
            Console.WriteLine($"Incorrect Words: {incorrectWords}");

            //User has enetered x.words - done
            //User has spelt x words wrong - done
            //Here is the list of incorrect words.- done

            Console.WriteLine("Would you like to edit the original text with possible changes?\n y/n");

            string uS = Console.ReadLine();

            if (uS == "y")
            {

                for (int i = 0; i < incorrect.Count; i++)
                {
                    // recommendedFix(incorrect[i]);
                    Console.WriteLine($"Options for: {incorrect[i]}");

                    HashSet<string> options = convertText.recommendedFix(incorrect[i], allLines); //returns options which are good to change the users incorrect word.
                    List<string> optionsList = new List<string>();

                    foreach (var item in options)
                    {
                        optionsList.Add(item);
                    }
                    Console.WriteLine("Select a number from the below options:");
                    for (int j = 0; j < optionsList.Count; j++)
                    {
                        Console.WriteLine($"{j + 1}. {optionsList[j]}");
                    }
                    Console.WriteLine("- press enter if no words match -");

                    string userSelectionString = Console.ReadLine();

                    if (userSelectionString == string.Empty || userSelectionString == null)
                    {
                       
                    }else if (userSelectionString == "1"|| userSelectionString == "2" || userSelectionString == "3")
                    {
                        int userSelection = int.Parse(userSelectionString);

                        userSelection = userSelection - 1;

                        if (userSelection > 1 || userSelection < 3)//1 = op2
                        {
                            for (int j = 1; j < optionsList.Count + 1; j++)
                            {
                                if (userSelection == j)
                                {
                                    //I have a correct word and i want to change the original text.


                                    // the original text

                                    for (int a = 0; a < words.Count; a++)
                                    {
                                        if (words[a] == incorrect[i])//a is the index of the original user text
                                        {
                                            words[a] = optionsList[userSelection];//this changes the correct word.

                                            Text = string.Join(" ", convertText.TextRestorerWithChange(Text, a, optionsList[userSelection]));//just have to join
                                        }
                                    }


                                }
                            }
                        }
                    }
                    
                }


            }
            //would you like to apply these corrections to the words ?
            Console.WriteLine("New text: ");

            Console.WriteLine(Text);
        }



        public virtual void GeneralRun()
        {

            string wordSearch = "";
            string puncDropped = "";
            List<string> rebuiltUserInput = new List<string>();

            string[] textArray = Text.Split(" ");//this split is working correctly


            for (int i = 0; i < textArray.Length; i++) // this iteration is the length of the file to be changed 
            {                                          // using the mona lisa: "the mona lisa" i0 = the
                                                       //i currently = the, so we need to split the entire string to check for the last chr to = puncts
                char[] charArray = textArray[i].ToCharArray();
                try
                {


                    if (charArray[charArray.Length - 1].ToString() == "," || charArray[charArray.Length - 1].ToString() == ";" || charArray[charArray.Length - 1].ToString() == "." || charArray[charArray.Length - 1].ToString() == ":" || charArray[charArray.Length - 1].ToString() == "?")
                    {

                        puncDropped = charArray[charArray.Length - 1].ToString(); //this equals the correct first punc which is comma.

                        //here i need to remove the comma or watever. this is going to iterarate through the word.
                        for (int ji = 0; ji < charArray.Length - 1; ji++)
                        {
                            wordSearch += charArray[ji];

                        }

                        //wordSearch is the word that comes out
                    }
                    else
                    {
                        wordSearch = textArray[i];//this means that if a word fails we can just but it back as textarray, or if the user enters an inccorect word/
                    }
                }
                catch (Exception ex)
                {
                    wordSearch = textArray[i];
                }

                List<string> options = new List<string>();// holds the options to change the words.
                Random random = new Random();

                string wordChanged;

                if (wordSearch.Length > 2)
                {
                    options = textStorage.thesaurasStorage(wordSearch); // this recieves a list of the possible words to change.


                    int randomIndex = random.Next(0, options.Count);

                    // Use the random index to access the element in the array
                    wordChanged = options[randomIndex];


                }
                else { wordChanged = wordSearch; }// if the word isnt changed then it is importnat to return it with or without a comma.



                wordChanged += puncDropped; // word changed is the convereted and non converted word.;

                puncDropped = "";//this is not restoring the punctuation anymore.


                rebuiltUserInput.Add(wordChanged); // we are not changin the user text.

            }


            //rebuilding the users text
            Console.WriteLine("Would you like the new string displayed onto the console or saved into a text file");

            string choice = Console.ReadLine();
            int correct = 3;



            Text = string.Join(" ", rebuiltUserInput);

            
           
        }

        public virtual void saveFile()
        {

            Console.WriteLine("File Name:");
            string userFile = Console.ReadLine();
                string f = $"../../../OutputText/{userFile}.txt";

                File.WriteAllText(f, $"Created by: {UserName}\n");
                File.AppendAllText(f, Text);
                File.AppendAllText(f, "\n~ TextApp v1.1.3 ~");

           
            
        }
    }
}

