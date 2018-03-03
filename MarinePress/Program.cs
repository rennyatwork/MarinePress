using MarinePressCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinePress
{
    class Program
    {
        static void Main(string[] args)
        {
            DashBoard dashBoard = DashBoard.Instance;

            InitializeDachboardSampleData(dashBoard);

            dashBoard.TraverseList();
        }


        static void InitializeDachboardSampleData(DashBoard dashBoard)
        {
            Vessel v1 = new Vessel();
            v1.InitializeVesselSampleDataV1();

            Vessel v2 = new Vessel();
            v2.InitializeVesselSampleDataV2();

            Vessel v3 = new Vessel();
            v3.InitializeVesselSampleDataV3();

            dashBoard.AddVessel(v1);
            dashBoard.AddVessel(v2);
            dashBoard.AddVessel(v3);

        }
    }
}
