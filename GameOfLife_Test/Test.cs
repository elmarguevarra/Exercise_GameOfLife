
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ConsoleApp1.Program;

namespace GameOfLife_Test
{
    public class Test
    {
        public static void Main(string[] args)
        {
            TestGameOfLife();
        }

        public static void TestGameOfLife()
        {
            var inputMatrix = new int[6, 6] {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };

            var gameOfLifeObj = new GameOfLife()
            {
                iterations = 1,
                matrix = inputMatrix
            };

            var actualResults = Program.StartGameOfLife(gameOfLifeObj);
            var mockResult = inputMatrix;

            Assert(actualResults, mockResult);
        }

        private static void Assert(int[,] results, int[,] mockResult)
        {
            int xLimit = results.GetUpperBound(0), yLimit = results.GetUpperBound(1);

            for (int xctr = 0; xctr <= xLimit; xctr++)
            {
                for (int yctr = 0; yctr <= yLimit; yctr++)
                {
                    if (!results[xctr, yctr].Equals(mockResult[xctr, yctr]))
                    {
                        Console.WriteLine("FAIL");
                        break;
                    }
                }
            }
        }
    }
}
