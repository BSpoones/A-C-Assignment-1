using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Assignment_1
{
    public class Tasks
    {
        public static void TaskMenu()
        {
            while (true)
            {
                // Taking user input to decide which task to undertake
                Console.WriteLine("Select task to do (1-7) or EXIT to quit");
                string userInput = Console.ReadLine();

                // Using a string oriented switch statement as it doesn't
                // require error handling
                switch (userInput.ToLower())
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3and4();
                        break;
                    case "4":
                        Console.WriteLine("Task 4 is an extension of task 3, you will now be redirected to task 3...");
                        Task3and4();
                        break;
                    case "5":
                        Task5();
                        break;
                    case "6":
                        Task6();
                        break;
                    case "7":
                        Task7();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        continue;
                }
            }
        }
        public static void Task1()
        {
            Console.WriteLine("--------- [ Task 1 ] ---------\n");
            Console.WriteLine("Text files are read and arrays are initialised at runtime. This has already been done.");
        }
        public static void Task2()
        {
            Console.WriteLine("--------- [ Task 2 ] ---------\n");
            // Sort the 3 256 length arrays into ascending and descending order
            // and output the array at every 10th value
            Console.WriteLine($"Roads 1,2, and 3 (256 length) sorted in ascending order every 10th value:");
            OutputListStep(Sorts.QuickSort(Roads.Road_1_256),10);
            OutputListStep(Sorts.MergeSort(Roads.Road_2_256),10);
            OutputListStep(Sorts.BubbleSort(Roads.Road_3_256),10);

            Console.WriteLine($"\nRoads 1,2, and 3 (256 length) sorted in descending order every 10th value:");
            OutputListStep(Sorts.CountingSort(Roads.Road_1_256, true), 10);
            OutputListStep(Sorts.QuickSort(Roads.Road_2_256, true), 10);
            OutputListStep(Sorts.MergeSort(Roads.Road_3_256, true), 10);
        }
        public static void Task3and4()
        {
            Console.WriteLine("--------- [ Task 3 (and 4) ] ---------\n");
            Console.WriteLine("Select Road 1-3\n1 - Road 1\n2 - Road 2\n3 - Road 3");
            string roadChoice = Console.ReadLine();
            List<int> outputList = new();

            // Choosing each list
            switch (roadChoice.ToLower())
            {
                case "1":
                    outputList = Sorts.QuickSort(Roads.Road_1_256);
                    break;
                case "2":
                    outputList = Sorts.MergeSort(Roads.Road_2_256);
                    break;
                case "3":
                    outputList = Sorts.BubbleSort(Roads.Road_3_256);
                    break;
            }

            // Search value selection
            Console.WriteLine("Select value to search");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            List<int> searchIndexes = Searches.LinearSearch(outputList, searchValue);
            
            // Outputting indexes
            if (searchIndexes.Count > 0)
            {
                Console.WriteLine($"{searchValue} found at index {string.Join(",", searchIndexes)}");
            }
            else
            {
                // searchValue not found (TASK 4)
                Console.WriteLine($"{searchValue} is not in the list.");
                FindNearest(outputList, searchValue);
            }
        }
        public static void Task5()
        {
            Console.WriteLine("--------- [ Task 5 ] ---------\n");
            // Sorts the 2048 length lists, outputs every 50th item, and prompts a user input for searching
            // Esensially tasks 2-4 with the 2048 length lists

            // Task 2 with 2048 length lists
            Console.WriteLine($"Roads 1,2, and 3 (2048 length) sorted in ascending order every 50th value:");
            OutputListStep(Sorts.QuickSort(Roads.Road_1_2048), 50);
            OutputListStep(Sorts.MergeSort(Roads.Road_2_2048), 50);
            OutputListStep(Sorts.BubbleSort(Roads.Road_3_2048), 50);

            Console.WriteLine($"\nRoads 1,2, and 3 (2048 length) sorted in descending order every 50th value:");
            OutputListStep(Sorts.CountingSort(Roads.Road_1_2048, true), 50);
            OutputListStep(Sorts.QuickSort(Roads.Road_2_2048, true), 50);
            OutputListStep(Sorts.MergeSort(Roads.Road_3_2048, true), 50);

            // Task 3 and 4
            Console.WriteLine("Select Road 1-3");
            string roadChoice = Console.ReadLine();
            List<int> outputList = new();
            switch (roadChoice.ToLower())
            {
                case "1":
                    outputList = Sorts.QuickSort(Roads.Road_1_2048);
                    break;
                case "2":
                    outputList = Sorts.MergeSort(Roads.Road_2_2048);
                    break;
                case "3":
                    outputList = Sorts.BubbleSort(Roads.Road_3_2048);
                    break;
            }

            Console.WriteLine("Select value to search");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            List<int> searchIndexes = Searches.LinearSearch(outputList, searchValue);

            if (searchIndexes.Count > 0)
            {
                Console.WriteLine($"{searchValue} found at index {string.Join(",", searchIndexes)}");
            }
            else
            {
                Console.WriteLine($"{searchValue} was not found.");
                FindNearest(outputList, searchValue);
            }
        }
        public static void Task6()
        {
            Console.WriteLine("--------- [ Task 6 ] ---------\n");
            // Merges the 256 road 1 and 3, and repeats tasks 2-4

            // Combining and sorting both lists
            List<int> mergedList = new();
            mergedList.AddRange(Roads.Road_1_256);
            mergedList.AddRange(Roads.Road_3_256);
            mergedList = Sorts.CountingSort(mergedList);

            // Task 2, using 10 as step as list length is 256
            OutputListStep(mergedList, 10);

            // Task 3 and 4
            Console.WriteLine("Select value to search");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            List<int> searchIndexes = Searches.LinearSearch(mergedList, searchValue);

            if (searchIndexes.Count > 0)
            {
                Console.WriteLine($"{searchValue} found at index {string.Join(",", searchIndexes)}");
            }
            else
            {
                Console.WriteLine($"{searchValue} was not found.");
                FindNearest(mergedList, searchValue);
            }
        }
        public static void Task7()
        {
            Console.WriteLine("--------- [ Task 7 ] ---------\n");
            // Does the same as task 6 using the 2048 versions

            // Merging and sorting both lists
            List<int> mergedList = new();
            mergedList.AddRange(Roads.Road_1_2048);
            mergedList.AddRange(Roads.Road_3_2048);
            mergedList = Sorts.CountingSort(mergedList);

            // Task 2 - Using 50 as step as length is 2048
            OutputListStep(mergedList, 50);

            // Task 3 and 4
            Console.WriteLine("Select value to search");
            int searchValue = Convert.ToInt32(Console.ReadLine());
            List<int> searchIndexes = Searches.LinearSearch(mergedList, searchValue);

            if (searchIndexes.Count > 0)
            {
                Console.WriteLine($"{searchValue} found at index {string.Join(",", searchIndexes)}");
            }
            else
            {
                Console.WriteLine($"{searchValue} was not found.");
                FindNearest(mergedList, searchValue);
            }
        }

        private static void OutputListStep(List<int> outputList, int step)
        {
            // Outputs a list step items at a time
            for (int i = 0; i < outputList.Count; i+=step){
                Console.Write(outputList[i] + " ");
            }
            Console.WriteLine();
        }

        private static void FindNearest(List<int> roadList, int value)
        {
            // Assumes that item is not in list
            // Checks items ++ and -- of the value until one is found
            // returns the position and value of the nearest values
            bool found = false;
            int lowerValue = value, higherValue = value;
            int largestValue = roadList[roadList.Count-1];
            int smallestValue = roadList[0];
            List<int> foundItems = new();
            while (!found)
            {
                lowerValue--;
                higherValue++;
                if (lowerValue >= smallestValue)
                {
                    List<int> searchValues = Searches.LinearSearch(roadList, lowerValue);
                    if (searchValues.Count > 0 && searchValues[0] != -1)
                    {
                        foundItems.Add(searchValues[0]);
                    }

                }
                if (higherValue <= largestValue)
                {
                    List<int> searchValues = Searches.BinarySearch(roadList, higherValue);
                    if (searchValues.Count > 0 && searchValues[0] != -1)
                    {
                        foundItems.Add(searchValues[0]);
                    }

                }
                if (foundItems.Count > 0)
                {
                    found = true;
                }

            }

            // Formatting output
            string indexes = string.Join(",", foundItems);
            List<int> valueList = new();
            foreach(int i in foundItems)
            {
                valueList.Add(roadList[i]);
            }
            string values = string.Join(",", valueList);
            Console.WriteLine($"Nearest indexes are {indexes} which have values {values}");
        }
    }
}
