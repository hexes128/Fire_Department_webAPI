using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore
{
    public class LoginCore : ILoginCore
    {
        OpenDB iOpneDB = new OpenDB();
        string LoginStatus;
        public string CheckLogin(string LoginId, string LoginPw)
        {
          
            List<IDbDataParameter> SetParameters = new List<IDbDataParameter>();
            SetParameters.Add(new SqlParameter("@LoginId", LoginId));
            SetParameters.Add(new SqlParameter("@LoginPw", LoginPw));

            string SQLString = "";
            SQLString = "SELECT  * FROM Users where id=@LoginId AND password=@LoginPw";

            DataTable dtTemp = iOpneDB.SELECT(SQLString, SetParameters);

            if (dtTemp.Rows.Count > 0) {
               
                if (!dtTemp.Rows[0]["LoginStatus"].ToString().Trim().Equals("登入"))
                {
                     SetParameters = new List<IDbDataParameter>();
                    SetParameters.Add(new SqlParameter("@LoginId", LoginId));

                    SetParameters.Add(new SqlParameter("@LogStatus", "登入"));

                

                    SQLString = "UPDATE Users SET LoginStatus = @LogStatus  WHERE id =@LoginId";

                    if (iOpneDB.UPDATE(SQLString, SetParameters) == 1) {

                        LoginStatus= "登入成功";
                    }
                }
                else
                {
                    LoginStatus= "此帳號已登入";
                }
           

             }
            else
            {

                LoginStatus= "帳號或密碼錯誤";
            }
            return LoginStatus;
        }
    }
}