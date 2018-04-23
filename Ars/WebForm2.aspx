<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Ars.WebForm2" %>

<%@ Register Namespace="MapControl" TagPrefix="mc" Assembly="MapControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <mc:GoogleMap ID="GoogleMap1" runat="server" CenterLatitude="36.1658" CenterLongitude="-86.7844"
            Width="500" Height="500">
            <Markers>
                <mc:MapMarker Latitude="36.1658" Longitude="-86.7844" Title="Nashville, TN" InfoWindowHtml="<strong>Nashville, TN</strong>" />
            </Markers>
        </mc:GoogleMap>

    </div>
    </form>
</body>
</html>
