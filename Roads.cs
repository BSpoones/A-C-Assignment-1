using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC_Assignment_1
{
    class Roads
    {
        // Path to RoadFiles directory
        // When debugging and running the program, it is run in /bin/debug/net6.0
        // therefore the file needs to be 3 folders up
        private static readonly string directory = @"..\..\..\Roadfiles\";

        // Initialising all 6 roads
        public static readonly List<int> Road_1_256 = InitRoad("Road_1_256.txt");
        public static readonly List<int> Road_1_2048 = InitRoad("Road_1_2048.txt");
        public static readonly List<int> Road_2_256 = InitRoad("Road_2_256.txt");
        public static readonly List<int> Road_2_2048 = InitRoad("Road_2_2048.txt");
        public static readonly List<int> Road_3_256 = InitRoad("Road_3_256.txt");
        public static readonly List<int> Road_3_2048 = InitRoad("Road_3_2048.txt");

        public static List<int> InitRoad(string filepath)
        {
            /*
             * InitRoad function
             * Reads text file of given filepath and converts
             * to an int array
             */
            string[] lines = File.ReadAllLines(directory + filepath);
            int[] road = lines.Select(int.Parse).ToArray();

            List<int> roadList = new();
            for (int i = 0; i < road.Length; i++)
            {
                roadList.Add(road[i]);
            }
            return roadList;
        } 
    }
}
