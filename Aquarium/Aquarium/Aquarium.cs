﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    public class Aquarium
    {

        public Aquarium()
        {
            
        }        
        public static string[,] GenerateAquarium()  //Aquarium mit Breite 40 und Höhe 10 wird generiert
        {

            string[,] aquarium = new string[40, 10];

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (i == 0 || i == 40 - 1)
                    {
                        aquarium[i, j] = "|";
                    }
                    else
                    {
                        aquarium[i, j] = " ";
                    }

                    if (j == 10 - 1)
                    {
                        aquarium[i, j] = "-";
                    }
                    if ((j == 10 - 1 && i == 0) || (j == 10 - 1 && i == 39))
                    {
                        aquarium[i, j] = "+";
                    }
                }
            }
            return aquarium;
        }
        public static void PrintAquarium(string[,]p_Aquarium) 
        {

            Console.Clear();
            for (int j = 0; j < 10; j++)
            {
                for (int b = 0; b < 40; b++)
                {
                    Console.Write(p_Aquarium[b, j]);
                }
                Console.Write("\n");
            }
            
        }
        public static void CreateFish(string[,] p_Aquarium, List<Fish>list)    //Hier Fische eingeben, die dem Aquarium hinzugefügt werden sollen
        {
            List<Fish> fish_list = list;


            fish_list.Add(new Carp());
            fish_list.Add(new Shark());
            fish_list.Add(new Swordfish());
            fish_list.Add(new Blowfish());

            Random r = new Random();
            foreach (Fish f in fish_list)
            {
                
                f.PosX = r.Next(1, 38 - f.Lenght); // x
                f.PosY = r.Next(0, 8); // y
  
            }

            
        }
        public static void PlaceFish(string[,] p_Aquarium, List<Fish>fish_list)
        {
            foreach (Fish f in fish_list)
            {

                

                if (f.SwimDirectionRight)
                {

                    for (int a = 0; a < f.Lenght; a++)
                    {
                        p_Aquarium[f.PosX + a, f.PosY] = f.Shape[a].ToString();
                        if (p_Aquarium[f.PosX + f.Lenght, f.PosY] != "|")
                        {
                            p_Aquarium[f.PosX + f.Lenght, f.PosY] = " ";
                        }
                            p_Aquarium[0, f.PosY] = "|";

                        

                    }
                }
                else
                {
                    for (int a = 0; a < f.Lenght; a++)
                    {
                        p_Aquarium[f.PosX + a, f.PosY] = f.mirrored_Shape[a].ToString();
                        if (p_Aquarium[f.PosX-1, f.PosY] != "|")
                        {
                            p_Aquarium[f.PosX-1, f.PosY] = " ";
                        }
                            p_Aquarium[0, f.PosY] = "|";
                        
                    }
                }
            }
        }


        public static void MoveFish(string[,] p_Aquarium, List<Fish> fish_list)
        {
              foreach(Fish f in fish_list)
              {
                    if (f.SwimDirectionRight)
                    {
                        f.PosX--;
                        if(f.PosX == 1)
                        {
                        f.SwimDirectionRight = !f.SwimDirectionRight;
                        p_Aquarium[f.PosX+f.Lenght, f.PosY] = " ";
                        }
                    }
                    else
                    {
                        f.PosX++;
                        if(f.PosX + f.Lenght - 1 == 38)
                        {
                        f.SwimDirectionRight = !f.SwimDirectionRight;
                        p_Aquarium[f.PosX - 1, f.PosY] = " ";
                        }
                    }
                   
              }
              
        }

    }

}