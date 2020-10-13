using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Draw.Windows
{
    public static class GenerateData
    {

        /// <summary>
        /// Generates an array which looks like a sine wave.
        /// </summary>
        /// <param name="amountOfPillars">Amount of bars</param>
        /// <param name="array">The array we want to manipulate</param>
        /// <returns></returns>
        public static int[] GenerateSineArray(int amountOfPillars, int[] array)
        {
            double amplitude = 500;
            double frequency = 0.01;

            for (int i = 0; i < amountOfPillars; i++)
            {
                array[i] = (int)(amplitude * Math.Sin(2* Math.PI * 66 * i * frequency));
            }
            return array;
        }

        /// <summary>
        /// Go through an array and put every index to 0.
        /// </summary>
        /// <param name="array"> The em</param>
        /// <returns></returns>
        public static int[] GenerateArray(int amountOfPillars, int[] array)
        {
            for (int i = 0; i < amountOfPillars; i++)
            {
                array[i] = 0;
            }
            return array;
        }

        /// <summary>
        /// Returns an array of integers where none of the integers are recurring.
        /// </summary>
        /// <param name="values"> The amount of pillars we will need to get a number for.</param>
        /// <param name="min"> The smallest number possible to generate. </param>
        /// <param name="max"> The highest numver possible to generate.</param>
        /// <returns></returns>
        public static int[] GenerateRandomArray(int values, int min, int max, int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < values; i++)
            {
                array[i] = random.Next(min, max);
            }
            return array;
        }
    }
}
