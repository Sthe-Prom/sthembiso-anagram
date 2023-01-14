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
            //Dictionary Key(Word Length) and Value(Word List), allows for faster checking of anagrams words 
            //with equal lengths.
            Dictionary<int, List<string>> dicWordCount = new Dictionary<int, List<string>>();
            List<string> tempWords = new List<string>();

            foreach (string word in words) 
            {
                int wordLength = word.Length;
                if(dicWordCount.ContainsKey(wordLength))
                {
                    //Update values in a dictionary for existing found key 
                    dicWordCount[wordLength].Add(word);                  
                }
                else
                {
                    //Add to dictionary if key is new
                    //List<string> newList = new List<string>();
                    //newList.Add(word);                                                                   
                    dicWordCount[wordLength] = new List<string>{word};                   
                }
            }
            
            //Store AnagramService return values
            List<AnagramCounter> anagramCounter = new List<AnagramCounter>();   

            foreach (var item in dicWordCount)
            {
                // var an = new AnagramCounter(item.Key, item.Value.Count);
                // an.WordLength = item.Key;
                // an.Count = item.Value.Count;
                // anagramCounter.Add(an);

                anagramCounter.Add(countAnagrams(item.Key, item.Value)); //Add anagramCounter object to anagramCounter list for all dictionary items
            }

            return anagramCounter;
          
        }     
      
        public static bool IsAnagram(string subject_, string anagramCandidate_)
        {
            var subject = ProcessWord(subject_);
            var anagramCandidate = ProcessWord(anagramCandidate_);
            return subject.Count == subject.Where(x => anagramCandidate.Contains(x)).ToList().Count;

            // var isAnagram = subject.OrderBy(c => c).SequenceEqual(anagramCandidate.OrderBy(c => c));
            // return isAnagram;
        }

        public static List<(Char Key, int Count)> ProcessWord(string subject_)
        {           
            return subject_.Replace(" ", "").ToLower().GroupBy(c => c)
                .Select(x => (x.Key, Count: x.Count())).ToList();
        }

        public static AnagramCounter countAnagrams(int wordLength, List<string> words)
        {            
            int countAnagrams = 0;

            for (int i = 0; i < words.Count; i++) {

                string subject = words[i]; //the subject word in the list

                for (int x = 0; x < words.Count; x++) {

                    string candidateAnagram = words[x]; //the anagram candidate word

                    if (x != i) {
                        if(IsAnagram(subject, candidateAnagram)){
                            countAnagrams++; //if subject is found to be anagram against candidate --add 1 to the count of anagrams for that subject
                        }
                    }
                }
            }  

            //Console.WriteLine(wordLength + " " + words.Count);
            return new AnagramCounter(wordLength, countAnagrams); //Return wordLength as (--expected dictionary Key), and countAnagrams as (--sum of anagrams found for all words in list of words for this wordLength)
        }
        
    }
}