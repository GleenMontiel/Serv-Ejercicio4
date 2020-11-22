using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Horse
    {
        static Random r = new Random();
        readonly static object l = new object();
        static int meta = 90;

        public static bool running = true;
        public char HorseChar { set; get; }
        public  bool winner = false;
        private int positionX;
        public int PositionX
        {
            set
            {
                if (value > 0)
                {
                    this.positionX = value;
                }
            }
            get
            {
                return this.positionX;
            }
        }
        private int positionY;
        public int PositionY
        {
            set
            {
                if (value > 0)
                {
                    this.positionY = value;
                }
            }
            get
            {
                return this.positionY;
            }
        }

        public Horse(int positionX, int positionY, char horseChar)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.HorseChar = horseChar;
        }

        public void Run()
        {

            while (running)
            {
                lock (l)
                {
                    int aux = this.PositionX; 
                    this.PositionX += r.Next(1, 5);
                    if (this.PositionX > meta)
                    {
                        this.PositionX = meta;
                    }
                    
                    for (int i = aux; i != this.positionX; i++) 
                    {
                        Console.SetCursorPosition(i, this.PositionY);
                        Console.Write("{0}", this.HorseChar);
                    }
                    if (this.positionX == meta)
                    {
                        running = false;
                        this.winner = true;
                    }
                }
                Thread.Sleep(r.Next(50, 200));
                
            }
        }
    }
}
