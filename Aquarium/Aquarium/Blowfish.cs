using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aquarium
{
    public class Blowfish: Fish
    {
        public Blowfish()
        {
            PosX = 0;
            PosY = 0;
            Shape = "<()><";
            mirrored_Shape = "><()>";
            Lenght = 5;
            SwimDirectionRight = false;
        }

    }

}