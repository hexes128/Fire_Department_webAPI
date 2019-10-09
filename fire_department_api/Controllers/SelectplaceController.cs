using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;

namespace fire_department_api.Controllers
{
    public class SelectplaceController : Controller
    {
        SqlConnection conn = new SqlConnection("data source=140.133.78.44; initial catalog =  fire_department;user id =FIREEQUPIMENT;password=Hexes128%");//連接資料庫SQL驗證
        SqlCommand cmd;
        public void Selectplace(string Token)
        {


            var Tokenverification = new TokenverificationController(Token);
           
            switch (Tokenverification.Tokenstatus.Trim())
            {

                case ("認證成功"):
                    {

                        conn.Open();

                        cmd = new SqlCommand("SELECT  * FROM item_place ", conn);
                     

                        SqlDataReader Reader = cmd.ExecuteReader();
                        var output = new List<object>();
                       
                        while (Reader.Read())
                        {
                            output.Add(Reader.GetString(0));
                           
                        }

                  

                        Response.Write(JsonConvert.SerializeObject(
                                    new
                                    {
                                        Tokenstatus = Tokenverification.Tokenstatus.Trim(),
                                        NewToken = Tokenverification.NewToken.Trim(),
                                        JsonResult =output
                                    }));

                   


                        break;
                    }
                case ("認證過期"):
                    {


                       
                     Response.Write(  JsonConvert.SerializeObject(new{Tokenstatus = Tokenverification.Tokenstatus.Trim(), NewToken = "",JsonResult = ""}));


                        break;
                    }

            }


          conn.Close();

           
        }


    }
}
