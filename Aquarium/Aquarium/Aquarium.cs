using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static int AskUserForHight()
        {
            Console.WriteLine("Wie hoch soll das Aquarium sein? (min 4)");
            int hight = Convert.ToInt32(Console.ReadLine());
            return hight;
        }
        public static int AskUserForWidth()
        {
            Console.WriteLine("Wie breit soll das Aquarium sein? (min 14)");
            int width = Convert.ToInt32(Console.ReadLine());
            return width;
        }

        public static string[,] GenerateAquarium(int width,int  hight)  //Aquarium mit Breite 40 und Höhe 10 wird generiert
        {
            string[,] aquarium = new string[width, hight];

            for (int j = 0; j < hight; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (i == 0 || i == width - 1)
                    {
                        aquarium[i, j] = "|";
                    }
                    else
                    {
                        aquarium[i, j] = " ";
                    }

                    if (j == hight - 1)
                    {
                        aquarium[i, j] = "-";
                    }
                    if ((j == hight - 1 && i == 0) || (j == hight - 1 && i == width - 1))
                    {
                        aquarium[i, j] = "+";
                    }
                }
            }
            return aquarium;
        }
        public static void PrintAquarium(string[,]p_Aquarium, int width, int hight) 
        {
            Console.Clear();
            for (int j = 0; j < hight; j++)
            {
                for (int b = 0; b < width; b++)
                {
                    Console.Write(p_Aquarium[b, j]);
                }
                Console.Write("\n");
            }          
        }
        public static void CreateFish(string[,] p_Aquarium, List<Fish>list, int width, int hight)    //Hier Fische eingeben, die dem Aquarium hinzugefügt werden sollen
        {
            List<Fish> fish_list = list;

            fish_list.Add(new Shark());
            if(width > 24 && hight > 5)
            {
                fish_list.Add(new Shark());
                fish_list.Add(new Carp());
                fish_list.Add(new Carp());
                fish_list.Add(new Swordfish());
            }
            fish_list.Add(new Carp());
            fish_list.Add(new Carp());
            fish_list.Add(new Carp());
            fish_list.Add(new Swordfish());
            fish_list.Add(new Blowfish());

            Random r = new Random();
            foreach (Fish f in fish_list)
            {                
                f.PosX = r.Next(1, width - 2 - f.Lenght); // x
                f.PosY = r.Next(0, hight - 2); // y  
            }           
        }
        public static void PlaceFish(string[,] p_Aquarium, List<Fish>fish_list, int width, int hight)
        {
            foreach (Fish f in fish_list)
            {                
                if (f.SwimDirectionRight) //Richtung des Fisches wird überprüft
                {
                    for (int a = 0; a < f.Lenght; a++)
                    {
                        p_Aquarium[f.PosX + a, f.PosY] = f.Shape[a].ToString(); //Fisch wird geprintet
                        
                        p_Aquarium[f.PosX + f.Lenght, f.PosY] = " ";
                        
                        p_Aquarium[0, f.PosY] = "|"; //Rand wird wiederhergestellt
                        p_Aquarium[width-1, f.PosY] = "|";
                    }
                }
                else
                {
                    for (int a = 0; a < f.Lenght; a++)
                    {
                        p_Aquarium[f.PosX + a, f.PosY] = f.mirrored_Shape[a].ToString(); //Gespiegelter Fisch wird geprintet
                        if (p_Aquarium[f.PosX-1, f.PosY] != "|")
                        {
                            p_Aquarium[f.PosX-1, f.PosY] = " ";
                        }
                            p_Aquarium[0, f.PosY] = "|"; //Rand wird wiederhergestellt
                            p_Aquarium[width -1, f.PosY] = "|";                        
                    }
                }
            }
        }
        public static void MoveFish(string[,] p_Aquarium, List<Fish> fish_list, int width, int hight)
        {
            Random r = new Random();
            foreach (Fish f in fish_list)
            {
                int d = r.Next(1, f.ChangeDepth+1); //Wahrscheinlichkeit, mit welcher der Fisch seine Tiefe ändert

                if (f.ChangeDepth != d )
                { //Fisch ändert Tiefe nicht
                    if (f.SwimDirectionRight)
                    {
                        f.PosX--;
                        if (f.PosX == 1)
                        {
                            f.SwimDirectionRight = !f.SwimDirectionRight;
                            p_Aquarium[f.PosX + f.Lenght, f.PosY] = " "; //Überstehendes Fischteil wird deleted
                        }
                    }
                    else
                    {
                        f.PosX++;
                        if (f.PosX + f.Lenght - 1 == width - 2)
                        {
                            f.SwimDirectionRight = !f.SwimDirectionRight;
                            p_Aquarium[f.PosX - 1, f.PosY] = " "; //Überstehendes Fischteil wird deleted
                        }
                    }
                }
                else //Fisch ändert Tiefe
                {
                    f.OldPosX = f.PosX;
                    f.OldPosY = f.PosY;

                    if (f.SwimDirectionUp && (f.PosY != hight - 2) )
                    {
                        if (f.PosY == hight - 1) //Wenn Fisch den Rand vom Aquarium berührt, ändert er seine Richtung
                        {
                            f.SwimDirectionUp = false;
                        }
                        f.PosY++; //Fisch schwimmt nach oben                                               
                    }
                    else if(!f.SwimDirectionUp && (f.PosY != 0))
                    {
                        if (f.PosY == 1) //Wenn Fisch den Rand vom Aquarium berührt, ändert er seine Richtung
                        {
                            f.SwimDirectionUp = true;
                        }
                        f.PosY--; //Fisch schwimmt nach unten                                                
                    }
                    else
                    {
                        f.SwimDirectionUp = !f.SwimDirectionUp;
                    }
                    for (int i = 0; i < f.Lenght; i++) //"Alte" Fisch wird gelöscht
                    {
                        p_Aquarium[f.OldPosX + i, f.OldPosY] = " ";
                    }
                }
            }             
        }
        public static Fish DetectFish(List<Fish> fish_list)
        {
            Fish eaten_fish = fish_list[0]; 
            foreach(Fish f in fish_list)
            {
                if(f.GetType() == typeof(Shark)) //Überprüfung, ob Fisch = Shark
                {
                    foreach(Fish p in fish_list)
                    {
                        if(p.GetType() != typeof(Shark)) //Überprüfung anderer Fisch != Shark
                        {

                            for (int a = 0; a < f.Lenght; a++)
                            {
                                for (int b = 0; b < p.Lenght; b++)
                                {
                                    if ((f.PosX + a == p.PosX + b) && (f.PosY == p.PosY))
                                    {
                                        eaten_fish = p;
                                    }
                                }
                            }
                        }                        
                    }                    
                }                               
            }
            return eaten_fish;
        }
        public static void EatFish(Fish fish, List<Fish> fish_list, string[,] p_Aquarium)
        {
            if (fish.GetType() != typeof(Shark))
            {
                for(int a = 0; a < fish.Lenght; a++)
                {
                    p_Aquarium[fish.PosX+a, fish.PosY] = " ";
                    
                }
                fish_list.Remove(fish);
            }            
        }
    }
}
