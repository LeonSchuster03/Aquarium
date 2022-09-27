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
             string[,] aquarium = Aquarium.GenerateAquarium();   //Aquarium wird generiert

            Aquarium.CreateFish(aquarium,fish_list);//Fische werden erstellt
            Aquarium.PlaceFish(aquarium, fish_list);//Fische werden ins Aquarium gesetzt
            Aquarium.PrintAquarium(aquarium); //Aquarium wird ausgegeben
            
            while(true)
            {
                Console.Clear();
                Aquarium.MoveFish(aquarium, fish_list); //Koordinaten des Fisches werden geändert
                Aquarium.EatFish(Aquarium.DetectFish(fish_list), fish_list);
                Aquarium.PlaceFish(aquarium, fish_list); //Fisch wird ins Aquarium gesetzt             
                Aquarium.PrintAquarium(aquarium); //Aquarium wird ausgegeben         
                Thread.Sleep(300);

            }
            //Console.ReadLine();
        }
    }
}
