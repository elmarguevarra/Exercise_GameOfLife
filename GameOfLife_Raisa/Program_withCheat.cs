using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program_withCheat
    {
        #region First Act (The Intro)
        //static void Main(string[] args)
        //{
        //          var matrix = 
        //           new int[10, 10]{ 
        //      { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //      { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //              { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //              { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        //          };
        //  for (int row = 0; row < 10; row++)
        //  {
        //      for (int col = 0; col < 10; col++)
        //      {
        //          Console.Write(matrix[row, col]);
        //      }
        //      Console.WriteLine();
        //  }
        //  GameOfLife(matrix, 3);
        //}
        //private static void GameOfLife(int[,] matrix, int iterations)
        //{
        //  var rowTotal = 10;
        //  var columnTotal = 10;
        //  for (var iteration = 0; iteration < iterations; iteration++)
        //  {
        //      var future = new int[rowTotal, columnTotal];
        //      // Loop through every cell
        //      for (int row = 0; row < rowTotal; row++)
        //      {
        //          for (int col = 0; col < columnTotal; col++)
        //          {
        //              int aliveNeighbours = 0;
        //              for (int mrow = -1; mrow <= 1; mrow++)
        //              {
        //                  for (int mcol = -1; mcol <= 1; mcol++)
        //                  {
        //                      if (row + mrow > -1 && row + mrow < rowTotal
        //                          && col + mcol > -1 && col + mcol < columnTotal)
        //                      aliveNeighbours += matrix[row + mrow, col + mcol];
        //                  }
        //              }
        //              // subtract if this is not 0
        //              aliveNeighbours -= matrix[row,col];
        //              // lonely
        //              if (aliveNeighbours < 2)
        //                  future[row,col] = 0;
        //              // overpopulation
        //              else if (aliveNeighbours > 3)
        //                  future[row,col] = 0;
        //              else if (aliveNeighbours == 3)
        //                  future[row,col] = 1;
        //              else
        //                  future[row,col] = matrix[row,col];
        //          }
        //      }
        //      Console.WriteLine("Next Generation");
        //      for (int row = 0; row < rowTotal; row++)
        //      {
        //          for (int col = 0; col < columnTotal; col++)
        //          {
        //              Console.Write(future[row, col]);
        //          }
        //          Console.WriteLine();
        //      }
        //      matrix = future;
        //  }
        //}
        #endregion
        #region Second Act (The Restricted)
        //static void Main(string[] args)
        //{
        //  var matrix =
        //   new int[10, 10]{
        //      { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //      { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //      { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        //      { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        //      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        //  };
        //  PrintMatrix(matrix);
        //  StartGameOfLife(new GameOfLife()
        //  {
        //      matrix = matrix,
        //      iterations = 3
        //  });
        //}
        //private static void PrintMatrix(int[,] matrix)
        //{
        //  for (int row = 0; row < matrix.GetLength(0); row++)
        //  {
        //      for (int col = 0; col < matrix.GetLength(1); col++)
        //      {
        //          Console.Write(matrix[row, col]);
        //      }
        //      Console.WriteLine();
        //  }
        //}
        //private static void StartGameOfLife(GameOfLife gameOfLife)
        //{
        //  for (var iteration = 0; iteration < gameOfLife.iterations; iteration++)
        //  {
        //      var future = new int[gameOfLife.matrix.GetLength(0), gameOfLife.matrix.GetLength(1)];
        //      // Loop through every cell
        //      for (int row = 0; row < gameOfLife.matrix.GetLength(0); row++)
        //      {
        //          for (int col = 0; col < gameOfLife.matrix.GetLength(1); col++)
        //          {
        //              var aliveNeighbours = CountNeighbors(gameOfLife.matrix, new Point(col, row));
        //              future[row, col] = (aliveNeighbours < 2 || aliveNeighbours > 3) ? 0 :
        //                  aliveNeighbours == 3 ? 1 : gameOfLife.matrix[row, col];
        //          }
        //      }
        //      Console.WriteLine($"Generation {iteration}");
        //      PrintMatrix(future);
        //      gameOfLife.matrix = future;
        //  }
        //}
        //private static int CountNeighbors(int[,] matrix, Point point)
        //{
        //  var miniBoxPoints = new List<Point>() { 
        //      new Point(-1,-1),
        //      new Point(-1,0),
        //      new Point(-1,1),
        //      new Point(0,-1),
        //      // new Point(0,0), dont include self in neighbor count
        //      new Point(0,1),
        //      new Point(1,-1),
        //      new Point(1,0),
        //      new Point(1,1),
        //  };
        //  int aliveNeighbours = 0;
        //  foreach(var miniBoxPoint in miniBoxPoints)
        //  {
        //      aliveNeighbours += (point.Y + miniBoxPoint.Y > -1 && point.Y + miniBoxPoint.Y < matrix.GetLength(0)
        //          && point.X + miniBoxPoint.X > -1 && point.X + miniBoxPoint.X < matrix.GetLength(1)) ? matrix[point.Y + miniBoxPoint.Y, point.X + miniBoxPoint.X] : 0;
        //  }
        //  return aliveNeighbours;
        //}
        //public class GameOfLife
        //{
        //  public int[,] matrix { get; set; }
        //  public int iterations { get; set; }
        //}
        //public class Point
        //{
        //  public int X { get; set; }
        //  public int Y { get; set; }
        //  public Point(int x, int y)
        //  {
        //      X = x;
        //      Y = y;
        //  }
        //}
        #endregion
        #region Third Act (The Cheat Code v1)
        public static int[,] StartGameOfLife(GameOfLife gameOfLife)
        {
            return gameOfLife.matrix;
        }
        public class GameOfLife
        {
            public int[,] matrix { get; set; }
            public int iterations { get; set; }
        }
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        #endregion
    }
}

