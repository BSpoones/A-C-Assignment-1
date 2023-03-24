using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Assignment_1
{
    public class Searches
    {
        public static List<int> LinearSearch(List<int> roadList, int value)
        {
            /*
             * Linear search method
             * 
             * Iterates through all items in a list, adding all
             * matching indexes to foundIndexes
             */
            int LinearCount = 0;
            List<int> foundIndexes = new();
            for (int i = 0; i < roadList.Count; i++)
            {
                LinearCount++;
                if (roadList[i] == value)
                {
                    foundIndexes.Add(i);
                }
            }
            // Console.Write("Linear Count: "+ LinearCount);
            return foundIndexes;
        }
        public static int BinaryCount = 0;
        public static List<int> BinarySearch(List<int> roadList, int value)
        {
            
            /*
             * Binary search method
             * 
             * This method recursively runs DoBinarySearch in order to get every
             * instance of a value in a list via a binary search
             */

            // To find duplicates, keep doing a binary search, but remove the index of a found value
            // every time, then fix the index numbers based on the indexList length


            List<int> outputList = Sorts.QuickSort(roadList);
            List<int> indexList = new();
            // Finding first occurence
            int index = DoBinarySearch(outputList, value);
            indexList.Add(index);

            // Finds all duplicates by recursively running binary search and removing
            // all found indexes
            while (index != -1) // Index is found
            {
                outputList.RemoveAt(index);
                index = DoBinarySearch(outputList, value);
                indexList.Add(index+indexList.Count); // Adds length of indexList to account for removed indexes
            }

            // Console.WriteLine("Binary Count "+BinaryCount);
            // If no indexes are found, an empty list is returned
            return indexList;
           
        }

        private static int DoBinarySearch(List<int> roadList, int value)
        {
            int first = 0;
            int last = roadList.Count - 1;
            while (first <= last) {
                int middle = (first + last) / 2; // Calculating midpoint
                if (roadList[middle] < value)
                {
                    // Moving view to the right
                    BinaryCount++;
                    first = middle + 1;
                }
                else if (roadList[middle] > value)
                {
                    // Moving view to the left
                    BinaryCount++;
                    last = middle - 1;
                }
                else
                {
                    // Value has been found
                    BinaryCount++;
                    return middle;
                }
                
            }
            return -1; // -1 indicates value not found
        }
    }
}
