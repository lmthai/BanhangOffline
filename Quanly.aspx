<%@ Page Title="Quản lý danh mục sản phẩm" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Quanly.aspx.cs" Inherits="BanhangOffline.Quanly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <div class="mycol-4">
        <asp:Label ID="lblMessage" runat="server" Text="" />
    </div>
    <div class="mycol-4" style="text-align: right;">
        <asp:Label ID="Label5" runat="server" Text="[" Font-Size="12px" Visible="true"></asp:Label>
        <asp:LinkButton ID="lbNewSanpham" runat="server" Font-Size="12px" OnClick="lbNewSanpham_Click">Thêm</asp:LinkButton>
        <asp:Label ID="Label6" runat="server" Text="]" Font-Size="12px" Visible="true"></asp:Label>
    </div>
    <%-- Gridview --%>
    <div class="myrow" style="margin-top: 20px;">
        <div class="mycol-2">
            <asp:ListBox ID="ListNhom" runat="server" DataSourceID="SqlDataSource1" Width="100%"
            DataTextField="Tennhom" DataValueField="Manhom" AutoPostBack="true" OnSelectedIndexChanged="ShowNhom"></asp:ListBox>  
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
            ConnectionString="<%$ ConnectionStrings:ShopConnection %>"   
            SelectCommand="SELECT * FROM NhomSP"></asp:SqlDataSource>                
        </div>
        <div class="mycol-1"></div>
        <div class="mycol-9">
            <asp:GridView ID="gvSanphams" runat="server" AutoGenerateColumns="False" AllowSorting="True"  width="90%"
                DataKeyNames="IDSP"
                BorderColor="Silver"
                OnRowDeleting="gvSanphams_RowDeleting"
                OnRowCommand="gvSanphams_RowCommand"
                EmptyDataText="Không có dữ liệu">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="25px" />
                        <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Tennhom" HeaderText="Nhóm">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MaSP" HeaderText="Mã">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Dvt" HeaderText="ĐVT">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Giaban" HeaderText="Giá bán" DataFormatString="{0:### ### ###}">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                    <%-- Delete Sanpham --%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDelSanpham" Text="Del" runat="server"
                                OnClientClick="return confirm('Bạn chắc chắn muốn xóa sản phẩm này?');" CommandName="Delete" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>

                    <%-- Update Company --%>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUpdSanpham" runat="server" CommandArgument='<%# Eval("IDSP") %>'
                                CommandName="UpdSanpham" Text="Upd" CausesValidation="false"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
