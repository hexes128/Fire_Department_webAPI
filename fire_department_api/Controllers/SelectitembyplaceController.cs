using fire_department_api.LibraryCore.GetitembyplaceFolder;
using fire_department_api.LibraryCore.TokenverificationFolder;
using Newtonsoft.Json;
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
    public class SelectitembyplaceController : Controller
    {
        SqlConnection conn = new SqlConnection("data source=140.133.78.44; initial catalog =  fire_department;user id =FIREEQUPIMENT;password=Hexes128%");//連接資料庫SQL驗證
        SqlCommand cmd; //SQL指令


        public void Selectitembyplace(string item_place, string Token)
        {
            Tokenverification tokenverification = new Tokenverification(Token);

            switch (tokenverification.Tokenstatus.Trim())
            {

                case ("認證成功"):
                    {

                        IGetitembyplace getitembyplace = new Getitembyplace();

                        Response.Write(JsonConvert.SerializeObject(new
                        {
                            Tokenstatus = tokenverification.Tokenstatus.Trim(),
                            NewToken = tokenverification.NewToken.Trim(),
                            JsonResult = getitembyplace.getitem(item_place)
                        }));
                        break;
                    }
                case ("認證過期"):
                    {
                        Response.Write(JsonConvert.SerializeObject(new { Tokenstatus = tokenverification.Tokenstatus.Trim(), NewToken = "", JsonResult = "" }));
                        break;
                    }
            }
        }





    }
}
