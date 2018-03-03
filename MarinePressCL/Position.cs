using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePressCL
{
    public class Position
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public DateTime TimeStamp { get; set; }

        //keeps track whether this position has already been considered  in the intersection computation or not
        public bool AlreadyCalculated { get; set; }
    }
}
