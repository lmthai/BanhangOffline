<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Sanpham.aspx.cs" Inherits="BanhangOffline.Sanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="lblSanphamNew" runat="server" Text="Thêm sản phẩm mới" Font-Size="24px" Font-Bold="true" />
        <asp:Label ID="lblSanphamUpd" runat="server" Text="Xem / Cập nhật sản phẩm" Font-Size="24px" Font-Bold="true" />
        <asp:Label runat="server" ID="lblSPID" Visible="false" Font-Size="12px" />
    </div>
    <div class="mycol-4">
        <asp:Label ID="lblMessage" runat="server" Text="" />
    </div>
        <table align="center">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>Tên sản phẩm</td>
            <td>
                <asp:TextBox ID="txtSanphamName" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                    ToolTip="Tên sản phẩm"
                    AutoCompleteType="Disabled" placeholder="Tên sản phẩm" />
            </td>
        </tr>
        <tr>
            <td>Mã</td>
            <td>
                <asp:TextBox ID="txtSanphamMa" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                    ToolTip="Mã sản phẩm"
                    AutoCompleteType="Disabled" placeholder="Mã sản phẩm" />
            </td>
        </tr>
        <tr>
            <td>ĐVT</td>
            <td>
                <asp:TextBox ID="txtSanphamDVT" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                    ToolTip="Đơn vị tính"
                    AutoCompleteType="Disabled" placeholder="Đơn vị tính" />
            </td>
        </tr>

        <tr>
            <td>Giá bán</td>
            <td>
                <asp:TextBox ID="txtDongia" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                    ToolTip="Giá bán"
                    AutoCompleteType="Disabled" placeholder="Giá bán sản phẩm" />
            </td>
        </tr>

        <tr>
            <td>Nhóm</td>
            <td>
                <asp:DropDownList ID="ddlNhom" runat="server" CssClass="form-control input-xs" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button ID="btnAddSanpham" runat="server" class="btn btn-danger button-xs" data-dismiss="modal" 
                    Text="Thêm sản phẩm"
                    Visible="true" CausesValidation="false"
                    OnClick="btnAddSanpham_Click"
                    UseSubmitBehavior="false" />
                <asp:Button ID="btnUpdSanpham" runat="server" class="btn btn-danger button-xs" data-dismiss="modal" 
                    Text="Cập nhật"
                    Visible="false" CausesValidation="false"
                    OnClick="btnUpdSanpham_Click"
                    UseSubmitBehavior="false" />
                <asp:Button ID="btnClose" runat="server" class="btn btn-info button-xs" data-dismiss="modal" 
                    Text="Close" CausesValidation="false"
                    OnClick="btnClose_Click"
                    UseSubmitBehavior="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblModalMessage" runat="server" ForeColor="Red" Font-Size="12px" Text="" />
            </td>
        </tr>
    </table>


</asp:Content>
