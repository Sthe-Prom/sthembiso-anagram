using System;
using System.Collections.Generic;

namespace Anagrams
{
    public class AnagramCounter
    {
        public int WordLength { get; set; }

        public int Count { get; set; }

        public AnagramCounter(int wordLength, int count)
        {
            this.WordLength = wordLength;
            this.Count = count;
        }

    }
}