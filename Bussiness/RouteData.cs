using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using DataAccess;
using System.Data;
namespace Bussiness
{
    public class RouteData
    {
        DBRoute dbroute = new DBRoute();
        public int InsertRoute(Route route)
        {
            
            return dbroute.InsertRoute(route);
        }
        public DataSet GetAllRouteDetails()
        {
             
            return dbroute.GetAllRouteDetails();
        }

        public DataSet GetRouteDetailsbyID(int RouteID)
        {

            return dbroute.GetRouteDetailsbyID(RouteID);
        }
         

    }
}