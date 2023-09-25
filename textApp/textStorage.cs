
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
