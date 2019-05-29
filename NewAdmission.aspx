<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewAdmission.aspx.cs" Inherits="WebApplication1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style14 {
        width: 184px;
            height: 28px;
        }
    .auto-style15 {
            margin-left: 80px;
            }
        .auto-style19 {
        height: 26px;
    }
        .auto-style22 {
            height: 53px;
        }
        .auto-style24 {
            margin-left: 80px;
            height: 28px;
            width: 410px;
        }
        .auto-style25 {
            height: 34px;
        }
        .auto-style26 {
            height: 42px;
        }
        .auto-style27 {
            height: 26px;
            width: 410px;
        }
        .auto-style28 {
            width: 410px;
        }
        .auto-style30 {
            height: 42px;
            width: 410px;
        }
        .auto-style31 {
            height: 39px;
        }
        .auto-style32 {
            height: 39px;
            width: 410px;
        }
        .auto-style33 {
            height: 34px;
            width: 410px;
        }
    .auto-style34 {
        height: 50px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
    <tr>
        <td class="auto-style14">Enter School Name</td>
        <td class="auto-style24">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="offset-sm-0"></asp:TextBox>
        </td>
        <td class="auto-style15" rowspan="5" style="text-align:center">
           
            <asp:Button  ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" />
            <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found!"> 


            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style19">Address</td>
        <td class="auto-style27">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>StateName</td>
        <td class="auto-style28">
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" CssClass="mb-0">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>City</td>
        <td class="auto-style28">
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Affiliated Board</td>
        <td class="auto-style28">
            <asp:DropDownList ID="DropDownList3" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style31" >Pin Code</td>
        <td class="auto-style32">
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style15" rowspan="4" style="text-align:center">
            <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
        </td>
    </tr>
    <tr>
        <td>Contact Number</td>
        <td class="auto-style28">
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style25">Date Of Resignation</td>
        <td class="auto-style33">
            <asp:TextBox ID="TextBox8" runat="server" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style26">Zonal</td>
        <td class="auto-style30">
            <asp:DropDownList ID="DropDownList4" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    </table>
    <div class="auto-style34" >
            <table class="w-100">
                <tr>
                    <td style="text-align:center">
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
</asp:Content>
