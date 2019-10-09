using fire_department_api.LibraryCore.SelectplaceFolder;
using fire_department_api.LibraryCore.TokenverificationFolder;
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
    public class GetplaceController : Controller
    {
    
        public void Selectplace(string Token)
        {

            Tokenverification tokenverification = new Tokenverification(Token);

            switch (tokenverification.Tokenstatus.Trim())
            {

                case ("認證成功"):
                    {

                        IGetPlaceCore iGetplaceCore = new GetPlaceCore();

                        Response.Write(JsonConvert.SerializeObject(new
                        {
                            Tokenstatus = tokenverification.Tokenstatus.Trim(),
                            NewToken = tokenverification.NewToken.Trim(),
                            JsonResult = iGetplaceCore.getplace()
                        }));
                        break;
                    }
                case ("認證過期"):
                    {       
                     Response.Write(  JsonConvert.SerializeObject(new{Tokenstatus = tokenverification.Tokenstatus.Trim(), NewToken = "",JsonResult = ""}));
                        break;
                    }
            }
     
        }
    }
}
