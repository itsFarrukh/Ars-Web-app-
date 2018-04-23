using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using MapControl;

namespace Ars
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection connection;
        String query = "select a.AId,a.longitude,a.latitude,a.address,d.description,d.date,p.Name,p.phoneNumber,i.MId from Address a join Description d on a.Rid=d.Rid join Image i on a.Rid=i.Rid join phoneNumber p on p.PId=d.Pid where a.Rid=@RId";
        protected void Page_Load(object sender, EventArgs e)
        {
 
            if (Request.QueryString["Rid"] != null)
            {
                using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Rid",Request.QueryString["Rid"]);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        gMap.CenterLatitude = Convert.ToDouble(reader["latitude"]);
                        gMap.CenterLongitude = Convert.ToDouble(reader["longitude"]);
                        
                        MapMarker marker = new MapMarker();
                        marker.Title = "sss";
                        marker.InfoWindowHtml = "<h1>this description window</h1>";
                        marker.Latitude = Convert.ToDouble(reader["latitude"]);
                        marker.Longitude = Convert.ToDouble(reader["longitude"]);
                        gMap.Markers.Add(marker);
                        Name.Text = reader["Name"].ToString();
                        //Nic.Text = reader["Nic"].ToString();
                        PNumber.Text = reader["phoneNumber"].ToString();
                        date.Text = (reader["date"]).ToString();
                       address.Text = reader["Address"].ToString();
                       description.Text = reader["description"].ToString();
                        img1.ImageUrl = "img1handler.ashx?id=" + (reader["MId"]).ToString();
                       img2.ImageUrl = "img2handler.ashx?id=" + (reader["MId"]).ToString();
                       img1.Width = 308;
                       img1.Height = 200;
                        img2.Width = 308;
                       img2.Height = 200;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}