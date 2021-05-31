using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace Pronto.Common
{
    public class DataAccessFactory
    {
        public static bool UpdateUsers(List<LoginDetails> ChangedUsers) 
        {
            string InsertQuery = "INSERT INTO [Pronto].[Users]    ([UserName] ,[LoginType] ,[Password],[Active]) VALUES   (@UserName, @LoginType, @Password, @Active)";
            string UpdateQuery = "UPDATE [Pronto].[Users]   SET [LoginType] = @LoginType,[Password] = @Password,[Active] = @Active WHERE ID = @ID";
           

            foreach (var item in ChangedUsers)
            {

                if(item.ID >= 0)
                {
                    Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
                    da.SaveData<LoginDetails>(UpdateQuery, item);
                }
                else
                {
                    string SelectQuery = String.Format("select ID, UserName,LoginType,Password,ACTIVE from Pronto.Users WHERE UserName = '{0}'", item.UserName)  ;
                    Save<LoginDetails>(item, InsertQuery, SelectQuery);
                
                }

            }
            return true;
        }

        public static bool UpdateDrivers(List<DriverBase> obj, string Insertquery, string selectquery, string UpdateQuery)
        {
            foreach (var item in obj)
            {
                if (item.ID >= 0)
                {
                    Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
                    da.SaveData<DriverBase>(UpdateQuery, item);
                }
                else
                {
                    Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
                    int result = da.SaveData(Insertquery, item);
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Cannot insert data to db");
                    }
                                 

                }
            }



            return true;
        }
        public static void DeleteRoute(int RouteNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            da.RunScript(string.Format("DELETE FROM Pronto.Route WHERE RootNo = {0}", RouteNo));
            da.RunScript(string.Format("DELETE FROM Pronto.Stop WHERE RouteId = {0}", RouteNo));
            da.RunScript(string.Format("DELETE FROM Pronto.RouteHelpers WHERE RouteId = {0}", RouteNo));
        }
        public static List<LoginDetails> GetUserList()
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<LoginDetails> resultList = da.LoadData<LoginDetails>("select UserName,LoginType,Password from Pronto.Users WHERE ACTIVE = 1");
            return resultList;
        }

        public static List<LoginDetails> GetAllUserList()
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<LoginDetails> resultList = da.LoadData<LoginDetails>("select ID, UserName,LoginType,Password,ACTIVE from Pronto.Users ");
            return resultList;
        }

        public static System.Data.DataTable GetAllUsers()
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            return da.RunScriptToTable("select ID, UserName,LoginType,Password,ACTIVE from Pronto.Users ");
        }
        public static System.Data.DataTable GetSearchResult(DateTime from, DateTime To, string Query)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            return da.RunScriptToTable(string.Format(Properties.Resources.Search, from.ToString(), To.ToString()) + Query);
        }

        public static System.Data.DataTable GetResultForRoot(string RootNo )
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            return da.RunScriptToTable(string.Format( Properties.Resources.SearchByRoot,RootNo));
        }

        public static System.Data.DataTable LoadDataTable(string Query)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            return da.RunScriptToTable( Query);
        }

        public static Route GetRoute(int RootNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Route> resultList = da.LoadData<Route>(string.Format(Properties.Resources.SelectRoot, RootNo.ToString()));

            if (resultList != null && resultList.Count > 0)
            {
                Route curRoute = resultList.FirstOrDefault();
                curRoute.driver = GetDriver(RootNo);
                curRoute.truck = GetTruck(RootNo);
                curRoute.stops = GetStops(RootNo);
                curRoute.helpers = GetHelpers(RootNo);
                return curRoute;
            }
            return null;
        }

        public static List<int> GetRouteNos()
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<int> resultList = da.LoadData<int>("SELECT[RootNo]  FROM[Pronto].[Route]");

            if (resultList != null )
            {
               
                return resultList;
            }
            return new List<int>();
        }

        public static Drivers GetDriver(int RootNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Drivers> resultList = da.LoadData<Drivers>(string.Format(Properties.Resources.SelectRoot, RootNo.ToString()));

            if (resultList != null && resultList.Count > 0)
            { return resultList.FirstOrDefault(); }
            return null;
        }

        public static Truck GetTruck(int RootNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Truck> resultList = da.LoadData<Truck>(string.Format(Properties.Resources.SelectRoot, RootNo.ToString()));

            if (resultList != null && resultList.Count > 0)
            { return resultList.FirstOrDefault(); }
            return null;
        }


        public static List<Helper> GetHelpers(int RootNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Helper> resultList = da.LoadData<Helper>(string.Format(Properties.Resources.SelectHelpers, RootNo.ToString()));

            if (resultList != null && resultList.Count > 0)
            { return resultList; }
            return new List<Helper>();
        }

        public static List<Stop> GetStops(int RootNo)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Stop> resultList = da.LoadData<Stop>(string.Format(Properties.Resources.SelectStop, RootNo.ToString()));

            if (resultList != null && resultList.Count > 0)
            {
                foreach (Stop item in resultList)
                {
                    string SelectQuery = string.Format(Properties.Resources.SelectSingleStopCustomer, item.ID.ToString());

                    item.customer = GetObj<Customer>(new Customer(), "", SelectQuery, true);
                    SelectQuery = string.Format(Properties.Resources.SelectSingleStopService, item.ID.ToString());
                    item.service = GetObj<Service>(new Service(), "", SelectQuery, true);
                }

                return resultList;
            }
            return new List<Stop>();
        }

        public static Customer GetCustomer(int StopId)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            List<Customer> resultList = da.LoadData<Customer>(string.Format(Properties.Resources.SelectSingleStopCustomer, StopId.ToString()));

            if (resultList != null && resultList.Count > 0)
            {

                return resultList.FirstOrDefault();
            }
            return null;
        }
        public static int GetRootNo()
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            var Result = da.RunScriptToResult("SELECT MAX(RootNo) AS ID FROM Pronto.Route");
            return Pronto.Utility.Functions.StringToInt(Result.ToString()) + 1;

            //SELECT MAX(RootNo) FROM Pronto.Route
        }

        public static Route SaveRoute(Route route,bool isEdit = false)
        {

          

            route.driver = GetDriver(route.driver);
            route.truck = GetTruck(route.truck);

            if (route.driver == null)
            { throw new Exception("Please enter driver"); }

            if (route.truck == null)
            { throw new Exception("Please enter Truck"); }

            for (int i = 0; i < route.helpers.Count; i++)
            {
                route.helpers[i] = GetHelper(route.helpers[i]);
            }


            for (int i = 0; i < route.stops.Count; i++)
            {
                route.stops[i].customer = GetCustomer(route.stops[i].customer);
                route.stops[i].service = GetService(route.stops[i].service);
            }


            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            int result = 0;
            if (!isEdit)
            {
                result = da.SaveDataAndGetIdentity(Properties.Resources.InsertRoute, new
                {
                    RouteDate = route.RouteDate,
                    DriverID = route.driver.ID,
                    //VehicleID = route.VehicleId,
                    //LicencePlateId = route.LicencePlateId,
                    TruckId = route.truck.ID,
                    DepatureTime = route.DepatureTime,
                    ArrivelTime = route.ArrivelTime,
                    DepartureMilage = route.DepartureMilage,
                    ArrivelMilage = route.ArrivelMilage,
                    TotolCod = route.TotolCod,
                    CodDecrepency = route.CodDecrepency,
                    HotelInfo = route.HotelInfo,
                    HotelReceipt = route.HotelReceipt,
                    BreakAStart = route.BreakAStart,
                    BreakAEnd = route.BreakAEnd,
                    BreakBStart = route.BreakBStart,
                    BreakBEnd = route.BreakBEnd,
                    LunchStart = route.LunchStart,
                    LunchEnd = route.LunchStart,
                    DinnerStart = route.DinnerStart,
                    DinnerEnd = route.DinnerEnd,
                    DriverComments = route.DriverComments
                }); 
            }
            else
            {
                result = da.SaveDataAndGetIdentity(Properties.Resources.UpdateRoot, new
                {
                    RouteDate = route.RouteDate,
                    DriverID = route.driver.ID,
                    //VehicleID = route.VehicleId,
                    //LicencePlateId = route.LicencePlateId,
                    TruckId = route.truck.ID,
                    DepatureTime = route.DepatureTime,
                    ArrivelTime = route.ArrivelTime,
                    DepartureMilage = route.DepartureMilage,
                    ArrivelMilage = route.ArrivelMilage,
                    TotolCod = route.TotolCod,
                    CodDecrepency = route.CodDecrepency,
                    HotelInfo = route.HotelInfo,
                    HotelReceipt = route.HotelReceipt,
                    BreakAStart = route.BreakAStart,
                    BreakAEnd = route.BreakAEnd,
                    BreakBStart = route.BreakBStart,
                    BreakBEnd = route.BreakBEnd,
                    LunchStart = route.LunchStart,
                    LunchEnd = route.LunchStart,
                    DinnerStart = route.DinnerStart,
                    DinnerEnd = route.DinnerEnd,
                    DriverComments = route.DriverComments,route.RootNo
                });

                string DeleteHelpers = string.Format( "DELETE H FROM Pronto.RouteHelpers H WHERE H.RouteId = {0}",route.RootNo);
                da.RunScript(DeleteHelpers);

                string DELETESTOPS = string.Format("DELETE S FROM Pronto.Stop S WHERE S.RouteId = {0}", route.RootNo);
                da.RunScript(DELETESTOPS);
            }

            if (result < 0)
            {
                throw new Exception("Cannot insert data to db");
            }

            route.RootNo = result;

            int Result1 = da.SaveData("INSERT INTO [Pronto].[RouteHelpers] ([RouteId],[HelperId])   VALUES(@RouteId, @HelperId)", route.routeHelpers);

            if (result < 0)
            {
                throw new Exception("Cannot insert data to db");
            }


            int result2 = da.SaveData(Properties.Resources.InsertStop, route.stops);

            return route;

        }

        public static Drivers GetDriver(Drivers driver, bool IsRetry = false, bool isSave = false)
        {
            if (string.IsNullOrEmpty(driver.DriverName))
            { return null; }
            string SelectQuery = string.Format("select [ID],[DriverName] from [Pronto].[Drivers] where [DriverName] = '{0}'", driver.DriverName);
            string InsertQuery = "INSERT INTO [Pronto].[Drivers]([DriverName])  VALUES(@DriverName)";

            return GetObj<Drivers>(driver, InsertQuery, SelectQuery, false, isSave);

        }

        public static Truck GetTruck(Truck truck, bool IsRetry = false, bool isSave = false)
        {
            if (string.IsNullOrEmpty(truck.TruckId))
            { return null; }
            string SelectQuery = string.Format("SELECT [ID],[TruckId] FROM [Pronto].[Truck] WHERE TruckId  = '{0}'", truck.TruckId);
            string InsertQuery = "INSERT INTO [Pronto].[Truck] ([TruckId]) VALUES (@TruckId)";

            return GetObj<Truck>(truck, InsertQuery, SelectQuery, false, isSave);
        }

        public static Helper GetHelper(Helper helper, bool IsRetry = false, bool isSave = false)
        {
            if (string.IsNullOrEmpty(helper.HelperName))
            { return null; }
            string SelectQuery = string.Format("select [ID],[HelperName] from [Pronto].[Helper] where [HelperName]   = '{0}'", helper.HelperName);
            string InsertQuery = "INSERT INTO [Pronto].[Helper] ([HelperName]) VALUES (@HelperName)";

            return GetObj<Helper>(helper, InsertQuery, SelectQuery, false, isSave);
        }

        public static Customer GetCustomer(Customer customer, bool IsRetry = false, bool isSave = false)
        {
            if (customer == null || string.IsNullOrEmpty(customer.CustomerName))
            { return null; }
            string SelectQuery = string.Format("SELECT [ID],[CustomerName]  FROM [Pronto].[Customer] where [CustomerName] = '{0}'", customer.CustomerName);
            string InsertQuery = "INSERT INTO [Pronto].[Customer] ([CustomerName])  VALUES (@CustomerName)";

            return GetObj<Customer>(customer, InsertQuery, SelectQuery, false, isSave);
        }

        public static Service GetService(Service service, bool IsRetry = false, bool isSave = false)
        {
            if (service == null || string.IsNullOrEmpty(service.ServiceType))
            { return null; }
            string SelectQuery = string.Format("SELECT [ID],[ServiceType]  FROM [Pronto].[Service] where [ServiceType] = '{0}'", service.ServiceType);
            string InsertQuery = "INSERT INTO [Pronto].[Service]  ([ServiceType])  VALUES (@ServiceType)";

            return GetObj<Service>(service, InsertQuery, SelectQuery,false,isSave);
        }


        private static T SaveNew<T>(T obj, string Insertquery, string selectquery, bool isRetry = false)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();
            int result = da.SaveData(Insertquery, obj);
            if (result == 1)
            {
                return GetObj(obj, Insertquery, selectquery, true);
            }
            else
            {
                throw new Exception("Cannot insert data to db");
            }

        }

        private static T GetObj<T>(T obj, string Insertquery, string selectquery, bool IsRetry = false,bool isSave = false)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            List<T> trucks = da.LoadData<T>(selectquery);

            if (trucks != null && trucks.Count > 0)
            { 
                if(isSave)
                { throw new Exception("Selected Value already exists"); }
                return trucks.FirstOrDefault();
            }
            else if (!IsRetry)
            {
                return SaveNew(obj, Insertquery, selectquery);
            }

            return default(T);
        }



        public static T Save<T>(T obj, string Insertquery, string selectquery, bool IsRetry = false)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            List<T> trucks = da.LoadData<T>(selectquery);

            if (trucks != null && trucks.Count > 0)
            { throw new Exception("Selected user already exists"); }
            else if (!IsRetry)
            {
                return SaveNew(obj, Insertquery, selectquery);
            }

            return default(T);
        }


        public static List<Drivers> GetDriverlist()
        {
           
            string SelectQuery = "select [ID],[DriverName],[ACTIVE] from [Pronto].[Drivers] ";
           

            return GetList<Drivers>(SelectQuery);

        }

        public static List<Helper> GetHelperlist()
        {

            string SelectQuery = "select [ID],[HelperName],[ACTIVE] from [Pronto].[Helper] ";


            return GetList<Helper>(SelectQuery);

        }

        public static List<Truck> GetTrucklist()
        {

            string SelectQuery = "SELECT [ID],[TruckId],[VehicleID],[LicencePlateId],[ACTIVE] FROM [Pronto].[Truck] ";


            return GetList<Truck>(SelectQuery);

        }

        public static List<Customer> GetCustomerlist()
        {

            string SelectQuery = "SELECT [ID],[CustomerName],[ACTIVE]  FROM [Pronto].[Customer] ";


            return GetList<Customer>(SelectQuery);

        }

        public static List<Service> GetServicelist()
        {

            string SelectQuery = "SELECT [ID],[ServiceType],[ACTIVE]  FROM [Pronto].[Service]  ";


            return GetList<Service>(SelectQuery);

        }
        private static List<T> GetList<T>(string selectquery)
        {
            Pronto.Common.Data.SqlDataAccess da = new Data.SqlDataAccess();

            List<T> trucks = da.LoadData<T>(selectquery);

            

            return trucks;
        }




    }
}
