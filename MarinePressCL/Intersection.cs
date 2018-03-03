using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePressCL
{
    /// <summary>
    /// Vessel's names and intersection position
    /// </summary>
    public class Intersection
    {
        public string VesselName1 { get; set; }
        public string VesselName2 { get; set; }
        Position IntersectionPosition { get; set; } 
    }
}
