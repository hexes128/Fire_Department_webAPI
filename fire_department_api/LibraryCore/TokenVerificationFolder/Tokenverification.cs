using JWT;
using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore.TokenverificationFolder
{
    public class Tokenverification
    {
        public string Tokenstatus, NewToken;


        public Tokenverification(string Token)
        {

            var payload = new JwtBuilder().Decode<IDictionary<string, object>>(Token);
            string secret = "MVgIUONObLgr8262769MBI8787rREbtF";

            try
            {
                var json = new JwtBuilder().WithSecret(secret).MustVerifySignature().Decode(Token);
                Tokenstatus = "認證成功";
                NewToken = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret(secret)
                          .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
                          .AddClaim("id", payload["id"]).Build();
            }
            catch (TokenExpiredException)
            {
          

                List<IDbDataParameter> SetParameters = new List<IDbDataParameter>();
                SetParameters.Add(new SqlParameter("@Logout", "登出"));
                SetParameters.Add(new SqlParameter("@LogoutId",payload["id"]));
                string   SQLString = "UPDATE Users SET LoginStatus = @Logout WHERE id =@LogoutId";
                OpenDB iOpneDB = new OpenDB();

                if (iOpneDB.UPDATE(SQLString, SetParameters) > 0) {

                    Tokenstatus = "認證過期";
                    NewToken = "";
                }

            }
            //catch (SignatureVerificationException)
            //{
            //    Tokenstatus = "Token無效";
            //    NewToken = "";
            //}
        }
    
    }
}