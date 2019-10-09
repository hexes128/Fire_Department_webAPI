using fire_department_api.LibraryCore;
using fire_department_api.LibraryCore.LogoutFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace fire_department_api.Controllers
{
    public class LogoutController : Controller
    {


        ILogoutCore iLogoutCor = new LogoutCore();

        public void Logout(string id)
        {
   
            if (iLogoutCor.CheckLogout(id)) {
                Response.Write("登出成功");
            }
            else
            {
                Response.Write("登出失敗");

            }
        }
    
    }
}
