﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Andre/default_layout.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="web.Andre.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #Button1 {
            text-align: left;
        }

        #TextArea1 {
            height: 167px;
            width: 412px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBox" runat="server">
    <p style="font-family: 'Segoe UI'; font-weight: bold">Unsere Produkte</p>

    <p style="font-family: 'Segoe UI'; font-weight: bold; text-align: left">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource2" ForeColor="#333333" GridLines="None" style="text-align: center" Width="100%" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Andre/img/marker20-2.png" />
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="PricePerUnit" HeaderText="PricePerUnit" SortExpression="PricePerUnit" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="CUnit" HeaderText="CUnit" SortExpression="CUnit" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="ProductsGetAllByCategory" TypeName="bll.clsProductFacade">
            <SelectParameters>
                <asp:SessionParameter Name="_category" SessionField="category" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>

    <p style="font-family: 'Segoe UI'; font-weight: bold; text-align: center">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <asp:TextBox ID="TextBox1" runat="server" Height="127px" TextMode="MultiLine" Width="241px"></asp:TextBox>

    </p>
    <p>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ProductsGetAll" TypeName="bll.clsProductFacade"></asp:ObjectDataSource>
    </p>
</asp:Content>

