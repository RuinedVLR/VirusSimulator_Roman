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
                                    { '^','^','^','^','^','^','^','^','^','-','-','~','~','~','~','~','~','~','~','~','~','-','-','-','-','-','-','-','-','-','-' },
                                    { '^','^','^','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','~','~','-','-','-','-','-','^','^','^','^','^','^' },
                                    { '-','-','-','-','-','-','-','-','-','-','~','~','~','~','~','~','~','~','~','-','-','-','-','^','^','^','^','^','^','^','^' },
                                    { '-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','~','~','~','~','-','-','^','^','^','^','^','^','^','^','^','^' },
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

            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("-------------~~~~--------------");
            //Console.WriteLine("^^^^^^------~~~~~~~~~----------");
            //Console.WriteLine("^^^^^^^^^--~~~~~~~~~~----------");
            //Console.WriteLine("^^^------~~~~~~~~~~~-----^^^^^^");
            //Console.WriteLine("----------~~~~~~~~~----^^^^^^^^");
            //Console.WriteLine("--------------~~~~~--^^^^^^^^^^");
            //Console.WriteLine("----^^^^^^-------------------^^");
            //Console.WriteLine("---^^^^^^^^^^^-----------------");
            //Console.WriteLine("---^^^^^^^^^----------~~~~~~~~~");
            //Console.WriteLine("-^^^^^^^^^^^^^-----~~~~~~~~~~~~");
            //Console.WriteLine("-^^^^^^^^^^^^^-----~~~~~~~~~~~~");
            //Console.WriteLine("---------^^^-----~~~~~~~~~~~~~~");
            //Console.WriteLine("---------------------~~~~~~~~~~");
            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("-------------------------------");
        }

        static void VirusMovement()
        {
            while (true)
            {
                

                while (virusCount < 3)
                {
                    int x = rand.Next(0, 30);
                    int y = rand.Next(0, 16);                    
                    Console.WriteLine(x);
                    Console.WriteLine(y);

                    virusPosition.Add((x, y));
                    if (landscape[y, x].Equals('-'))
                    {
                        landscape[y, x] = 'X';
                        virusPosition.Add((y, x));
                        Console.Clear();
                        DrawLandscape();
                        virusCount++;
                    }
                    else
                    {
                        continue;
                    }
                }

                for (int i = 0; i < virusPosition.Count; i++)
                {
                    int moveNum = rand.Next(1, 5);
                    Thread.Sleep(1000);
                    if (moveNum == 1 && virusPosition[i].Item1 > 0 && virusPosition[i].Item1 < 16) // down
                    {
                        virusPosition[i] = (virusPosition[i].Item1 + 1, virusPosition[i].Item2);
                    }
                    else if (moveNum == 2 && virusPosition[i].Item1 > 0 && virusPosition[i].Item1 < 16) // up
                    {
                        virusPosition[i] = (virusPosition[i].Item1 - 1, virusPosition[i].Item2);
                    }
                    else if (moveNum == 3 && virusPosition[i].Item2 > 0 && virusPosition[i].Item2 < 30)
                    {
                        virusPosition[i] = (virusPosition[i].Item1, virusPosition[i].Item2 + 1);
                    }
                    else if (moveNum == 4 && virusPosition[i].Item2 > 0 && virusPosition[i].Item2 < 30)
                    {
                        virusPosition[i] = (virusPosition[i].Item1, virusPosition[i].Item2 - 1);
                    }
                }
             
            }

        }

        static void Move()
        {
            
        }


    }
}
