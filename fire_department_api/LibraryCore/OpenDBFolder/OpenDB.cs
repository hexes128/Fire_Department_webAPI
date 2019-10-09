using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace fire_department_api.LibraryCore
{
    public class OpenDB
    {
        SqlConnection conn = new SqlConnection("data source=140.133.78.44; initial catalog =  fire_department;user id =FIREEQUPIMENT;password=Hexes128%");//連接資料庫SQL驗證
        SqlCommand cmd;
        SqlDataAdapter dataAdapter;
        public DataTable SELECT(string sql, List<IDbDataParameter> parameters)
        {
          
  

            conn.Open();
            cmd = new SqlCommand(sql, conn);
             dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;

            if (parameters != null)
            {
                dataAdapter.SelectCommand.Parameters.Clear();

                foreach (IDbDataParameter parameter in parameters)
                {
                    if (parameter.Value == null) parameter.Value = DBNull.Value;

                    dataAdapter.SelectCommand.Parameters.Add(parameter);

                }
            }

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            conn.Close();

            return dataTable;
        }

        public int UPDATE(string sql, List<IDbDataParameter> parameters) {
            conn.Open();
            cmd = new SqlCommand(sql, conn);
          
            foreach (IDbDataParameter parameter in parameters)
                {
                if (parameter.Value == null)
                {
                    parameter.Value = DBNull.Value;
                }

                cmd.Parameters.Add(parameter);

                }
            int affectedrowcount = cmd.ExecuteNonQuery(); 
            conn.Close();


            return affectedrowcount;
        }
    }
}