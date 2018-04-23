using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace Ars
{
    /// <summary>
    /// Summary description for img1handler
    /// </summary>
    public class img1handler : IHttpHandler
    {
        SqlConnection connection;

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            if (id != null)
            {
                using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    SqlCommand cmd = new SqlCommand("select img1 from Image where MId=@MId", connection);
                    cmd.Parameters.AddWithValue("@MId", Convert.ToInt32(id));
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    byte[] buffer = (byte[])reader["img1"];
                    memoryStream.Write(buffer, 0, buffer.Length);
                    context.Response.Buffer = true;
                    context.Response.BinaryWrite(buffer);
                    memoryStream.Dispose();



                }
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}