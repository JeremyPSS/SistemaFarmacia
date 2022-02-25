<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmMenu.Master" AutoEventWireup="true" CodeBehind="frmClientes.aspx.cs" Inherits="SistemaFarmaciaWeb.Formularios.frmClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:center">Historial de Clientes</h1>
    </section>
    <section class="content">
        <div class="row" >
            <div class="col-md-12" >
                <div class="box box-solid">
                    <div class="box-body">
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal"  align="center">
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#487575" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#275353" />
                        </asp:GridView>

                        <br />

<%--                        <div class="form-group">
                            <label>Seleccione un cliente</label>
                            <table>
                                <tr>
                                    <td  >
                                        <asp:DropDownList ID="ddlEditar" runat="server" CssClass="form-control" Width="250px"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-danger" Width="100px" OnClick="btnEliminar_Click"/>
                                    </td>
                                </tr>
                            </table>
                            
                            
                        </div>

                    </div>--%>

                    

                </div>
            </div>
        </div>
    </section>


</asp:Content>
