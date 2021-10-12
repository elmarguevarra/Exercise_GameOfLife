using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var lifeMatrix = new bool[6, 6] {
                { false, false, false, false, false, false },
                { false, false, false, false, false, false },
                { false, false, true, false, false, false },
                { false, true, false, true, false, false },
                { false, false, true, false, false, false },
                { false, false, false, false, false, false }
            };
            var nbMaxtrix = new int[lifeMatrix.GetUpperBound(0) + 1, lifeMatrix.GetUpperBound(1) + 1];

            var iteration = 10;

            EvaluateGameOfLife(lifeMatrix, nbMaxtrix, iteration);
        }

        public static int[,] EvaluateGameOfLife(bool[,] lifeMatrix, int[,] nbMatrix, int iteration)
        {
            int xLimit = lifeMatrix.GetUpperBound(0), yLimit = lifeMatrix.GetUpperBound(1);

            for (int i = 0; i <= iteration; i++)
            {
                Evaluate(lifeMatrix, nbMatrix, xLimit, yLimit);

                DisplayMatrices(i, lifeMatrix, nbMatrix);
            }
            return nbMatrix;
        }

        private static void Evaluate(bool[,] lifeMatrix, int[,] nbMaxtrix, int xLimit, int yLimit)
        {
            for (int xctr = 0; xctr <= xLimit; xctr++)
            {
                for (int yctr = 0; yctr <= yLimit; yctr++)
                {
                    var aliveNeigh = 0;

                    aliveNeigh = Check(lifeMatrix, xctr, yctr, xLimit, yLimit, aliveNeigh);

                    nbMaxtrix[xctr, yctr] = aliveNeigh;
                }
            }
        }

        private static int Check(bool[,] lifeMatrix, int xctr, int yctr, int xLimit, int yLimit, int aliveNeigh)
        {
            aliveNeigh = CheckHorizontally(lifeMatrix, xctr, yctr, xLimit, yLimit, aliveNeigh);
            aliveNeigh = CheckVertically(lifeMatrix, xctr, yctr, yLimit, aliveNeigh);

            return aliveNeigh;
        }

        private static int[,] LifePerIteration(bool[,] lifeMatrix, int[,] nbMaxtrix)
        {
            int xLimit = nbMaxtrix.GetUpperBound(0), yLimit = nbMaxtrix.GetUpperBound(1);

            for (int xctr = 0; xctr <= xLimit; xctr++)
            {
                for (int yctr = 0; yctr <= yLimit; yctr++)
                {
                    SetLife(lifeMatrix, nbMaxtrix, xctr, yctr);
                }
            }

            return nbMaxtrix;
        }

        private static void SetLife(bool[,] lifeMatrix, int[,] nbMaxtrix, int xctr, int yctr)
        {
            lifeMatrix[xctr, yctr] =
                nbMaxtrix[xctr, yctr] == 1 ||
                    nbMaxtrix[xctr, yctr] == 0 ||
                        nbMaxtrix[xctr, yctr] >= 4 ? false
                : lifeMatrix[xctr, yctr];

            lifeMatrix[xctr, yctr] =
                nbMaxtrix[xctr, yctr] == 3 ? true
                : lifeMatrix[xctr, yctr];
        }

        private static int CheckHorizontally(bool[,] lifeMatrix, int xctr, int yctr, int xLimit, int yLimit, int aliveNeigh)
        {
            aliveNeigh = xctr + 1 <= xLimit ?
                CheckHorizontalHelper(lifeMatrix, xctr + 1, yctr, xLimit, yLimit, aliveNeigh)
                    : aliveNeigh;

            aliveNeigh = xctr != 0 ?
                CheckHorizontalHelper(lifeMatrix, xctr - 1, yctr, xLimit, yLimit, aliveNeigh)
                    : aliveNeigh;

            return aliveNeigh;
        }

        private static int CheckHorizontalHelper(bool[,] lifeMatrix, int xctr, int yctr, int xLimit, int yLimit, int aliveNeigh)
        {
            aliveNeigh = lifeMatrix[xctr, yctr] ? aliveNeigh + 1 : aliveNeigh;
            aliveNeigh = CheckVertically(lifeMatrix, xctr, yctr, yLimit, aliveNeigh); //Checks diagonally relative to the current cell.

            return aliveNeigh;
        }

        private static int CheckVertically(bool[,] lifeMatrix, int xctr, int yctr, int yLimit, int aliveNeigh)
        {
            aliveNeigh = yctr + 1 <= yLimit ?
                (lifeMatrix[xctr, yctr + 1] ? aliveNeigh + 1 : aliveNeigh)
                    : aliveNeigh;

            aliveNeigh = yctr != 0 ?
                (lifeMatrix[xctr, yctr - 1] ? aliveNeigh + 1 : aliveNeigh)
                    : aliveNeigh;

            return aliveNeigh;
        }

        #region Display

        private static void DisplayMatrices(int i, bool[,] lifeMatrix, int[,] nbMaxtrix)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Iteration: " + i);
            Display(lifeMatrix);

            LifePerIteration(lifeMatrix, nbMaxtrix);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Neighbor count");
            Display(nbMaxtrix);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------------------------------------------------------------------", Console.ForegroundColor);
        }

        private static void Display(bool[,] results)
        {
            for (int i = 0; i <= results.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= results.GetUpperBound(1); j++)
                {
                    if (results[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(results[i, j] + "(" + i + "," + j + ")" + " ", Console.ForegroundColor);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void Display(int[,] results)
        {
            for (int i = 0; i <= results.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= results.GetUpperBound(1); j++)
                {
                    if (results[i, j] < 2 || results[i, j] >= 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(results[i, j] + " ", Console.ForegroundColor);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion Display
    }
}
