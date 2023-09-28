﻿
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
                        if (i != firstPart.Length - 1)
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



            for (int i = 0; i < incorrect.Count; i++)
            {
                // recommendedFix(incorrect[i]);
                HashSet<string> options = recommendedFix(incorrect[i], allLines);
            }

            //would you like to apply these corrections to the words ?

        }

        public static HashSet<string> recommendedFix(string word, List<string> dictionary)
        {
            HashSet<string> options = new HashSet<string>();
            char[] incorrectWord = convertText.wordStripper(word);
            Dictionary<string, double> tempOptions = new Dictionary<string, double>();

            foreach (var currentWord in dictionary)
            {
                char[] wordsInDictionary = convertText.wordStripper(currentWord);

                if (word.Length >= 6)
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
                                double min = 0.00002;

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

                                    var keyWithMinValue = tempOptions.First(kvp => kvp.Value == minValue).Key; //took from chat gpt need more knowledge on dictionarys

                                    tempOptions.Remove(keyWithMinValue);
                                }
                            

                            foreach (var item in tempOptions)
                            {
                                options.Add(item.Key);
                            }
                        }
                    }

                }
                else if (word.Length <= 5)
                {

                    if (wordsInDictionary[0] == incorrectWord[0])
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
                            double length = (currentWord.Length);

                            if ((counter / length) > 0.6)
                            {

                                if (word.Length == currentWord.Length + 1 || word.Length == currentWord.Length - 1)
                                {

                                    options.Add(currentWord);
                                }
                                else if (word.Length == currentWord.Length)
                                {
                                    options.Add(currentWord);
                                }

                            }

                        }

                    }
                }
                else
                {
                    string na = "no words found";

                    options.Add(na);
                }
                // check if there are atleast 66% of the words correct in the word
                // add to list of options, if  



                // this will send back the options the user has to choose from.
            }

            foreach (var item in options)
            {
                Console.WriteLine(item);
            }

            return options;
        }
    }
}

//Notes:
// does the dictionary get split into the profieceny levels,,,
// nooo the file will store the words for the proficenys name of the text file can be changed as per the proficency level.

// then based on the proficeny that will be used for the entirety of the program, which can be changed when the proficeny level is changed.
