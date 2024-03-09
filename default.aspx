<%@ Page Title="Trang chu" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BanhangOffline._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
        <div class="mycol-4">
            <asp:Label ID="lblMessage" runat="server" Text="" />
        </div>
        <div class="mycol-8" style="text-align: right;">
            <asp:Label ID="Label5" runat="server" Text="[" Font-Size="12px" Visible="true"></asp:Label>
            <asp:LinkButton ID="lbGiohang" runat="server" Font-Size="12px" OnClick="lbGiohang_Click" Text="Giỏ hàng"> </asp:LinkButton>
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
                <asp:GridView ID="listSanphams" runat="server" AutoGenerateColumns="False" AllowSorting="True" width="90%"
                    DataKeyNames="IDSP"
                    BorderColor="Silver"
                    OnRowCommand="listSanphams_RowCommand"
                    EmptyDataText="Không có dữ liệu trong nhóm">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="25px" />
                            <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="image">
                                <ItemTemplate>
                                    <asp:Image ID="img" runat="server" Width="100px" Height="100px" imageurl='<%#  "~/Images/"+Eval("img") %>'/>
                                </ItemTemplate>
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
                        <asp:BoundField DataField="Giaban" HeaderText="Giá bán" DataFormatString="{0:### ### ###}" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <%-- Update Company --%>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbChitietSanpham" runat="server" CommandArgument='<%# Eval("IDSP") %>'
                                    CommandName="XemSanpham" Text="Xem" CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


</asp:Content>
