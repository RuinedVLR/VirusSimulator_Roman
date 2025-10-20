using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VirusSimulator_Roman
{
    internal class Program
    {
        static char[,] landscape ={ { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',},
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','~','~','~','~','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                                    { '^','^','^','^','^','^','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','-','-','-','-','-','-','-','-','-','-' },
                                    { '^','^','^','^','^','^','^','-','-','-','-','~','~','~','~','~','~','~','~','~','~','-','-','-','-','-','-','-','-','-','-' },
                                    { '^','^','^','^','^','-','-','-','-','~','~','~','~','~','~','~','~','~','~','~','-','-','-','-','-','^','^','^','^','^','^' },
                                    { '-','-','-','-','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','-','-','-','-','-','^','^','^','^','^','^','^' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','~','~','~','~','-','-','-','-','^','^','^','^','^','^','^','^' },
                                    { '-','-','-','-','^','^','^','^','^','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','^','^' },
                                    { '-','-','-','^','^','^','^','^','^','^','^','^','^','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                                    { '-','-','-','^','^','^','^','^','^','^','^','^','^','-','-','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~' },
                                    { '-','^','^','^','^','^','^','^','^','^','^','^','^','^','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~','~','~' },
                                    { '-','^','^','^','^','^','^','^','^','^','^','^','^','^','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~','~','~' },
                                    { '-','-','-','-','-','-','-','-','-','^','^','^','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~','~','~','~','~' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-'} };

        static List<(int, int)> virusPosition = new List<(int, int)>();
        static List<(int, int)> newPosition = new List<(int, int)>();
        static Random rand = new Random();
        static int virusCount = 0;


        static void Main(string[] args)
        {            
            DrawLandscape();
            VirusMovement();


        }

        static void DrawLandscape()
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(landscape[i, j]);
                }
            }
        }

        static void VirusMovement()
        {
            while (true)
            {
                virusPosition.AddRange(newPosition);

                while (virusCount < 3)
                {
                    int x = rand.Next(0, 30);
                    int y = rand.Next(0, 16);

                    if (landscape[y, x].Equals('-'))
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write('X');
                        virusPosition.Add((y, x));
                        virusCount++;
                    }
                    else
                    {
                        continue;
                    }
                }

                newPosition.Clear();

                for (int i = 0; i < virusPosition.Count; i++)
                {
                    int moveNum = rand.Next(1, 5);

                    Thread.Sleep(1);

                    (int, int) currPos = (virusPosition[i].Item1, virusPosition[i].Item2);

                    if (moveNum == 1 && virusPosition[i].Item1 >= 0 && virusPosition[i].Item1 < 16) // down
                    {
                        if (landscape[virusPosition[i].Item1 + 1, virusPosition[i].Item2] == '-')
                        {
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write(landscape[virusPosition[i].Item1, virusPosition[i].Item2]);
                            virusPosition[i] = (virusPosition[i].Item1 + 1, virusPosition[i].Item2);
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write('X');
                            RandomSpawn(currPos);
                        }

                    }
                    else if (moveNum == 2 && virusPosition[i].Item1 > 0 && virusPosition[i].Item1 <= 16) // up
                    {
                        if (landscape[virusPosition[i].Item1 - 1, virusPosition[i].Item2] == '-')
                        {
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write(landscape[virusPosition[i].Item1, virusPosition[i].Item2]);
                            virusPosition[i] = (virusPosition[i].Item1 - 1, virusPosition[i].Item2);
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write('X');
                            RandomSpawn(currPos);
                        }
                    }
                    else if (moveNum == 3 && virusPosition[i].Item2 >= 0 && virusPosition[i].Item2 < 30) // right
                    {
                        if (landscape[virusPosition[i].Item1, virusPosition[i].Item2 + 1] == '-')
                        {
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write(landscape[virusPosition[i].Item1, virusPosition[i].Item2]);
                            virusPosition[i] = (virusPosition[i].Item1, virusPosition[i].Item2 + 1);
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write('X');
                            RandomSpawn(currPos);
                        }
                    }
                    else if (moveNum == 4 && virusPosition[i].Item2 > 0 && virusPosition[i].Item2 <= 30) // left
                    {
                        if (landscape[virusPosition[i].Item1, virusPosition[i].Item2 - 1] == '-')
                        {
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write(landscape[virusPosition[i].Item1, virusPosition[i].Item2]);
                            virusPosition[i] = (virusPosition[i].Item1, virusPosition[i].Item2 - 1);
                            Console.SetCursorPosition(virusPosition[i].Item2, virusPosition[i].Item1);
                            Console.Write('X');
                            RandomSpawn(currPos);
                        }
                    }
                }
             
            }

        }

        static void RandomSpawn((int, int) currPosition)
        {
            int required = 9;
            int randInt = rand.Next(0, 11);

            if (randInt > required)
            {
                if (landscape[currPosition.Item1, currPosition.Item2].Equals('-'))
                {
                    Console.SetCursorPosition(currPosition.Item2, currPosition.Item1);
                    Console.Write('X');
                    newPosition.Add((currPosition.Item1, currPosition.Item2));
                    virusCount++;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }


    }
}
