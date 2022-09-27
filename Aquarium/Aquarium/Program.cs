using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fish> fish_list = new List<Fish>();
            int width = Aquarium.AskUserForWidth();
            int hight = Aquarium.AskUserForHight();
             string[,] aquarium = Aquarium.GenerateAquarium(width, hight);//Aquarium wird generiert

            Aquarium.CreateFish(aquarium,fish_list, width, hight);//Fische werden erstellt
            Aquarium.PlaceFish(aquarium, fish_list, width, hight);//Fische werden ins Aquarium gesetzt
            Aquarium.PrintAquarium(aquarium,width, hight); //Aquarium wird ausgegeben
            
            while(fish_list.Count() > 1)
            {
                Console.Clear();
                Aquarium.EatFish(Aquarium.DetectFish(fish_list), fish_list, aquarium); //Hai isst Fisch, wenn beide sich in den selben Koordinaten befinden
                Aquarium.MoveFish(aquarium, fish_list, width, hight); //Koordinaten des Fisches werden geändert               
                Aquarium.PlaceFish(aquarium, fish_list, width, hight); //Fisch wird ins Aquarium gesetzt             
                Aquarium.PrintAquarium(aquarium, width, hight); //Aquarium wird ausgegeben         
                Thread.Sleep(300);
                

            }
            Console.ReadLine();
        }
    }
}
