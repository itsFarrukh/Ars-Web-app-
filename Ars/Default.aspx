<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ars._Default" %>

<%@ Register Assembly="MapControl" Namespace="MapControl" TagPrefix="cc1" %>

<!doctype HTML>
<html>
<HEAD>
        <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>

	<title> ars </title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="css/style-sheet.css"/>  
    <link rel="stylesheet" type="text/css" href="css/reset.css"/>  
</HEAD>
<BODY>
 <div class="cotainer">
       
     <form id="form1" runat="server">
 	<header>
    	<div class="logo">
    	<img src="images/logo1.jpg" alt="logo" width="60" height="40"/>
        <p> Accident Reporting System</p>
        </div>
        <nav>
         <ul>
                  <li><img src="images/question.png" alt="request"/><a href="window 2.htm"> Requests </a></li>
                  <li><img src="images/spam.png" alt="report"/><a href="Reorts.html">Reports </a></li>
                  <li><img src="images/cogs.png" alt="setting"/><a href="Settings.html">Settings </a></li>
         </ul>
             
		 
		</nav>
        
<div class="tabs">
                          <asp:Button ID="GrideViewBt" runat="server" OnClick="GrideViewBt_Click" Text="Gride View" />
        <asp:Button ID="MapViewBt" runat="server" OnClick="MapViewBt_Click" Text="Map View" />

    </div>
    </header>
       
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:Panel ID="gridePanel" runat="server">
 <div class="main"  >
    <div class="check-container">
      <p > Town:</p>
        
    <ul>
      <li>
          <asp:CheckBox ID="GulshanIqbal_CB" runat="server" Text="Gulshan e Iqbal"  AutoPostBack="true" OnCheckedChanged="GulshanIqbal_CB_CheckedChanged"/>
         </li>
      <li>
          
            <asp:CheckBox ID="GulistanJauhr_CB" runat="server" Text="Gulistan e Jauhr" AutoPostBack="true" OnCheckedChanged="GulistanJauhr_CB_CheckedChanged"/>
      </li>
      <li>
        <asp:CheckBox ID="JamshaidTown_CB" runat="server" Text="Jamshed" AutoPostBack="true" OnCheckedChanged="JamshaidTown_CB_CheckedChanged"/>
         </li>
      <li>
        <asp:CheckBox ID="Lyari_CB" runat="server" Text="Lyari Town" AutoPostBack="true" OnCheckedChanged="Lyari_CB_CheckedChanged"/>
        </li>
      <li>
        <asp:CheckBox ID="NorthNazimabad_CB" runat="server" Text="North Nazimabad" AutoPostBack="true" OnCheckedChanged="NorthNazimabad_CB_CheckedChanged"/>
       </li>
      <li>
        <asp:CheckBox ID="Malir_CB" runat="server" Text="Malir" AutoPostBack="true" OnCheckedChanged="Malir_CB_CheckedChanged"/>
        </li>
      <li>
        <asp:CheckBox ID="Landhi_CB" runat="server" Text="Landhi" AutoPostBack="true" OnCheckedChanged="Landhi_CB_CheckedChanged"/>
        </li>
      <li>
        <asp:CheckBox ID="Orangi_CB" runat="server" Text="Orangi" AutoPostBack="true" OnCheckedChanged="Orangi_CB_CheckedChanged"/>
        </li>
      </ul>
    </div>
         <asp:Panel ID="AccidentPanel" runat="server" CssClass="tab-box">
   
    	    </asp:Panel>
    
     
   </div> <!--main-->
         </asp:Panel>
     <asp:Panel ID="mapPanel" runat="server" Visible="false">
        
     </asp:Panel>
 </form>
    </div>

</BODY>
</html>