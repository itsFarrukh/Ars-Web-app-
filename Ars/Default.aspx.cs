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
    public partial class _Default : Page
    {
        
        
        SqlConnection connection;
        String Query = "select a.address,a.latitude,a.longitude,a.Rid,d.description,i.MId from Address a join Description d on a.Rid=d.Rid join Image i on a.Rid=i.Rid";
        String QueryCondition="";
        Boolean firstCondition=true;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                showGrideView();
            }
           
        }
        private void showGrideView()
        {
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Panel panel = new Panel();
                    panel.CssClass = "inner";
                    GoogleMap gmap = new GoogleMap();
                    gmap.CenterLatitude = Convert.ToDouble(reader["latitude"]);
                    gmap.CenterLongitude = Convert.ToDouble(reader["longitude"]);
                    gmap.Width = 150;
                    gmap.Height = 100;
                    gmap.CssClass = "requestclass";
                    MapMarker marker = new MapMarker();
                    marker.Latitude = 36.1658;
                    marker.Longitude = -86.7844;
                    gmap.Markers.Add(marker);
                    Literal lt = new Literal();
                    // lt.Text = "<div class='requestclass'>";
                    HyperLink link = new HyperLink();
                    link.Text = "<h1>This accident from " + reader["Address"] + "</h1>";
                    link.NavigateUrl = "Accident.aspx?Rid=" + (reader["Rid"]).ToString();
                    Literal literal = new Literal();
                    literal.Text = "<p>" + reader["description"] + "</p1>";
                    panel.Controls.Add(gmap);
                    // panel.Controls.Add(lt);
                    panel.Controls.Add(link);
                    panel.Controls.Add(literal);
                    AccidentPanel.Controls.Add(panel);

                }

            }
        }
        private void showMapView()
        {

       GoogleMap gmap = new GoogleMap();
            gmap.Width = 1415;
            gmap.Height = 665;
           /* gmap.CssClass = "requestclass";
            MapMarker marker = new MapMarker();
            marker.Latitude = 36.1658;
            marker.Longitude = -86.7844;
            gmap.Markers.Add(marker);

            MapMarker marker1 = new MapMarker();
            marker1.Latitude = 36.1758;
            marker1.Longitude = -86.8844;
            gmap.Markers.Add(marker1);

            */
           
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select a.latitude,a.longitude,a.Rid,d.type,d.description,i.MId from Address a join Description d on a.Rid=d.Rid join Image i on a.Rid=i.Rid",connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
                {
                    gmap.CenterLatitude = Convert.ToDouble(reader["latitude"]);
                    gmap.CenterLongitude = Convert.ToDouble(reader["longitude"]);
                    MapMarker marker = new MapMarker();
                    marker.Title = reader["type"].ToString();
                    marker.InfoWindowHtml = reader["type"] + "</a></br>" + reader["type"] + reader["description"].ToString() + "<br/><a href='Accident.aspx?Rid=" + (reader["Rid"]).ToString() + "'><u>View Detail</u></a>";
                    marker.Latitude = Convert.ToDouble(reader["latitude"]);
                    marker.Longitude = Convert.ToDouble(reader["longitude"]);
                    gmap.Markers.Add(marker);
                   
                }
            }
            mapPanel.Controls.Add(gmap);
        }
        protected void GulshanIqbal_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void GulistanJauhr_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void JamshaidTown_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void Lyari_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void NorthNazimabad_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void Malir_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void Landhi_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }
        protected void Orangi_CB_CheckedChanged(object sender, EventArgs e)
        {
            getAccidentsByTowns();
        }

        private void getAccidentsByTowns()
        {
            firstCondition =true;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                if (GulshanIqbal_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @GulshanIqbal";
                        cmd.Parameters.AddWithValue("@GulshanIqbal" ,"%" + GulshanIqbal_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @GulshanIqbal";
                        cmd.Parameters.AddWithValue("@GulshanIqbal", "%" + GulshanIqbal_CB.Text + "%");
                    }
                }
                if (GulistanJauhr_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @GulistanJauhr";
                        cmd.Parameters.AddWithValue("@GulistanJauhr", "%" + GulistanJauhr_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @GulistanJauhr";
                        cmd.Parameters.AddWithValue("@GulistanJauhr", "%" + GulistanJauhr_CB.Text + "%");
                    }
                }
                if (JamshaidTown_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @JamshaidTown";
                        cmd.Parameters.AddWithValue("@JamshaidTown", "%" + JamshaidTown_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @JamshaidTown";
                        cmd.Parameters.AddWithValue("@JamshaidTown", "%" + JamshaidTown_CB.Text + "%");
                    }
                }
                if (Lyari_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @Lyari";
                        cmd.Parameters.AddWithValue("@Lyari", "%" + Lyari_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @Lyari";
                        cmd.Parameters.AddWithValue("@Lyari", "%" + Lyari_CB.Text + "%");
                    }
                }
                if (NorthNazimabad_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @NorthNazimabad";
                        cmd.Parameters.AddWithValue("@NorthNazimabad", "%" + NorthNazimabad_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @NorthNazimabad";
                        cmd.Parameters.AddWithValue("@NorthNazimabad", "%" + NorthNazimabad_CB.Text + "%");
                    }
                }
                if (Malir_CB.Checked)
                {
                    if (firstCondition)
                    {
                        firstCondition = false;
                        QueryCondition += "where address like @Malir";
                        cmd.Parameters.AddWithValue("@Malir", "%" + Malir_CB.Text + "%");
                    }
                    else
                    {
                        QueryCondition += " or address like @Malir";
                        cmd.Parameters.AddWithValue("@Malir", "%" + Malir_CB.Text + "%");
                    }
                }
                cmd.Connection = connection;
                cmd.CommandText = Query + " " + QueryCondition;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Panel panel = new Panel();
                    panel.CssClass = "inner";

                   

                    Image img = new Image();
                    img.ImageUrl = "img1handler.ashx?id=" + (reader["MId"]).ToString();
                    img.Width = 150;
                    img.Height = 100;
                    HyperLink link = new HyperLink();
                    link.Text = "<h1>This accident from " + reader["Address"] + "</h1>";
                    link.NavigateUrl="Accident.aspx?Rid=" + (reader["Rid"]).ToString();
                    Literal literal = new Literal();
                    literal.Text = "<p>" + reader["description"] + "</p1>";
                    panel.Controls.Add(img);
                    panel.Controls.Add(link);
                    panel.Controls.Add(literal);
                    AccidentPanel.Controls.Add(panel);

                }
            }
        }

        protected void GrideViewBt_Click(object sender, EventArgs e)
        {
            mapPanel.Visible = false;
            gridePanel.Visible = true;
            showGrideView();
        }

        protected void MapViewBt_Click(object sender, EventArgs e)
        {
            mapPanel.Visible = true;
            gridePanel.Visible = false;
            showMapView();
        }
    }
}