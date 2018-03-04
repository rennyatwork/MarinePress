using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePressCL
{
    public class Vessel
    {
        public string Name { get; set; }
        public List<Position> ListPositions
        {
            get
            {
                return this.listPositions;
            }
        }

        private List<Position> listPositions;

        /// <summary>
        /// Navigates to the next position
        /// </summary>
        /// <param name="p1"></param>
        public void Naviagte(Position p1)
        {
            if (this.listPositions == null)
            {
                this.listPositions = new List<Position>();
            }

            // don't let add a timestamp earlier thant the last
            if (this.listPositions.LastOrDefault().TimeStamp.CompareTo(p1.TimeStamp) > 0)
            {
                throw new Exception("Cannot add timeStamp smaller than the last one");
            }

            this.ListPositions.Add(p1);
        }

        /// <summary>
        /// Clears all the navigation
        /// </summary>
        public void ClearNavigation()
        {
            this.listPositions = null;
        }

        /// <summary>
        /// Difference between time in first and last position divided by total distance
        /// Velocity/hour
        /// </summary>
        /// <returns></returns>
        public decimal CalculateAverageSpeed()
        {
            if (this.ListPositions == null || this.ListPositions.Count == 1)
            {
                return 0;
            }

            TimeSpan totalTime = this.ListPositions.Last<Position>().TimeStamp.Subtract(this.ListPositions.First<Position>().TimeStamp);

            return CalculateTotalDistance() / totalTime.Hours;
        }

        /// <summary>
        /// Calculates totalDistance
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotalDistance()
        {
            if (this.ListPositions == null || this.ListPositions.Count == 1)
            {
                return 0;
            }

            double totalDistance = 0;

            for (int i = 0; i < this.ListPositions.Count - 1; i++)
            {
                totalDistance += this.CalculateDistance(this.ListPositions[i], this.ListPositions[i + 1]);
            }

            return (decimal)totalDistance;
        }

        /// <summary>
        /// Returns the position immediately before the intersection
        /// </summary>
        /// <param name="intersectionPoint"></param>
        /// <returns></returns>
        public Position GetFirstPositionBeforeIntersection(Position intersectionPoint)
        {
            int posBeforeIntersection = this.listPositions.FindLastIndex(x => x.TimeStamp.CompareTo(intersectionPoint.TimeStamp) <= 0);
            return (this.listPositions[posBeforeIntersection]);
        }

        /// <summary>
        /// Initializes a vessel with sample data 1
        /// </summary>
        public void InitializeVesselSampleDataV1()
        {
            this.Name = "Vessel 1";
            this.listPositions = new List<Position>()
            {
                new Position{
                    AlreadyCalculated =false,
                    CoordX =5,
                    CoordY =5,
                    TimeStamp = new DateTime(2020,1,1,7,40,0, DateTimeKind.Utc)
                },

                new Position{
                    AlreadyCalculated =false,
                    CoordX =9,
                    CoordY =9,
                    TimeStamp = new DateTime(2020,1,1,7,55,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =15,
                    CoordY =11,
                    TimeStamp = new DateTime(2020,1,1,8,25,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =22,
                    CoordY =14,
                    TimeStamp = new DateTime(2020,1,1,8,50,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =29,
                    CoordY =16,
                    TimeStamp = new DateTime(2020,1,1,9,06,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =29,
                    CoordY =16,
                    TimeStamp = new DateTime(2020,1,1,9,06,0, DateTimeKind.Utc)
                },
                  new Position{
                    AlreadyCalculated =false,
                    CoordX =35,
                    CoordY =17,
                    TimeStamp = new DateTime(2020,1,1,9,34,0, DateTimeKind.Utc)
                },

                  new Position{
                    AlreadyCalculated =false,
                    CoordX =41,
                    CoordY =20,
                    TimeStamp = new DateTime(2020,1,1,9,45,0, DateTimeKind.Utc)
                },

                new Position{
                    AlreadyCalculated =false,
                    CoordX =48,
                    CoordY =23,
                    TimeStamp = new DateTime(2020,1,1,10,13,0, DateTimeKind.Utc)
                }
            };
        }


        /// <summary>
        /// Initialises vessel with sample data 2
        /// </summary>
        public void InitializeVesselSampleDataV2()
        {
            this.Name = "Vessel 2";
            this.listPositions = new List<Position>()
            {
                new Position{
                    AlreadyCalculated =false,
                    CoordX =35,
                    CoordY =35,
                    TimeStamp = new DateTime(2020,1,1,8,24,0, DateTimeKind.Utc)
                },

                new Position{
                    AlreadyCalculated =false,
                    CoordX =41,
                    CoordY =33,
                    TimeStamp = new DateTime(2020,1,1,8,48,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =41,
                    CoordY =33,
                    TimeStamp = new DateTime(2020,1,1,9,15,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =45,
                    CoordY =31,
                    TimeStamp = new DateTime(2020,1,1,9,43,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =47,
                    CoordY =27,
                    TimeStamp = new DateTime(2020,1,1,10,12,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =52,
                    CoordY =25,
                    TimeStamp = new DateTime(2020,1,1,10,37,0, DateTimeKind.Utc)
                },
                  new Position{
                    AlreadyCalculated =false,
                    CoordX =56,
                    CoordY =23,
                    TimeStamp = new DateTime(2020,1,1,9,34,0, DateTimeKind.Utc)
                },

                  new Position{
                    AlreadyCalculated =false,
                    CoordX =62,
                    CoordY =19,
                    TimeStamp = new DateTime(2020,1,1,10,58,0, DateTimeKind.Utc)
                },

                new Position{
                    AlreadyCalculated =false,
                    CoordX =67,
                    CoordY =17,
                    TimeStamp = new DateTime(2020,1,1,11,24,0, DateTimeKind.Utc)
                }
            };
        }

        /// <summary>
        /// Initializes vessel with sample V3
        /// </summary>
        public void InitializeVesselSampleDataV3()
        {
            this.Name = "Vessel 3";
            this.listPositions = new List<Position>()
            {
                new Position{
                    AlreadyCalculated =false,
                    CoordX =30,
                    CoordY =5,
                    TimeStamp = new DateTime(2020,1,1,7,55,0, DateTimeKind.Utc)
                },

                 new Position{
                    AlreadyCalculated =false,
                    CoordX =29,
                    CoordY =9,
                    TimeStamp = new DateTime(2020,1,1,8,20,0, DateTimeKind.Utc)
                },

                new Position{
                    AlreadyCalculated =false,
                    CoordX =26,
                    CoordY =15,
                    TimeStamp = new DateTime(2020,1,1,8,49,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =24,
                    CoordY =18,
                    TimeStamp = new DateTime(2020,1,1,9,14,0, DateTimeKind.Utc)
                },
                new Position{
                    AlreadyCalculated =false,
                    CoordX =21,
                    CoordY =23,
                    TimeStamp = new DateTime(2020,1,1,9,40,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =19,
                    CoordY =27,
                    TimeStamp = new DateTime(2020,1,1,10,8,0, DateTimeKind.Utc)
                },
                 new Position{
                    AlreadyCalculated =false,
                    CoordX =16,
                    CoordY =31,
                    TimeStamp = new DateTime(2020,1,1,10,24,0, DateTimeKind.Utc)
                },
                  new Position{
                    AlreadyCalculated =false,
                    CoordX =15,
                    CoordY =37,
                    TimeStamp = new DateTime(2020,1,1,10,43,0, DateTimeKind.Utc)
                },

                  new Position{
                    AlreadyCalculated =false,
                    CoordX =62,
                    CoordY =19,
                    TimeStamp = new DateTime(2020,1,1,10,58,0, DateTimeKind.Utc)
                }
            };
        }

        /// <summary>
        /// Calculates the distance between two points
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private double CalculateDistance(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p2.CoordY - p1.CoordY, 2D) + Math.Pow((p2.CoordX - p1.CoordX), 2));
        }
    }
}
