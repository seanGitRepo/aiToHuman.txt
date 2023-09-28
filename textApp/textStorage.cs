
using System;
namespace textApp
{
	public class textStorage
	{
		public textStorage()
		{
		}


		

		public static void outputText()
		{
			// will do the math for converting the inputText

		}

		

		public static List<string> thesaurasStorage(string searchWord)
		{
            StreamReader a = new StreamReader("../../../Thes/stolenSyn.txt");
            

             List<string> newWordsInList = new List<string>();
            int found = 0;

            string preventCaps = searchWord;
            string line;
            while ((line = a.ReadLine()) != null)
            {
        
                char[] upper = searchWord.ToCharArray();
                upper[0] = char.ToUpper(upper[0]);
                searchWord = new string(upper);

                string[] firstPart = line.Split(" ");

                
                if (firstPart[0] == searchWord)
                {
                    //gets to here with created.

                    found++;

                    for (int i = 2; i < firstPart.Length; i++)
                    {
                        char[] charArray = firstPart[i].ToCharArray();// turns the current word into a char we wnat to remove the last one

                        firstPart[i] = "";
                        if (i != firstPart.Length-1)
                        {

                            for (int ji = 0; ji < charArray.Length - 1; ji++)
                            {
                                firstPart[i] += charArray[ji]; // build it again here

                            }

                            newWordsInList.Add(firstPart[i]);
                        }
                        else
                        {
                            for (int ji = 0; ji < charArray.Length; ji++)
                            {
                                firstPart[i] += charArray[ji]; // build it again here

                            }

                            newWordsInList.Add(firstPart[i]);

                        }
                    }
                   
                }

               
            }
            a.Close();
            if (found == 0)
            {
                newWordsInList.Add(preventCaps);
            }
            //6. thesauraus receicves the word- done 
            //8. takes the first letter to go to the text file which is for words that start with ex"like" 
            //7. goes through the text file until the word is found.
            //8. it then takes that entire line and puts the words that were on that line into an array/list
            // if ther word is not found, just return the word back.
            //9. will then return the string of words to convertText.
            
			return newWordsInList;
		}

		public static void theSmallerDictionary(string text)
		{
            Console.WriteLine("Welcome to the spell checker:");
            int numOfWords = 0;
            int incorrectWords = 0;
            List<string> incorrect = new List<string>();
            List<string> words = new List<string>();
            words = convertText.splitUserText(text);

            

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

                    }else if (allLines[i] == "OneWordAwayFromReadingAllWords" && !found)
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

            

            for (int i = 0; i < incorrect.Count; i++)
            {
               // recommendedFix(incorrect[i]);

                
            }

            //would you like to apply these corrections to the words ?

		}
        public static List<string> recommendedFix(string word)
        {
            List<string> options = new List<string>();


           char[] letters= convertText.wordStripper(word);


            //percentage of a word correctness



            return options;
            // this will store the input of the user, aka descriptoin of the mona lisa.
        }

    }
}

//Notes:
// does the dictionary get split into the profieceny levels,,,
// nooo the file will store the words for the proficenys name of the text file can be changed as per the proficency level.

// then based on the proficeny that will be used for the entirety of the program, which can be changed when the proficeny level is changed.
