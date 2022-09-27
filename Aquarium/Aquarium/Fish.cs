using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    public abstract class Fish
    {
        public int PosX { get; set; }
        public int OldPosX { get; set; }
        public int PosY { get; set; }
        public int OldPosY { get; set; }
        public string Shape { get; set; }
        public string mirrored_Shape { get; set; }
        public int Lenght { get; set; }
        public int ChangeDepth { get; set; }
        public bool SwimDirectionRight { get; set; }
        public bool SwimDirectionUp { get; set; }




    }

}
