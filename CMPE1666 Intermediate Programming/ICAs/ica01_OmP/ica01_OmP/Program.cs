/*
 * Name: Om Maheshkumar Patel
 * Assignment :- ICA01 - linear Search 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA1_OmP
{
    internal class Program
    {
        // ---------------------------------------------------------
        // Main: This is where the program starts. It shows the title,
        //       asks the user for array size and range, generates the
        //       array, displays it, and then lets the user search for
        //       values in a loop until they decide to quit.
        // ---------------------------------------------------------
        static void Main(string[] args)
        {
            Console.SetCursorPosition((Console.WindowWidth - "ICA01 - Om Maheshkumar Patel".Length) / 2, 0);
            Console.WriteLine("ICA01 - Om Maheshkumar Patel");
            Console.WriteLine();

            int n = GetValue("Input the size of the array to generate", 10, 100);

            int low, high;
            GetRange(out low, out high);

            int[] numbers = GenerateArray(n, low, high);
            Console.Write("The generated values are: ");
            DisplayArray(numbers);
            Console.WriteLine();

            string again;
            do
            {
                int searchVal = GetValue("Enter Value to be searched", low, high);

                int hits = CountOccurrences(numbers, searchVal);

                if (hits > 0)
                {
                    Console.WriteLine($"Number of Occurrences of {searchVal} is {hits}");
                }
                else
                {
                    Console.WriteLine($"{searchVal} not found in array");
                }
                Console.WriteLine();

                do
                {
                    Console.Write("Do you want to search for another value? (Y/N, y/n): ");
                    again = Console.ReadLine().Trim().ToLower();

                    if (again != "y" && again != "n")
                    {
                        Console.WriteLine("You should respond by: Y,y,N or n. Please input again");
                        Console.WriteLine();
                    }
                } while (again != "y" && again != "n");

                Console.WriteLine();

            } while (again == "y");

            Console.WriteLine("Program exited.");
        }

        //********************************************************************************************
        // GetValue: Shows a prompt and waits for input. Keeps asking until
        //           the user types a valid integer within the given range.
        // Returns:  The confirmed number.
        //***********************************************************************************************************
        static int GetValue(string prompt, int min, int max)
        {
            int value;
            bool valid;
            do
            {
                Console.Write($"{prompt} ({min}-{max}): ");
                string input = Console.ReadLine();

                valid = int.TryParse(input, out value);
                if (!valid)
                {
                    Console.WriteLine("The input value is not valid- You have to input another value");
                    Console.WriteLine();
                    continue;
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"The input is out of range- You have to input in the range {min}-{max}");
                    Console.WriteLine();
                    valid = false;
                }
                Console.WriteLine();
            } while (!valid);

            return value;
        }

        //********************************************************************************************
        // GetRange: Asks the user for a lower and upper bound. Uses GetValue
        //           for input and only accepts ranges where upper > lower.
        // Returns:  The two limits through out parameters.
        //********************************************************************************************
        static void GetRange(out int lower, out int upper)
        {
            bool ok;
            do
            {
                lower = GetValue("Enter the lower limit of the range of values to generate", 0, 100);
                upper = GetValue("Enter the upper limit of the range of values to generate", 0, 100);

                ok = upper > lower;
                if (!ok)
                {
                    Console.WriteLine("Upper limit must be greater than lower limit. Please try again.");
                }
            } while (!ok);
        }

        //********************************************************************************************
        // GenerateArray: Builds an array filled with random numbers between
        //                the given lower and upper bounds (inclusive).
        // Returns:       A new array of random values.
        //********************************************************************************************
        static int[] GenerateArray(int count, int lower, int upper)
        {
            int[] data = new int[count];
            Random rng = new Random();

            for (int i = 0; i < count; i++)
            {
                data[i] = rng.Next(lower, upper + 1); 
            }

            return data;
        }

        //********************************************************************************************
        // DisplayArray: Prints all numbers in the array to the console,
        //               separated by commas for easy reading.
        //********************************************************************************************
        static void DisplayArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i >= 0) 
                Console.Write(arr[i]+", ");
            }
            Console.WriteLine();
        }

        //********************************************************************************************
        // CountOccurrences: Looks through the array one element at a time
        //                   and counts how many times the target value appears.
        // Returns:          The number of matches found.
        //********************************************************************************************
        static int CountOccurrences(int[] arr, int value)
        {
            int count = 0;
            foreach (int v in arr)
            {
                if (v == value)
                    count++;
            }
            return count;
        }
    }
}
