using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pronto.Common

{
    public enum LoginType
    {
        Admin = 0, User = 1, Median = 2
    }

    public abstract class DriverBase
    {
        public int ID { get; set; }
        //public string DriverName { get; set; }
        public bool Active { get; set; }

    }
    public class Drivers:DriverBase
    {
        //public int ID { get; set; }
        public string DriverName { get; set; }
        //public bool Active { get; set; }
    }


    public class Truck : DriverBase
    {
        //public int ID { get; set; }
        public string TruckId { get; set; }
        public string VehicleID { get; set; }
        public string LicencePlateId { get; set; }
        //public bool Active { get; set; }
    }

    public class Helper : DriverBase
    {
        //public int ID { get; set; }
        public string HelperName { get; set; }
        //public bool Active { get; set; }
    }

    public class Route
    {
        private int rootno;
        public int RootNo
        {
            get { return rootno; }
            set
            {
                rootno = value;

                if (this.stops != null)
                {
                    foreach (var item in this.stops)
                    {
                        item.RouteId = value;
                    }
                }
            }
        }
        public DateTime RouteDate { get; set; }
        public Drivers driver { get; set; }       //[DriverID] [int] Not null,
        //public string VehicleId { get; set; } //[VehicleID] [int] Not null,

        //public string LicencePlateId { get; set; } //[VehicleID] [int] Not null,
        public Truck truck { get; set; } //[VehicleID] [int] Not null,
        public DateTime DepatureTime { get; set; }// [datetime] not null,
        public DateTime ArrivelTime { get; set; }
        public int DepartureMilage { get; set; } = 0;
        public int ArrivelMilage { get; set; } = 0;
        public int RouteMlg
        {
            get
            { return ArrivelMilage - DepartureMilage; }
        }

        public int TotolCod { get; set; } = 0;
        public int CodDecrepency { get; set; } = 0;
        public string HotelInfo { get; set; }
        public string HotelReceipt { get; set; }
        public DateTime BreakAStart { get; set; }
        public DateTime BreakAEnd { get; set; }
        public DateTime BreakBStart { get; set; }
        public DateTime BreakBEnd { get; set; }
        public DateTime LunchStart { get; set; }
        public DateTime LunchEnd { get; set; }
        public DateTime DinnerStart { get; set; }
        public DateTime DinnerEnd { get; set; }
        public string DriverComments { get; set; }

        public List<Helper> helpers { get; set; }
        public List<Stop> stops { get; set; }

        public List<RouteHelper> routeHelpers
        {
            get
            {
                List<RouteHelper> temp = new List<RouteHelper>();
                if (this.helpers != null)
                {
                    foreach (var item in this.helpers)
                    {
                        temp.Add(new RouteHelper() { HelperId = item.ID, RouteId = this.RootNo });
                    }
                }
                return temp;
            }
        }
    }


    public class RouteHelper
    {
        public int RouteId { get; set; }
        public int HelperId { get; set; }
    }

    public class Customer : DriverBase
    {

        //public int ID { get; set; }
        public string CustomerName { get; set; }
        ////public bool Active { get; set; }
    }


    public class Service : DriverBase
    {
        ////public int ID { get; set; }
        public string ServiceType { get; set; }
        //public bool Active { get; set; }
    }


    public class Stop
    {
        public Stop()
        {
            this.StopArrivalTime = DateTime.Now;
            this.StopDepartTime = DateTime.Now;
            this.Eta = DateTime.Now.ToString("hh: mm: tt");
            this.StopCodAmount = 0;
        }
        public int ID { get; set; }

        public string StopNo { get; set; }

        public Customer customer { get; set; } //[CustomerId] Int not null,
        public Service service { get; set; }

        public string PtsId { get; set; }
        public string ClientName { get; set; }
        public string ClientAddr { get; set; }
        public string ClientCity { get; set; }
        public string ClientZipCode { get; set; }
        public string ClientState { get; set; }
        public string ClientPh { get; set; }
        public string QbDocNo { get; set; }
        public string PadId { get; set; }
        public string PhoneId { get; set; }
        public string Eta { get; set; }
        public int StopCodAmount { get; set; }
        public DateTime StopArrivalTime { get; set; }
        public DateTime StopDepartTime { get; set; }

        public TimeSpan StopTimeAllot
        {
            get
            {
                return StopDepartTime - StopArrivalTime;
            }
        }
        public int StopMlgMeterRead { get; set; }

        public int CustomerId
        {
            get
            {
                if (this.customer != null)
                {
                    return customer.ID;
                }
                return 0;
            }
        }

        public int ServiceId
        {
            get
            {
                if (this.service != null)
                {
                    return this.service.ID;
                }
                return 0;
            }
        }

        public int RouteId { get; set; }

        public string StopNote { get; set; }
    }

    public class ComboBoxData
    {
        ////private List<string> helper;
        ////private List<string> customer;
        ////List<string> service;

        List<Drivers> drivers;
        List<Helper> helpers;
        List<Truck> trucks;
        List<Customer> customers;
        List<Service> service;
        List<int> rootNos;


        public ComboBoxData()
        {
            drivers = DataAccessFactory.GetDriverlist();
            helpers = DataAccessFactory.GetHelperlist();
            trucks = DataAccessFactory.GetTrucklist();
            customers = DataAccessFactory.GetCustomerlist();
            service = DataAccessFactory.GetServicelist();
            rootNos = DataAccessFactory.GetRouteNos();
            helpers.Add(new Common.Helper() { HelperName = "" });

            //Pronto.Common.Data.ExcelDataAcess xlData = new Data.ExcelDataAcess(ExcelFile);
            //customer = xlData.ReadExcel("Customer");
            //DriverName = xlData.ReadExcel("DriverName");
            //helper = xlData.ReadExcel("Helper");
            //service = xlData.ReadExcel("Service");
            //Truck = xlData.ReadExcel("Truck");
            //xlData.Close();
        }
        public List<Customer> AllCustomer
        {
            get
            {
                return customers;
            }
        }
        public List<Drivers> AllDriverName
        {
            get
            {
                return drivers;
            }
        }
        public List<Helper> AllHelper
        {
            get
            { return helpers.ToList(); }

        }
        public List<Service> AllService
        {
            get
            { return service; }
        }

        public List<Truck> AllTruck
        {
            get
            { return trucks; }
        }


        public List<Customer> ActiveCustomer
        {
            get
            {
                return customers.Where(T => T.Active == true).ToList();
            }
        }
        public List<Drivers> ActiveDriverName
        {
            get
            {
                return drivers.Where(T => T.Active == true).ToList();
            }
        }
        public List<Helper> ActiveHelper
        {
            get
            { return helpers.Where(T => T.Active == true).ToList(); }

        }
        public List<Service> ActiveService
        {
            get
            { return service.Where(T => T.Active == true).ToList(); }
        }

        public List<Truck> ActiveTruck
        {
            get
            { return trucks.Where(T => T.Active == true).ToList(); }
        }

        public List<string> AllRoodNos
        {

            get
            { 
                List<string> strRootNos = rootNos.ConvertAll(delegate (int i) { return i.ToString(); });
                strRootNos.Add("");
                strRootNos.Sort();
                return strRootNos; 
            }
        }

    }

    public class LoginDetails
    {
        public LoginDetails()
        {
            this.Active = true;
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public LoginType loginType { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public int intType
        {
            get
            { return (int)loginType; }
            set
            {
                loginType = (LoginType)value;
            }
        }
    }


}
