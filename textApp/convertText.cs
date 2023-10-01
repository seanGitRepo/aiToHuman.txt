using System;
using Microsoft.VisualBasic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;

namespace textApp
{
	public class convertText
	{
		
		//in this class i will draw the text, and then convert it based on the current value, i wonder if its worth
		//having another class for storing all data within the program to clean it up and have it clearly labeled.
		public convertText()
		{
			//what is the logic behind a thesauraus.

			//you have a word
			//then there are different options based on that word.
			//then one of those words are used to recreate the text.
			//maybe to start, if a word is longer than 5 characters it wfill go through the process of chaning letters



		}

		public static char[] wordStripper(string word)
		{
			char[] currentchr = word.ToCharArray();



			return currentchr;
		}






		public static List<string> splitUserText(string userText)
		{
			
			List<string> wordStorage = new List<string>();
            string wordSearch = "";

			List<string> lowerAll = new List<string>();

            string[] textArray = userText.Split(" ");//this split is working correctly



			for (int i = 0; i < textArray.Length; i++)
			{

				lowerAll.Add(textArray[i].ToLower());

			}
		
			for (int i = 0; i < lowerAll.Count; i++) // this iteration is the length of the file to be changed 
			{                                          // using the mona lisa: "the mona lisa" i0 = the
													   //i currently = the, so we need to split the entire string to check for the last chr to = puncts
				char[] charArray = lowerAll[i].ToCharArray();
				try
				{

					if (charArray[charArray.Length - 1].ToString() == "," || charArray[charArray.Length - 1].ToString() == ";" || charArray[charArray.Length - 1].ToString() == "." || charArray[charArray.Length - 1].ToString() == ":" || charArray[charArray.Length - 1].ToString() == "?")
					{


						//here i need to remove the comma or watever. this is going to iterarate through the word.
						for (int ji = 0; ji < charArray.Length - 1; ji++)
						{

							wordSearch += charArray[ji];

						}

						//wordSearch is the word that comes out
					}
					else
					{
                        wordSearch = lowerAll[i];
                    }
				}catch (Exception ex)
                {
                    wordSearch = lowerAll[i];
                }

                

				wordStorage.Add(wordSearch);
				wordSearch = "";
			}


                return wordStorage;
		}






		//1. accept string - done
		//2. split string on space. - done
		//3. if last chr = , or . or : or ; then remove - will need a way to add back later. - do this everytime on iteration of word. - done
		//4. if chr count > 5, then run thesauras.- done
		//13. next line
		//14. if there was a . or , or ; or :, then add it back to the end of the string.
		//15. go back to 1.











		public static void thesauraus(userSettings a)
		{
			//5. will search for word in the thesaurs,
			//10. array of words is returned to here for string manipulation.
			//11. then based on a random number between, options count of the array will select a random word
			//12. swap the words around



		}

        public static HashSet<string> recommendedFix(string word, List<string> dictionary) // This method does the math for the words that could be used to change the current text.
        {
            HashSet<string> options = new HashSet<string>();
            char[] incorrectWord = convertText.wordStripper(word);
            Dictionary<string, double> tempOptions = new Dictionary<string, double>();

            foreach (var currentWord in dictionary)
            {
                char[] wordsInDictionary = convertText.wordStripper(currentWord);

				try
				{

                if (incorrectWord[0] == wordsInDictionary[0])
                {
                    if (word.Length == currentWord.Length + 1 || word.Length == currentWord.Length - 1 || word.Length == currentWord.Length)
                    {

                        int counter = 0;

                        for (int i = 0; i < incorrectWord.Length; i++)
                        {

                            for (int j = 0; j < wordsInDictionary.Length; j++)
                            {
                                if (incorrectWord[i] == wordsInDictionary[j])
                                {
                                    counter++;// asaings a counter value of the letters which equal the same letter.
                                }// the numbers arnt mathing.
                                 //why does a count of 1 which should be 1/1
                                 //the word has to be 
                            }
                        }
                        double length = (currentWord.Length);
                        double accuracy = (counter / length);

                        Random f = new Random();

                        double max = 0.0001;
                        double min = 0.000002;

                        double beans = f.NextDouble() * (max - min) + min; //chaty used here, to help with double random numbers not sure how this works

                        if (tempOptions.Count <= 2)
                        {

                            try
                            {
                                tempOptions.Add(currentWord, accuracy + beans);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("1");
                            }


                        }
                        else if (tempOptions.Count >= 3)
                        {
                            try
                            {
                                tempOptions.Add(currentWord, accuracy + beans);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("3");
                            }



                            double minValue = tempOptions.Values.Min();
                            //its not removing anything 
                            var minKeyValuePair = tempOptions.OrderBy(kvp => kvp.Value).First(); ; //took from chat gpt need more knowledge on dictionarys


                            tempOptions.Remove(minKeyValuePair.Key);


                        }



                    }

                }

                }
                catch (Exception ex)
                {

                }
                // check if there are atleast 66% of the words correct in the word
                // add to list of options, if  



                // this will send back the options the user has to choose from.
            }

            foreach (var item in tempOptions)
            {
                options.Add(item.Key);
            }
            if (options.Count == 0)
            {
                string na = "no words found";
                options.Add(na);
            }


            return options;

        }



        public static List<string> TextRestorerWithChange(string text,int indexToChange,string newStringForIndex)
        {

            string wordSearch = "";
            string puncDropped = "";
            List<string> rebuiltUserInput = new List<string>();

            string[] textArray = text.Split(" ");


            for (int i = 0; i < textArray.Length; i++)  
            {      
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

               

                string wordChanged;

                if (i == indexToChange) //if the index of the loop of text is = to the word that is going to be changed in the iteration. we change that word.
                {

                    wordChanged = newStringForIndex;
                    // new word goes here

                }
                else { wordChanged = wordSearch; }// if the word isnt changed then it is importnat to return it with or without a comma.



                wordChanged += puncDropped; // word changed is the convereted and non converted word.;

                puncDropped = "";//this is not restoring the punctuation anymore.


                rebuiltUserInput.Add(wordChanged); // we are not changin the user text.

            }

            return rebuiltUserInput;
        }

    }
}

