using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aquarium
{
    public class Swordfish: Fish
    {
        public Swordfish()
        {
            PosX = 0;
            PosY = 0;
            OldPosX = PosX;
            OldPosY = PosY;
            Shape = "-<><";
            mirrored_Shape = "><>-";
            Lenght = 4;
            SwimDirectionRight = true;
            SwimDirectionUp = true;
            ChangeDepth = 5;

        }

    }

}