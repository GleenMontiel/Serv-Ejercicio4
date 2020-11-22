using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            int n = 0;
            char horse;
            char[] horseChars = { '%', '#', '&', '+', 'X' };
            Horse[] horses = new Horse[horseChars.Length];

            do
            {
                for (int i = 0; i < horseChars.Length; i++)
                {
                    horses[i] = new Horse(0, i, horseChars[i]);
                }
       
                Thread[] horsesThreads = new Thread[5];

                do
                {
                    try
                    {
                        Console.WriteLine("Pick a \"horse\"");
                        Console.WriteLine("1.- %");
                        Console.WriteLine("2.- #");
                        Console.WriteLine("3.- &");
                        Console.WriteLine("4.- +");
                        Console.WriteLine("5.- X");
                        Console.Write("Option: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n > 5 || n < 1)
                        {
                            Console.WriteLine("Choose a valid option");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Choose a number");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Please noo");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                } while (n > 5 || n < 1);
                horse = horses[n - 1].HorseChar;
                Console.Clear();

                for (int i = 0; i < horses.Length; i++)
                {
                    horsesThreads[i] = new Thread(horses[i].Run);
                    horsesThreads[i].Start();
                }

                for (int i = 0; i < horsesThreads.Length; i++)
                {
                    horsesThreads[i].Join();
                }

                for (int i = 0; i < horses.Length; i++)
                {
                    if (horses[i].winner)
                    {
                       
                        Console.SetCursorPosition(0, 10);
                        Console.WriteLine("The winner is {0}", horses[i].HorseChar);
                        if (horses[i].HorseChar == horse)
                        {
                            Console.WriteLine("You win!");
                        }
                    }
                }

                do
                {
                    try
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.WriteLine("1.- Repeat");
                        Console.WriteLine("2.- Exit");
                        Console.Write("Option: ");
                        opc = Convert.ToInt32(Console.ReadLine());
                    if (opc == 1)
                    {
                        Console.Clear();
                        Horse.running = true;
                    }
                    if (opc > 2 || opc < 1)
                    {
                        Console.WriteLine("Choose a valid option");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Choose a number");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Please noo");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                } while (opc > 2 || opc < 1);

            } while (opc !=2 );
            Console.WriteLine("Bye");
            Console.ReadLine();
        }
    }
}