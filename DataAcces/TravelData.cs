using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Common

{
  public  class TravelData
    {
        public int RouteNo { get; set; }
        public DateTime RouteDate { get; set; }
        public string DriverName { get; set; }
        public string VehicleID { get; set; }
        public string LicencePlateID { get; set; }
        public string TruckID { get; set; }
        public string Helper1 { get; set; }
        public string Helper2 { get; set; }
        public string Helper3 { get; set; }
        public string Helper4 { get; set; }
        public DateTime DepatureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int DepartMLG { get; set; }
        public int ArrivalMLG { get; set; }
        public int TotalMLG { get; set; }
        public string HotelInfo { get; set; }
        public string HotelRecipt { get; set; }
        public SqlMoney TotalCOD { get; set; }
        public SqlMoney CODdic { get; set; }
        public DateTime LunchStart { get; set; }
        public DateTime LunchEnd { get; set; }
        public DateTime DinnerStart { get; set; }
        public DateTime DinnerEnd { get; set; }
        public DateTime BreakAStart { get; set; }
        public DateTime BreakAEnd { get; set; }
        public DateTime BreakBstart { get; set; }
        public DateTime BreakBend { get; set; }
        public string DriverComment { get; set; }
        public string Customer { get; set; }
        public string ptsID { get; set; }
        public string ClientName { get; set; }
        public string Service { get; set; }
        public string ClientAddress { get; set; } 
        public int ClientPhone { get; set; }
        public int QBdocNo { get; set; }
        public int PADid { get; set; }
        public int PhoneID { get; set; }
        public string ETA { get; set; }
        public SqlMoney StopCODamt { get; set; }
        public DateTime StopArrival { get; set; }
        public DateTime StopDepart { get; set; } 
        public int StopMLG { get; set; }




    }
}
