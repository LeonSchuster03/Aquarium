using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int y = 6;
            int x = 20;
            string[,] aquarium = new string[x, y];
            for(int j = 0; j < y; j++)
            {
                for(int i = 0; i < x; i++)
                {
                    if(i == 0 || i == x - 1)
                    {
                        aquarium[i, j] = "|";
                    }
                    else
                    {
                        aquarium[i, j] = " ";
                    }

                    if(j == y - 1)
                    {
                        aquarium[i, j] = "-";
                    }
                }
            }
                  
            //print aquarium
            for(int j = 0; j < y; j++)
            {
                for(int b = 0; b < x; b++)
                {
                    Console.Write(aquarium[b,j]);
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }
    }
}
