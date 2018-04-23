<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accident.aspx.cs" Inherits="Ars.WebForm1" %>

<%@ Register Assembly="MapControl" Namespace="MapControl" TagPrefix="cc1" %>
<!doctype HTML>
<html>
<HEAD>
	<title> ars </title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="css/style-sheet.css"/>  
    <link rel="stylesheet" type="text/css" href="css/reset.css"/>  
           <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>

</HEAD>
<body>
      <form id="form1" runat="server">
<div class="cotainer">
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
  </header>
    <div class="form-container"> 
    
    <asp:ScriptManager runat="server" ID="ScriptManager1">
    </asp:ScriptManager>
      <cc1:GoogleMap ID="gMap" runat="server"  Width="500px" Height="400px" CssClass="map-box">
             </cc1:GoogleMap>
    
    <div class="form-box">
      <div class="form-box-inner">
        <ul><li> Name:<asp:TextBox ID="Name" runat="server"  Enabled="false" CssClass="txtbox" style="margin-left:115px" Width="215px"></asp:TextBox><br></li>
        </ul>
      </div>
      <div class="form-box-inner">
       <ul><li> NIC Number:<asp:TextBox ID="Nic" runat="server"  Enabled="false" CssClass="txtbox" style="margin-left:63px" Width="215px"></asp:TextBox><br></li></ul>
      </div>
      <div class="form-box-inner">
       <ul><li> Phone Number:
        <asp:TextBox ID="PNumber" runat="server" Enabled="false"  CssClass="txtbox" style="margin-left:38px" Width="215px"></asp:TextBox>
         <br></li></ul>
      </div>
      <div class="form-box-inner">
        <ul><li> Date:<asp:TextBox ID="date" runat="server" Enabled="false" CssClass="txtbox" style="margin-left:122px" Width="215px"></asp:TextBox><br></li></ul>
      </div>
      <div class="form-box-inner">
        <ul><li> Address:
          <asp:TextBox ID="address" runat="server"  CssClass="txtbox" Enabled="false" TextMode="MultiLine"  style="margin-left:90px" Height="73px" Width="215px" OnTextChanged="address_TextChanged"></asp:TextBox>
          <br></li> </ul>
      </div>
      <div class="form-box-inner">
        <ul><li> Description:
  <asp:TextBox ID="description" runat="server" disabled="false" TextMode="MultiLine"  Enabled="false" CssClass="txtbox" style="margin: 0px 0 0 65px  " Height="89px" Width="215px"></asp:TextBox>
          
          </li>
          </ul>
      </div>
      
    </div>
 
    <div class="img-block">
    <h1 > Snaps Shots: </h1>
        <asp:Image ID="img1" runat="server" />
        <asp:Image ID="img2" runat="server" />
        
    </div>
     
   </div> 

    </div>
    </form>
          </body>
    </html>