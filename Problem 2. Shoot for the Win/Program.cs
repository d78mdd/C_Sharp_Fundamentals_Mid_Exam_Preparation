using System;
using System.Linq;

namespace Problem_2.Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int shotTargets = 0;

            // shoot targets
            for (; ; )
            {
                string input = Console.ReadLine();

                if (input.Equals("End"))
                {
                    break;
                }

                int shot = int.Parse(input);

                if (!IsValidIndex(targets, shot))
                {
                    continue;
                }

                int currentShotValue = targets[shot];
                targets[shot] = -1;

                IncreaseDecreaseValues(targets, shot, currentShotValue);

                shotTargets++;
            }

            Console.Write($"Shot targets: {shotTargets} -> ");
            foreach (int target in targets)
            {
                Console.Write(target + " ");
            }

        }

        private static void IncreaseDecreaseValues(int[] targets, int shot, int currentShotValue)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (i == shot)
                {
                    continue;
                }

                if (targets[i] == -1)
                {
                    continue;
                }

                if (targets[i] > currentShotValue)
                {
                    targets[i] -= currentShotValue;
                }
                else // case if (targets[i] <= currentShotValue)
                {
                    targets[i] += currentShotValue;
                }

            }
        }

        private static bool IsValidIndex(int[] array, int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
