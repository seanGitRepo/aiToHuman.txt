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
					wordSearch = lowerAll[i];//this means that if a word fails we can just but it back as textarray, or if the user enters an inccorect word/
				}

				wordStorage.Add(wordSearch);
				wordSearch = "";
			}


                return wordStorage;
		}

		public static void GeneralRun(string text)
		{

            string wordSearch = "";
            string puncDropped = "";
            List<string> rebuiltUserInput = new List<string>();

            string[] textArray = text.Split(" ");//this split is working correctly
			for (int i = 0; i < textArray.Length; i++) // this iteration is the length of the file to be changed 
			{                                          // using the mona lisa: "the mona lisa" i0 = the
													   //i currently = the, so we need to split the entire string to check for the last chr to = puncts
				char[] charArray = textArray[i].ToCharArray();

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

			while (correct != 1)
			{

				if (choice == "file" || choice == "console")
				{
					correct = 1;
				}
				else
				{
					correct = 0;
					Console.WriteLine("please try again");
					choice = Console.ReadLine();
				}

			}

		

			if (choice == "file" || choice == "File") // if the user wants to use a file.
			{
				string f = "../../../OutputText/output.txt";

				File.WriteAllText(f,$"Created by: Sean\n");
				File.AppendAllText(f,string.Join(" ", rebuiltUserInput.ToArray()));

				
			}
			else if (choice == "console" || choice == "Console")
			{
				Console.WriteLine("Created by: Sean Saap");
				Console.WriteLine(string.Join(" ", rebuiltUserInput.ToArray()));
			}
			Console.ReadLine();
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
			
	}
}

