using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore.SelectplaceFolder
{
    public class GetPlaceCore:IGetPlaceCore
    {
        OpenDB iOpneDB = new OpenDB();

        public DataTable getplace() {

            List<IDbDataParameter> SetParameters = new List<IDbDataParameter>();
            string SQLString = "";
            SQLString = "SELECT  * FROM item_place";

            return iOpneDB.SELECT(SQLString, SetParameters);
        }
    }
}