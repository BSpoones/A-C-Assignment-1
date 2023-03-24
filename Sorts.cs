using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Assignment_1
{
    public class Sorts
    {
        /*
         * Counting sort method
         * Takes a list of type int and sorts using a Counting sort
         * https://www.geeksforgeeks.org/counting-sort/
        */
        public static List<int> CountingSort(List<int> roadList, bool reverse = false)
        {
            /*
             * This function does the following steps in order to sort an array
             * 
             * - Finds the largest value in the array
             * - Creates a list the length of the largest value, setting each item to 0
             * - Iterates through the array, adding 1 to the conting list at the position of the value in the array
             *   e.g if the array value is 15, it adds 1 to countingList[16]
             * - Iterates through the list, adding values to a new list depending on the occurance
             *   e.g a countingList of [0,0,1,3,5] would be [2,3,3,3,4,4,4,4,4]
             * - Reverses the list if reverse == true
             */

            // Finding the maximum value by iterating through the list until the max
            // value is found - O(n)
            int steps = 0;

            int max = roadList[0];
            for (int i = 1; i< roadList.Count; i++)
            {
                steps++;
                if (roadList[i] > max)
                {
                    max = roadList[i];
                }
            }

            // Creating a list of 0s of length max
            steps++;
            int[] countingList = new int[max+1];

            // Iterating through roadList, adding to countingList depending on the value
            for (int i = 0; i < roadList.Count; i++)
            {
                steps++;
                countingList[roadList[i]]++;
            }

            List<int> outputList = new();
            // Iterating through countingList, adding values to outputList based on their occurence
            // in countingList
            for (int i = 0; i < countingList.Length; i++)
            {
                steps++;
                int occurences = countingList[i];
                for (int j = 0; j < occurences; j++)
                {
                    steps++;
                    if (occurences != 0)
                    {
                        outputList.Add(i);
                    }
                    
                }
            }
            // Console.WriteLine("Counting Steps: " + steps);
            // Reversing the list (descending order) if the user specifies
            if (reverse)
            {
                return ReverseList(outputList);
            }

            return outputList;
        }

        /*
         * Quick sort method
         * Takes a list of type int and sorts via a Quick sort
         * https://www.geeksforgeeks.org/quick-sort/
         */
        public static int QuickSteps = 0;
        public static List<int> QuickSort(List<int> roadList, bool reverse = false)
        {
            /*
             * This function does the following steps in order to sort an array
             * 
             * - Uses the last item of an array as a pivot
             * - Iterates from the start of the array with 2 values (i and j). 
             * - If j > pivot, j moves forward one, if j < pivot, i moves forward one
             *   as long as i and j aren't in the same place after the move
             * - If i > j, they are swapped
             * - This continues until j is at the same pisition as the pivot
             * - Once j is in the same position as the pivot, the pivot and i+1 are swapped
             * - The last 7 points are recursively repeated on the left and right side 
             *   until the array length is 1
             * - Once the array length is 1, we know that the list is sorted
             * 
             */
            List<int> outputList = new List<int>(roadList);
            QuickSteps++;
            DoQuickSort(outputList, 0, outputList.Count - 1);

            // Reversing the list (descending order) if the user specifies
            if (reverse)
            {
                outputList = ReverseList(outputList);
            }
            // Console.WriteLine("QuickSteps" + QuickSteps);
            return outputList;
        }
        private static List<int> DoQuickSort(List<int> roadList, int start, int end)
        {
            // If the list section length is <= 1
            if (end <= start) return roadList;

            // Partitioning the array until all items on the left < pivot
            // and all items on the right > pivot
            int pivot = Partition(roadList, start, end);
            QuickSteps++;
            // Recursively sorting the left and right side until sorted

            DoQuickSort(roadList, start, pivot - 1);
            DoQuickSort(roadList, pivot + 1, end);
            QuickSteps++;
            QuickSteps++;
            return roadList;
        }
        private static int Partition(List<int> roadList, int start, int end)
        {
            // Selecting the end element as the partition
            int pivot = roadList[end];

            /*
             * Rules for following loop:
             * 
             * if arr[j] > pivot, ignore and increment j
             * if arr[j] < pivot, increment i and swap i and j
             */

            // Index of first element
            int i = start - 1;
            int j = start;
            while (j<end)
            {
                QuickSteps++;
                if (roadList[j] < pivot)
                {
                    QuickSteps++;
                    // Swapping elements and incrementing i if j < pivot
                    i++;
                    (roadList[i], roadList[j]) = (roadList[j], roadList[i]);
                }
                j++;
            }
            // When j reaches the pivot, swap the pivot and i to create a new pivot
            i++;
            QuickSteps++;
            (roadList[i], roadList[end]) = (roadList[end], roadList[i]);
            return i;
        }

        /*
         * Bubble sort method
         * Takes a list of type int and sorts via a Quick sort
         * https://www.geeksforgeeks.org/bubble-sort/
         */
        public static List<int> BubbleSort(List<int> roadList)
        {
            /*
             * This function does the following steps in order to sort an array
             * 
             * - Create a pair from the first two items in the list
             * - Swap them if they aren't in the right order
             * - Move the pair across one
             * - Swap them if they aren't in the right order
             * - Keep going until the end of the list is reached
             * - Start again, stopping at the 2nd last item (last unsorted item) and so on
             * - Continue until the list is sorted
             * 
             */

            // Creating pairs (i and j)
            int BubbleCount = 0;
            for (int i = 0; i < roadList.Count; i++)
            {
                // Continue going, stopping at the correct item in each list
                for (int j = 0; j < roadList.Count-i-1; j++)
                {
                    if (roadList[j] > roadList[j + 1])
                    {
                        // Swapping elements
                        BubbleCount++;
                        (roadList[j], roadList[j + 1]) = (roadList[j + 1], roadList[j]);
                    }
                }
            }
            // Console.WriteLine("BubbleSteps" + BubbleCount);
            return roadList;
        }

        /*
         * Merge sort method
         * Takes a list of type int and sorts via a Quick sort
         * https://www.geeksforgeeks.org/merge-sort/
         */
        public static int MergeSteps = 0;
        public static List<int> MergeSort(List<int> roadList, bool reverse = false)
        {
            /*
             * This function does the following steps in order to sort an array
             * 
             * - Recursively splits a list until it reaches items of length 1
             * - Merges each item together up a metaphorical tree, sorting them via merging
             * 
             */
            MergeSteps++;
            List<int> outputList = new List<int>(roadList);
            DoMergeSort(outputList);

            // Reversing the list (descending order) if the user specifies
            if (reverse)
            {
                outputList = ReverseList(outputList);
            }
            // Console.WriteLine(MergeSteps);
            return outputList;
        }
        private static void DoMergeSort(List<int> roadList)
        {
            
            int listLength = roadList.Count;
            if (listLength <= 1) return;

            MergeSteps++;
            int middle = listLength / 2;
            List<int> leftList = new();
            List<int> rightList = new();

            // Splitting list into left and right side
            for (int i = 0; i < listLength; i++)
            {
                if (i < middle)
                {
                    MergeSteps++;
                    leftList.Add(roadList[i]);
                }
                else
                {
                    MergeSteps++;
                    rightList.Add(roadList[i]);
                }
            }
            // Keeps splitting them until each element has length 1
            MergeSteps++; MergeSteps++;
            DoMergeSort(leftList);
            DoMergeSort(rightList);

            // Merges the lists back together again
            MergeSteps++;
            Merge(leftList, rightList, roadList);

        }
        private static void Merge(List<int> leftList, List<int> rightList, List<int> roadList)
        {
            // Merge sort algorithm based on example from Merge sort citation (see report)

            // Calculating sizes of the left and right lists
            int leftSize = leftList.Count;
            int rightSize = rightList.Count;
            MergeSteps++;
            int i = 0, leftIndex = 0, rightIndex = 0; // indicies

            // check conditions for merging

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                // While there are items in both halves to check
                if (leftList[leftIndex] < rightList[rightIndex])
                {
                    // If the left value is larger than the right
                    MergeSteps++;
                    roadList[i] = leftList[leftIndex];
                    i++; leftIndex++;
                }
                else
                {
                    // If the right value is larger than the left
                    MergeSteps++;
                    roadList[i] = rightList[rightIndex];
                    i++; rightIndex++;
                }
            }
            while (leftIndex < leftSize)
            {
                // If there are items left in the left list
                MergeSteps++;
                roadList[i] = leftList[leftIndex];
                i++; leftIndex++;
            }
            while (rightIndex < rightSize)
            {
                // If there are items left in the right list
                MergeSteps++;
                roadList[i] = rightList[rightIndex];
                i++; rightIndex++;
            }
        }

        public static List<int> ReverseList(List<int> inputList)
        {
            /*
             * Reverses a list via a for loop
             * Creates a new list and adds items in reverse order
             */
            List<int> outputList = new();
            for (int i = inputList.Count-1; i >=0; i--)
            {
                outputList.Add(inputList[i]);
            }
            return outputList;
        }
    }
}
