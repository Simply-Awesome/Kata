using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Core
{
    public class DiamondFormProvider : IFormProvider
    {
        private const string CarriageReturnAndNewLine = "\r\n";

        private readonly Dictionary<char, int> _alphabetToIndex = new Dictionary<char, int>
        {
            {'a', 1 },
            {'A', 1 },
            {'b', 2 },
            {'B', 2 },
            {'c', 3 },
            {'C', 3 },
            {'d', 4 },
            {'D', 4 },
            {'e', 5 },
            {'E', 5 },
            {'f', 6 },
            {'F', 6 },
            {'g', 7 },
            {'G', 7 },
            {'h', 8 },
            {'H', 8 },
            {'i', 9 },
            {'I', 9 },
            {'j', 10 },
            {'J', 10 },
            {'k', 11 },
            {'K', 11 },
            {'l', 12 },
            {'L', 12 },
            {'m', 13 },
            {'M', 13 },
            {'n', 14 },
            {'N', 14 },
            {'o', 15 },
            {'O', 15 },
            {'p', 16 },
            {'P', 16 },
            {'q', 17 },
            {'Q', 17 },
            {'r', 18 },
            {'R', 18 },
            {'s', 19 },
            {'S', 19 },
            {'t', 20 },
            {'T', 20 },
            {'u', 21 },
            {'U', 21 },
            {'v', 22 },
            {'V', 22 },
            {'w', 23 },
            {'W', 23 },
            {'x', 24 },
            {'X', 24 },
            {'y', 25 },
            {'Y', 25 },
            {'z', 26 },
            {'Z', 26 }
        };
        
        private readonly SortedDictionary<int, char> _indexToUppercaseAlphabet = new SortedDictionary<int, char>
        {
            {1, 'A' },
            {2, 'B'},
            {3, 'C' },
            {4, 'D' },
            {5, 'E' },
            {6, 'F' },
            {7, 'G' },
            {8, 'H' },
            {9, 'I' },
            {10, 'J' },
            {11, 'K' },
            {12, 'L' },
            {13, 'M' },
            {14, 'N' },
            {15, 'O' },
            {16, 'P' },
            {17, 'Q' },
            {18, 'R' },
            {19, 'S' },
            {20, 'T' },
            {21, 'U' },
            {22, 'V' },
            {23, 'W' },
            {24, 'X' },
            {25, 'Y' },
            {26, 'Z' }
        };
        
        public string GenerateForm(char alphabetCharacter)
        {
            if (!_alphabetToIndex.TryGetValue(alphabetCharacter, out int index))
            {
                throw new NotImplementedException("Alphabet has not been implemented!");
            }

            if (index == 1)
            {
                return CreateDiamondForLetterA(index);
            }

            var horizontalLayers = new Queue<string>();

            int horizontalGapBetweenLettersInHorizontalLayers = 0;
            
            AddTopHorizontalLayersForDiamond(horizontalLayers, index, ref horizontalGapBetweenLettersInHorizontalLayers);

            Queue<string> bottomHorizontalLayers = new Queue<string>(horizontalLayers.Reverse());

            AddMiddleHorizontalLayersForDiamond(horizontalLayers, index, horizontalGapBetweenLettersInHorizontalLayers);

            AddBottomHorizontalLayersForDiamond(horizontalLayers, bottomHorizontalLayers);

            return CreateDiamond(horizontalLayers);
        }

        private static string CreateDiamond(Queue<string> horizontalLayers)
        {
            return horizontalLayers
                .Aggregate(string.Empty, (current, horizontalLayer) => current + horizontalLayer)
                .TrimEnd(CarriageReturnAndNewLine.ToCharArray());
        }

        private string CreateDiamondForLetterA(int index)
        {
            return _indexToUppercaseAlphabet[index] + string.Empty;
        }

        private void AddTopHorizontalLayersForDiamond(Queue<string> horizontalLayers, int index, ref int horizontalGapBetweenLetters)
        {
            Dictionary<int, char> lettersForDiamondInTopOrBottomHalf = _indexToUppercaseAlphabet
                .Take(index - 1)
                .ToDictionary(i => i.Key, i => i.Value);

            var sortedLettersForDiamondInTopOrBottomHalf = new SortedDictionary<int, char>(lettersForDiamondInTopOrBottomHalf);

            int lettersForDiamondInTopOrBottomHalfCount = lettersForDiamondInTopOrBottomHalf.Count;

            foreach (KeyValuePair<int, char> sortedLetterForDiamondInTopOrBottomHalf in sortedLettersForDiamondInTopOrBottomHalf)
            {
                string prefixOrSuffixOfLetters = new string(' ', lettersForDiamondInTopOrBottomHalfCount);
                lettersForDiamondInTopOrBottomHalfCount -= 1;
                
                if (horizontalLayers.Count == 0)
                {
                    horizontalLayers.Enqueue(prefixOrSuffixOfLetters
                                             + sortedLetterForDiamondInTopOrBottomHalf.Value
                                             + prefixOrSuffixOfLetters
                                             + CarriageReturnAndNewLine);

                    horizontalGapBetweenLetters = 1;
                }
                else
                {
                    horizontalLayers.Enqueue(prefixOrSuffixOfLetters
                                             + sortedLetterForDiamondInTopOrBottomHalf.Value
                                             + new string(' ', horizontalGapBetweenLetters)
                                             + sortedLetterForDiamondInTopOrBottomHalf.Value
                                             + prefixOrSuffixOfLetters
                                             + CarriageReturnAndNewLine);

                    horizontalGapBetweenLetters += 2;
                }
            }
        }

        private void AddMiddleHorizontalLayersForDiamond(Queue<string> horizontalLayers, int index, int horizontalGapBetweenLetters)
        {
            horizontalLayers.Enqueue(_indexToUppercaseAlphabet[index]
                                     + new string(' ', horizontalGapBetweenLetters)
                                     + _indexToUppercaseAlphabet[index]
                                     + CarriageReturnAndNewLine);
        }

        private void AddBottomHorizontalLayersForDiamond(Queue<string> horizontalLayers, Queue<string> bottomHorizontalLayers)
        {
            foreach (string bottomHorizontalLayer in bottomHorizontalLayers)
            {
                horizontalLayers.Enqueue(bottomHorizontalLayer);
            }
        }
    }
}