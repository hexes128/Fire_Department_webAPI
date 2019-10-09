using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore.LogoutFolder
{
    public class LogoutCore:ILogoutCore
    {
        OpenDB iOpneDB = new OpenDB();

        public bool CheckLogout(string id) {

            //var payload = new JwtBuilder().Decode<IDictionary<string, object>>(Token);

            List<IDbDataParameter> SetParameters = new List<IDbDataParameter>();

            SetParameters.Add(new SqlParameter("@Logout", "登出"));

            SetParameters.Add(new SqlParameter("@LogoutId", id));
        



            string SQLString = "";
            SQLString = "UPDATE Users SET LoginStatus = @Logout WHERE id =@LogoutId";
           

           

           


            return iOpneDB.UPDATE(SQLString, SetParameters) >0;
        }
    }
}