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
        private List<Vessel> _listVessels;

        /// <summary>
        /// List of vesses available in the dashboard
        /// </summary>
        public List<Vessel> ListVessels
        {
            get
            {
                return this._listVessels;
            }
        }


        /// <summary>
        /// List of intersections
        /// </summary>
        private List<Intersection> _listIntersection;

        private DashBoard()
        { }

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
            if (_listVessels == null)
            {
                _listVessels = new List<Vessel>();
            }

            _listVessels.Add(v);

            this.GetIntersections();

            this.IssueWarning();
        }

        /// <summary>
        /// Remove a vessel from the dashboard
        /// </summary>
        /// <param name="vesselName"></param>
        public void RemoveVessel(string vesselName)
        {
            Vessel veselToRemove = _listVessels.Single<Vessel>(x => x.Name.ToUpper() == vesselName.ToUpper());
            _listVessels.Remove(veselToRemove);

        }


        /// <summary>
        /// Calculates all the intersections for all the vessels we're monitoring
        /// </summary>
        /// <returns></returns>
        private List<Intersection> GetIntersections()
        {
            // if less than 2 vessels, no intersection
            if (_listVessels == null || _listVessels.Count < 2)
            {
                return null;
            }


            //traverse listVessels
            for (int i = 0; i < _listVessels.Count - 1; i++)
            {
                for (int j = 1; j < _listVessels.Count; j++)
                {
                    //gets all segments (p2-p1) for vessel outer loop
                    //gets all segments (p2-p1) for vessel inner loop

                    // The following if is to avoid to recalculate all over again every time a new navigation point is added
                    // if(!outerLoop.position1.AlreadyCalculated && !outerLoop.position2.AlreadyCalculated 
                    // && innerLoop.position1.AlreadyCalculated && !innerLoop.position2.AlreadyCalculated )
                    // {
                    // combine all segments from inner and outer loop in the algorithm    
                    // found in https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
                    // 
                    // innerLoop.position1.AlreadyCalculated = true;
                    // innerLoop.position2.AlreadyCalculated = true;
                    // outerLoop.position1.AlreadyCalculated = true;
                    // outerLoop.position2.AlreadyCalculated = true;
                    //
                    // Add intersections to this.listIntersection
                    //}



                }
            }


            throw new NotImplementedException("!!! Intersections");
        }


        /// <summary>
        /// Issue warning
        /// </summary>
        private void IssueWarning()
        {
            DateTime t1;
            DateTime t2;

            foreach (Intersection inter in this._listIntersection.FindAll(x=>x.WarningIssued==false))
            {
                t1 = inter.Vessel1.GetFirstPositionBeforeIntersection(inter.IntersectionPosition).TimeStamp;
                t2 = inter.Vessel2.GetFirstPositionBeforeIntersection(inter.IntersectionPosition).TimeStamp;

                // If intersection point within 1 hour, issue warning
                if (t1.Subtract(t2).TotalHours <= 1)
                {
                    inter.WarningIssued = true;

                    Console.WriteLine("WARNING!!!! Intersection at [0], vessels [1] and [2] ", inter.IntersectionPosition.TimeStamp.ToString("YYYY-MM-dd:HH:mm:ss"), 
                        inter.Vessel1.Name
                        , inter.Vessel2.Name);
                }
            }
        }

        /// Prints name, distance, average speed for each vessel
        public void TraverseList()
        {
            foreach (Vessel v in this._listVessels)
            {
                Console.WriteLine("============");
                Console.WriteLine("Vessel.Name: " + v.Name);
                Console.WriteLine("Vessel.TotalDistance: " + v.CalculateTotalDistance().ToString());
                Console.WriteLine("Vessel.AverageSpeed: " + v.CalculateAverageSpeed().ToString());

            }

        }
    }
}

