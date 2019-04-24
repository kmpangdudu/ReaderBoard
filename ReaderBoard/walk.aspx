<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="walk.aspx.cs" Inherits="ReaderBoard.walk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Walk so kids can talk</title>
    <meta http-equiv="refresh" content="600" />
    <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/readerboard.css" rel="stylesheet" />
</head>
<body style="background-color: #DDDDDD;">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div id="imgdiv" class="col-sm-12 col-md-12">
                    <img id="walk" alt="walk so kids can talk" src="./content/wskct.jpg"   class="img-rounded center-block"/>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12 col-md-12  text-left">
                    <%--<p id="header" class="text_left" style="padding-left: 45px;">Kids Help Phone Team</p>--%>
                     <p style="font-size:26px;">Kids Help Phone Team</p>
                </div>
            </div>

            <div class="row">
                <div id="donordiv" class="col-sm-12 col-md-12">
                    <asp:GridView ID="gvdonor" runat="server" AutoGenerateColumns="False"
                        BorderStyle="None"
                        CellPadding="15"
                        GridLines="None"
                        AlternatingRowStyle-BackColor="#e8e8e8"
                        ForeColor="#333333"
                        Font-Size="24px" CssClass="center" Width="100%"
                        AllowPaging="true" PageSize="10" PagerStyle-CssClass="hiddenPager">

                        <AlternatingRowStyle BackColor="#DDDDDD"></AlternatingRowStyle>

                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Walker" ReadOnly="True"
                                ItemStyle-BorderStyle="None"
                                ItemStyle-CssClass="text_left" HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="amount" HeaderText="Amount($)"
                                ItemStyle-BorderStyle="None"
                                ItemStyle-CssClass="text_right"
                                HeaderStyle-HorizontalAlign="Right"   />
                        </Columns>
                        <HeaderStyle BackColor="#9b9b9b" Font-Size="26px" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
