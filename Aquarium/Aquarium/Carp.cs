﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aquarium
{
    public class Carp: Fish
    {
        public Carp()
        {
            PosX = 0;
            PosY = 0;
            Shape = "<><";
            mirrored_Shape = "><>";
            Lenght = 3;
            SwimDirectionRight = true;

        }

    }

}