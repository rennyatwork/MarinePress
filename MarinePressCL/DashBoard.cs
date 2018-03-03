using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePressCL
{
    /// <summary>
    /// singleton class that represents a dashboard with all the vessels
    /// </summary>
    public sealed class DashBoard
    {
        /// <summary>
        ///  keeps track of all the vessesl being monitored on the dashboard
        /// </summary>
        private List<Vessel> listVessels;

        /// <summary>
        /// List of vesses available in the dashboard
        /// </summary>
        public List<Vessel> ListVessels
        {
            get
            {
                return this.listVessels;
            }
        }

        private DashBoard()
        { }

        // dictionray associating each vessel to its equations for each segment present in the vessel's list of positions
        private Dictionary<Vessel, int[,]> dicVesselEquations;

        private static readonly Lazy<DashBoard> lazy = new Lazy<DashBoard>(() => new DashBoard());
        public static DashBoard Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        /// <summary>
        /// Add a vessel to the dashboard
        /// </summary>
        /// <param name="v"></param>
        public void AddVessel(Vessel v)
        {
            if (listVessels == null)
            {
                listVessels = new List<Vessel>();
            }

            listVessels.Add(v);
        }

        /// <summary>
        /// Remove a vessel from the dashboard
        /// </summary>
        /// <param name="vesselName"></param>
        public void RemoveVessel(string vesselName)
        {
            Vessel veselToRemove = listVessels.Single<Vessel>(x => x.Name.ToUpper() == vesselName.ToUpper());
            listVessels.Remove(veselToRemove);
            dicVesselEquations.Remove(veselToRemove);
        }


        /// <summary>
        /// Calculates all the intersections for all the vessels we're monitoring
        /// </summary>
        /// <returns></returns>
        public List<Intersection> GetIntersections()
        {
            // if less than 2 vessels, no intersection
            if (listVessels == null || listVessels.Count < 2)
            {
                return null;
            }

            //traverse listVessels
            foreach (Vessel v in listVessels)
            {
                if (v != null && v.ListPositions != null && v.ListPositions.Count > 0)
                {
                    // Get all linear equations corresponding to each segment.
                    // Skip positions where Position.AlreadyCalculated == true
                    // Set Position.AlreadyCalculated = true. This is to avoid a whole ne recalculation when a vessel is added
                    // These equations will be used to detect intersections
                }
            }

            // combine all equations found in previous step and solve the system of linear equation to detect intersection

            throw new NotImplementedException("!!! Intersections");
        }

        //private decimal[] GetLinearEquation(Position p1, Position p2)
        //{
        //    Decimal[] equation = { };

        //    decimal? slope = this.getSlope(p1, p2);

        //    //vertical line
        //    if (!slope.HasValue)
        //    {
        //        equation= { }
        //    }

        //}

        /// <summary>
        /// Returns the "m" in y = mx+c
        /// </summary>
        /// <returns></returns>
        private decimal? getSlope(Position p1, Position p2)
        {
            // m = y2-y1/x2-x1. If x2=x1, division by 0, m is undefined
            if (p1.CoordX == p2.CoordX)
            {
                return null;
            }

            if (p1.CoordY == p2.CoordY)
            {
                return 0;
            }

            return (p2.CoordY - p1.CoordY) / (p2.CoordX - p1.CoordX);

        }

        private void IssueWarning(Position intersectionPoint, Vessel v1, Vessel v2)
        {
            //if intersection is within 1h from each vessel, issue a warning
            throw new NotImplementedException("!!! issue warning??");
        }

        public void TraverseList()
        {
            foreach (Vessel v in this.listVessels)
            {
                Console.WriteLine("============");
                Console.WriteLine("Vessel.Name: "+ v.Name);
                Console.WriteLine("Vessel.TotalDistance: "+ v.TotalDistance().ToString());
                Console.WriteLine("Vessel.AverageSpeed: "+ v.AverageSpeed().ToString());
                
            }

        }
    }
}

