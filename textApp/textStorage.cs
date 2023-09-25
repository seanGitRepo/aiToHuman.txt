
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
            string line = "test";

             List<string> newWordsInList = new List<string>();

            while (line != null)
            {
                line = a.ReadLine();

                if (line == null)
                {                  
                    break;
                }

                char[] upper = searchWord.ToCharArray();
                upper[0] = char.ToUpper(upper[0]);
                searchWord = new string(upper);
                

                string[] firstPart = line.Split(" ");
              
                if (firstPart[0] == searchWord)
                {         

                    string[] newWords = line.Split(" "); // this will contain "anger" "-"

                    for (int i = 1; i < newWords.Length; i++)
                    {
                        char[] charArray = newWords[i].ToCharArray();

                        if (charArray[charArray.Length - 1].ToString() == ",")
                        {
                            newWordsInList.Add(charArray[charArray.Length - 1].ToString());
                           //retunrs all the array with the words without a comma at the end
                        }
                    }

                }

                

            }

            //6. thesauraus receicves the word- done 
            //8. takes the first letter to go to the text file which is for words that start with ex"like" l
            //7. goes through the text file until the word is found.
            //8. it then takes that entire line and puts the words that were on that line into an array/list
            // if ther word is not found, just return the word back.
            //9. will then return the string of words to convertText.
            

			return newWordsInList;
		}

		public static void theSmallerDictionary()
		{
			//this will only be used when the proficenty is determined by the input text 
		}
        public static void userText()
        {
            // this will store the input of the user, aka descriptoin of the mona lisa.
        }

    }
}

//Notes:
// does the dictionary get split into the profieceny levels,,,
// nooo the file will store the words for the proficenys name of the text file can be changed as per the proficency level.

// then based on the proficeny that will be used for the entirety of the program, which can be changed when the proficeny level is changed.
