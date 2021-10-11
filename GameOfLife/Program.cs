using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var lifeMatrix = new bool[6, 6] {
                { false, true, false, true, false, false },
                { false, false, true, true, false, false },
                { false, true, false, true, false, false },
                { false, true, false, true, false, false },
                { false, true, false, true, false, false },
                { false, false, false, false, false, false }
            };
            var iteration = 11;
            var results = EvaluateGameOfLife(lifeMatrix, iteration);
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
                    Console.Write(results[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        public static int[,] EvaluateGameOfLife(bool[,] lifeMatrix, int iteration)
        {
            var nbMaxtrix = new int[lifeMatrix.GetUpperBound(0) + 1, lifeMatrix.GetUpperBound(1) + 1];

            int xLimit = lifeMatrix.GetUpperBound(0);
            int yLimit = lifeMatrix.GetUpperBound(1);

            for (int i = 0; i <= iteration; i++)
            {

                for (int xctr = 0; xctr <= xLimit; xctr++)
                {
                    
                    for (int yctr = 0; yctr <= yLimit; yctr++)
                    {
                        var aliveNeigh = 0;

                        //Check horizontally
                        if (xctr + 1 <= xLimit)
                        {
                            if (lifeMatrix[xctr + 1, yctr])
                            {
                                aliveNeigh++;
                            }
                            aliveNeigh = CheckVertically(lifeMatrix, xctr + 1, yctr, yLimit, aliveNeigh);
                        }
                        if (xctr != 0)
                        {
                            if (lifeMatrix[xctr - 1, yctr])
                            {
                                aliveNeigh++;
                            }
                            aliveNeigh = CheckVertically(lifeMatrix, xctr - 1, yctr, yLimit, aliveNeigh);
                        }
                            
                            
                        //Check vertically

                        if (yctr + 1 <= yLimit)
                        {
                            if (lifeMatrix[xctr, yctr + 1])
                            {
                                aliveNeigh++;
                            }
                        }
                        if (yctr != 0)
                        {
                            if (lifeMatrix[xctr, yctr - 1])
                            {
                                aliveNeigh++;
                            }
                        }

                        nbMaxtrix[xctr, yctr] = aliveNeigh;
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Iteration: " + i);
                Display(lifeMatrix);
                LifePerIteration(lifeMatrix, nbMaxtrix);
                Display(nbMaxtrix);
            }
            return nbMaxtrix;
        }

        private static int[,] LifePerIteration(bool[,] lifeMatrix, int[,] nbMaxtrix)
        {
            int xLimit = nbMaxtrix.GetUpperBound(0);
            int yLimit = nbMaxtrix.GetUpperBound(1);

            for (int xctr = 0; xctr <= xLimit; xctr++)
            {
                for (int yctr = 0; yctr <= yLimit; yctr++)
                {
                    if (nbMaxtrix[xctr, yctr] == 1 || nbMaxtrix[xctr, yctr] == 0 || nbMaxtrix[xctr, yctr] >= 4)
                    {
                        lifeMatrix[xctr, yctr] = false;
                    }
                    else if (nbMaxtrix[xctr, yctr] == 3)
                    {
                        lifeMatrix[xctr, yctr] = true;
                    }
                }
            }

            return nbMaxtrix;
        }

        private static int CheckVertically(bool[,] matrix, int xctr, int yctr, int yLimit, int aliveNeigh)
        {
            if (yctr + 1 <= yLimit)
            {
                if (matrix[xctr, yctr + 1])
                {
                    aliveNeigh++;
                }
            }
            if (yctr != 0)
            {
                if (matrix[xctr, yctr - 1])
                {
                    aliveNeigh++;
                }
            }

            return aliveNeigh;
        }
    }
}
