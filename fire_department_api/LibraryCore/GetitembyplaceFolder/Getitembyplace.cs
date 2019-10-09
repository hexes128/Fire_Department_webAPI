using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore.GetitembyplaceFolder
{
    public class Getitembyplace:IGetitembyplace
    {

        public DataTable getitem(string place)
        {

            OpenDB iOpneDB = new OpenDB();

           

                List<IDbDataParameter> SetParameters = new List<IDbDataParameter>();
                string SQLString = "";
                SQLString = "SELECT  * FROM item_withplace where item_place = @Itemplace" ;

                SetParameters.Add(new SqlParameter("@Itemplace", place));


            return iOpneDB.SELECT(SQLString, SetParameters);
            

        }
    }
}