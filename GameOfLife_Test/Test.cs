
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ConsoleApp1.Program_withCheat;

namespace GameOfLife_Test
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Test_InputMatrix_ShouldbeSamewith_OutputMatrix();
            Test_OutputMatrix_ShouldPass_inIteration2_withRemainingLife();
            Test_OutputMatrix_ShouldPass_inIteration10_withNoRemainingLife();
        }

        public static void Test_InputMatrix_ShouldbeSamewith_OutputMatrix()
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

            var actualResults = Program_withCheat.StartGameOfLife(gameOfLifeObj);
            var mockResult = inputMatrix;

            Assert(actualResults, mockResult);
        }

        public static void Test_OutputMatrix_ShouldPass_inIteration2_withRemainingLife()
        {
            var inputMatrix = new int[,] {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 0 },
                { 0, 0, 1, 0, 1, 0 },
                { 0, 0, 0, 1, 1, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };



            var gameOfLifeObj = new GameOfLife()
            {
                iterations = 2,
                matrix = inputMatrix
            };

            var actualResults = Program_withCheat.StartGameOfLife(gameOfLifeObj);

            var mockResult = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 1, 0 },
                    { 0, 0, 1, 0, 0, 1 },
                    { 0, 0, 1, 0, 1, 1 },
                    { 0, 0, 0, 1, 1, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                };

            Assert(actualResults, mockResult);
        }

        public static void Test_OutputMatrix_ShouldPass_inIteration10_withNoRemainingLife()
        {
            var inputMatrix = new int[,] {
                { 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 0, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0 }
            };



            var gameOfLifeObj = new GameOfLife()
            {
                iterations = 10,
                matrix = inputMatrix
            };

            var actualResults = Program_withCheat.StartGameOfLife(gameOfLifeObj);

            var mockResult = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0 },
                };

            Assert(actualResults, mockResult);
        }

        private static void Assert(int[,] results, int[,] mockResult)
        {
            int xLimit = results.GetUpperBound(0), yLimit = results.GetUpperBound(1);

            var match = true;
            for (int xctr = 0; xctr <= xLimit; xctr++)
            {
                for (int yctr = 0; yctr <= yLimit; yctr++)
                {
                    if (!results[xctr, yctr].Equals(mockResult[xctr, yctr]))
                    {
                        match = false;
                        break;
                    }
                }
            }

            if (match)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PASS", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FAIL", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
