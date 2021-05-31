using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlTypes;



namespace DataAcces
{
    public class DataAccessFactory
    {
        

        public void SaveTravelData(int routeNo, DateTime routeDate, string driverName, string vehicleID, string licencePlateID, string truckID, string helper1, string helper2, string helper3, string helper4, DateTime depatureTime, DateTime arrivalTime, int departMLG, int arrivalMLG, int totalMLG, string hotelInfo, string hotelRecipt, SqlMoney totalCOD, SqlMoney cODdic, DateTime lunchStart, DateTime lunchEnd, DateTime dinnerStart, DateTime dinnerEnd, DateTime breakAStart, DateTime breakBEnd, DateTime breakBstart, DateTime breakBend, string driverComment)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ProntoDB")))
            {
                //List<RouteInfo> route = new List<RouteInfo>();
                //route.Add(new RouteInfo { RouteNo = routeNo, RouteDate = routeDate, DriverName = driverName, VehicleID = vehicleID, LicencePlateID = licencePlateID, TruckID = truckID, Helper1 = helper1, Helper2 = helper2, Helper3 = helper3, Helper4 = helper4, DepatureTime = depatureTime, ArrivalTime = arrivalTime, DepartMLG = departMLG, ArrivalMLG = arrivalMLG, TotalMLG = totalMLG, HotelInfo = hotelInfo, HotelRecipt = hotelRecipt, TotalCOD = totalCOD, CODdic = cODdic, LunchStart = lunchStart, LunchEnd = lunchEnd, DinnerStart = dinnerStart, DinnerEnd = dinnerEnd, BreakAStart = breakAStart, BreakBEnd = breakBEnd, BreakBstart = breakBstart, DriverComment = driverComment});
                //connection.Execute();
            }
        }
    }
}
