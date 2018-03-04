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
        public Vessel Vessel1 { get; set; }
        public Vessel Vessel2 { get; set; }
        public Position IntersectionPosition { get; set; } 
        public bool WarningIssued { get; set; }
    }
}
