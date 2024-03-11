<%@ Page Title="Giỏ hàng" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Giohang.aspx.cs" Inherits="BanhangOffline.Giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <div class="myrow">
        <div class="mycol-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" width="90%"
                DataKeyNames="idSP"
                BorderColor="Silver"
                OnRowDeleting="GridView1_RowDeleting"
                EmptyDataText="Không có dữ liệu trong giỏ hàng">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" Width="25px" />
                        <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="TenSP" HeaderText="Tên sản phẩm">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Gia" HeaderText="Giá bán" DataFormatString="{0:### ### ###}" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SoLuong" HeaderText="Số lượng" DataFormatString="{0:### ### ###}" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TongTien" HeaderText="Thành tiền" DataFormatString="{0:### ### ###}" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>

                        <%-- Delete Sanpham --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbXoaSanpham" Text="Xóa" runat="server"
                                    OnClientClick="return confirm('Bạn chắc chắn muốn xóa sản phẩm này?');" CommandName="Delete" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="mycol-4">
        <asp:Label ID="Tongtien" runat="server" Text="" />
    </div>

    <%-- Dat hang Buttons --%>
    <div class="modal-footer">
        <asp:Button ID="lbDathang" runat="server" class="btn btn-danger button-xs" data-dismiss="modal" 
            Text="Đặt hàng"
            Visible="true" CausesValidation="false"
            OnClick="btnDathang_Click"
            UseSubmitBehavior="false" />
        <asp:Button ID="Button4" runat="server" class="btn btn-info button-xs" data-dismiss="modal" 
            Text="Close" CausesValidation="false"
            OnClick="btnClose_Click"
            UseSubmitBehavior="false" />
    </div>
</asp:Content>
