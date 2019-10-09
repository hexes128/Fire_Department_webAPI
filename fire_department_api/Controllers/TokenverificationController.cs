//using JWT;
//using JWT.Algorithms;
//using JWT.Builder;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using System.Web.Mvc;

//namespace fire_department_api.Controllers
//{
//    public class TokenverificationController : Controller
//    {
//        public string Tokenstatus, NewToken;
//        SqlConnection conn = new SqlConnection("data source=140.133.78.44; initial catalog =  fire_department;user id =FIREEQUPIMENT;password=Hexes128%");
//        SqlCommand cmd;

//        public TokenverificationController(string Token)
//        {
//            Tokenverification(Token);
//        }

//        public void Tokenverification(string Token)
//        {
//            var payload = new JwtBuilder().Decode<IDictionary<string, object>>(Token);
//            string secret = "MVgIUONObLgr8262769MBI8787rREbtF";

//            try
//            {
//                var json = new JwtBuilder().WithSecret(secret).MustVerifySignature().Decode(Token);
//                Tokenstatus = "認證成功";
//                NewToken = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(secret)
//                          .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
//                          .AddClaim("id", payload["id"]).Build();
//            }
//            catch (TokenExpiredException)
//            {
//                Tokenstatus = "認證過期";
//                NewToken = "";
//                conn.Open();
//                string id = payload["id"].ToString().Trim();
//                cmd = new SqlCommand("UPDATE Users SET LoginStatus = '登出' WHERE id ='" + id + "'", conn);
//                cmd.ExecuteNonQuery();
//            }
//            catch (SignatureVerificationException)
//            {
//                Tokenstatus = "Token無效";
//                NewToken = "";
//            }
//        }
//    }
//}
