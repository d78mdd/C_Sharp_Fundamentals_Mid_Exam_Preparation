using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(' ')
                .ToList();

            elements.Remove(string.Empty);

            int moves = 0;

            for (; ; )
            {
                string input = Console.ReadLine().Trim();

                if (input.Equals("end"))
                {
                    break;
                }

                int[] move = input
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (HaveHitAllMatchingElements(elements))
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }

                moves++;

                if (IsInvalidMove(elements, move))
                {
                    string additionalElement = $"-{moves}a";

                    int sequenceMiddleIndex = elements.Count / 2;

                    elements.Insert(sequenceMiddleIndex, additionalElement);
                    elements.Insert(sequenceMiddleIndex, additionalElement);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    continue;
                }

                if (AreMoveElementsEqual(elements, move))
                {
                    string element = elements.ElementAt(move[0]);
                    Console.WriteLine($"Congrats! You have found matching elements - {element}!");

                    int secondIndex = Math.Max(move[0], move[1]);
                    int firstIndex = Math.Min(move[0], move[1]);

                    elements.RemoveAt(secondIndex);
                    elements.RemoveAt(firstIndex);

                }
                else // two different elements
                {
                    Console.WriteLine("Try again!");
                }


            }


            if (!HaveHitAllMatchingElements(elements))
            {
                Console.WriteLine("Sorry you lose :(");
                foreach (string element in elements)
                {
                    Console.Write($"{element} ");
                }

            }

        }

        private static bool HaveHitAllMatchingElements(List<string> elements)
        {
            return elements.Count == 0;
        }

        private static bool AreMoveElementsEqual(List<string> elements, int[] move)
        {
            return elements.ElementAt(move[0]) == elements.ElementAt(move[1]);
        }

        private static bool IsInvalidMove(List<string> elements, int[] move)
        {
            return move[0] == move[1] ||
                                (move[0] < 0 || move[0] >= elements.Count ||
                                 move[1] < 0 || move[1] >= elements.Count);
        }


    }
}
