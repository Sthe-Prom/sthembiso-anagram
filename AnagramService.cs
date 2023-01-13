using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
    public class AnagramService
    {
        //Calculate anagrams for each word from a given words list
        public IEnumerable<AnagramCounter> Compute(IList<string> words)
        {
            //Dictionary Key(Word Length) and Value(Word List), allows for easy checking anagrams of words 
            //with equal length.
            Dictionary<int, List<string>> dicWordCount = new Dictionary<int, List<string>>();
            List<string> tempWords = new List<string>();

            foreach (string word in words) 
            {
                int wordLength = word.Length;
                if(dicWordCount.ContainsKey(wordLength))
                {
                    //Update values in a dictionary for existing key 
                    dicWordCount[wordLength].Add(word);                  
                }
                else
                {
                    //Add to dictionary
                    List<string> newList = new List<string>();
                    newList.Add(word);                                                                   
                    dicWordCount[wordLength] = newList;                   
                }
            }
            
            //Store AnagramService return values
            List<AnagramCounter> angramCounter = new List<AnagramCounter>();   

            foreach (var item in dicWordCount)
            {
                angramCounter.Add(countAnagrams(item.Key, item.Value)); 
            }

            return angramCounter;
          
        }
     
      
        public static bool IsAnagram(string word, string dest)
        {
            var isAnagram = word.OrderBy(c => c).SequenceEqual(dest.OrderBy(c => c));
            return isAnagram;
        }

        public static AnagramCounter countAnagrams(int wordLength, List<string> words)
        {            
            int countAnagrams = 0;

            for (int i = 0; i < words.Count; i++) {

                string word = words[i];

                for (int x = 0; x < words.Count; x++) {

                    string compare = words[x];

                    if (x != i) {
                        if(IsAnagram(word, compare)){
                            countAnagrams++;
                        }
                    }
                }
            }  

            Console.WriteLine(wordLength + " " + words.Count);
            return new AnagramCounter(wordLength, 0);
        }
        
    }
}