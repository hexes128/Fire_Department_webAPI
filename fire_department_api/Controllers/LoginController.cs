using fire_department_api.LibraryCore;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace fire_department_api.Controllers
{
    public class LoginController : Controller
    {

   
        ILoginCore iLoginCor = new LoginCore();

        public void Login(string id, string password)
        {
         


            if (iLoginCor.CheckLogin(id, password).Equals("登入成功"))
            {


                string secret = "MVgIUONObLgr8262769MBI8787rREbtF";
                var createtoken = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(secret) .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds()).AddClaim("id", id).Build();

                Response.Write(JsonConvert.SerializeObject(new { Access = "True", Token = createtoken.Trim() }));

            }
            else
            {
                if(iLoginCor.CheckLogin(id, password).Equals("此帳號已登入"))
                {
                    Response.Write(JsonConvert.SerializeObject(new { Access = "此帳號已登入", Token = "" }));
                }
                if(iLoginCor.CheckLogin(id, password).Equals("帳號或密碼錯誤"))
                {
                    Response.Write(JsonConvert.SerializeObject(new { Access = "帳號或密碼錯誤", Token = "" }));

                }
              
            }




     
        }
   
    }
}