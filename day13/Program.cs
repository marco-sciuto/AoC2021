using System;
using System.IO;

namespace day13
{
    class Program
    {
        static void Main(string[] args)
        {
            var xSize = 0;
            var ySize = 0;
            foreach (var line in File.ReadLines("input"))
            {
                if (line.Contains(','))
                {
                    var coordinates = line.Split(',');
                    xSize = Math.Max(xSize, int.Parse(coordinates[0]));
                    ySize = Math.Max(ySize, int.Parse(coordinates[1]));
                }
            }

            var matrix = new int[xSize + 1, ySize + 1];

            foreach (var line in File.ReadLines("input"))
            {
                if (line.Contains(','))
                {
                    var coordinates = line.Split(',');
                    var x = int.Parse(coordinates[0]);
                    var y = int.Parse(coordinates[1]);

                    matrix[x, y] = 1;
                }
                else if (line.Contains("fold"))
                {
                    var foldOn = line.Split(' ')[2].Split('=');
                    if (foldOn[0].Equals("x"))
                    {
                        FoldX(matrix, xSize, ySize, int.Parse($"{foldOn[1]}"));
                        xSize = int.Parse($"{foldOn[1]}");
                        //break;
                    }
                    else
                    {
                        FoldY(matrix, xSize, ySize, int.Parse($"{foldOn[1]}"));
                        ySize = int.Parse($"{foldOn[1]}");
                    }
                }
            }

            //int sum = 0;
            //foreach (var element in matrix)
            //{
            //    sum += element;
            //}
            //Console.WriteLine($"{sum}");

            // Image was flipped, played a bit to obtain something readable
            for (var i = 0; i < ySize; i++)
            {
                for (var j = 0; j < xSize; j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine("");
            }
        }

        private static void FoldX(int[,] matrix, int sizeX, int sizeY, int foldPoint)
        {
            int iFrom, iTo;
            for (iFrom = foldPoint + 1, iTo = foldPoint - 1; iFrom < sizeX; iFrom++, iTo--)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    matrix[iTo, j] = Math.Max(matrix[iTo, j], matrix[iFrom, j]);
                    matrix[iFrom, j] = 0;
                    matrix[foldPoint, j] = 0;
                }
            }
        }

        private static void FoldY(int[,] matrix, int sizeX, int sizeY, int foldPoint)
        {
            int jFrom, jTo;
            for (var i = 0; i < sizeX; i++)
            {
                for (jFrom = foldPoint + 1, jTo = foldPoint - 1; jFrom < sizeY; jFrom++, jTo--)
                {
                    matrix[i, jTo] = Math.Max(matrix[i, jFrom], matrix[i, jTo]);
                    matrix[i, jFrom] = 0;
                    matrix[i, foldPoint] = 0;
                }
            }
        }
    }
}
