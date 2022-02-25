<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmMenu.Master" AutoEventWireup="true" CodeBehind="frmFactura.aspx.cs" Inherits="SistemaFarmaciaWeb.Formularios.frmFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:left">Factura</h1>
    </section>
    <section class="content">
        <div class="row">

            <div class="col-md-12">
                <div class="box box-info">
                    <div class="box-body">
                        <div class="form-group">
                            <p align="center"><b>FARMACIA</b></p>
                            <p align="center"><b>EL ORO - MACHALA</b></p>
                            <p align="center"><b>COMERCIO AL POR MENOR DE PRODUCTOS FARMACEUTICOS DE USO HUMANO</b></p>
                            <p align="center"><b>CEL:(0981) 590 5440 - (0986) 465 4612</b></p>
                            <hr />
                            <p align="center"><b>Matriz: spezzini e/ Av.España y Zoila Urgarte</b></p>
                            <p align="center"><b>Suc: Calle Parto y Curuparty Nº527 // casa</b></p>
                        </div>
                    </div>
                </div>


            </div>
            <div class="col-md-6">
                <div class="box box-info">
                    <div class="box-body">
                         <div class="form-group">
                             <label>ID Cliente</label>
                            <asp:TextBox ID="txtIdCliente" runat="server" placeholder="Digite el codigo..." CssClass="form-control"  MaxLength="8" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"  > </asp:TextBox>
                         </div>
                        <div class="form-group">
                             <label>Nombre</label>
                            <asp:TextBox ID="txtNomCliente" runat="server" placeholder="Digite el nombre.." CssClass="form-control" > </asp:TextBox>
                         </div>
                        <div class="form-group">
                             <label>Apellido</label>
                            <asp:TextBox ID="txtApeCliente" runat="server" placeholder="Digite el apellido..." CssClass="form-control"  > </asp:TextBox>
                         </div>
                        <div class="form-group">
                            <label>Correo Electronico</label>
                            <asp:TextBox ID="txtCorCliente" runat="server" placeholder="Digite el email..." CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Cedula</label>
                            <asp:TextBox ID="txtCedCliente" runat="server" placeholder="Digite la cedula..." CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="box box-info">
                    <div class="box-body">
                        <div class="form-group">
                            <label>No. Factura</label>
                            <asp:DropDownList ID="ddlIdFactura" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:TextBox ID="txtIdFactura" runat="server" placeholder="xxxxxxxxxxxxxx" CssClass="form-control"  MaxLength="8" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Fecha</label>
                            <asp:Calendar ID="Calendar1" runat="server" ></asp:Calendar>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="box box-primary">
                    
                    
                    
                    <div class="box-body">
                    <div class="form-group">

                        <table>
                            <tr>
                                <td>
                                    <label>Elejir medicamento</label>
                                    <asp:DropDownList ID="ddlElejirMedicamento" runat="server" CssClass="form-control"></asp:DropDownList>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <label>Cantidad</label>
                                    <asp:TextBox ID="txtCant" runat="server"  CssClass="form-control" Width="100" MaxLength="8" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        
                        <asp:Button ID="btnAnadirMedicamento" runat="server" Text="AÑADIR" OnClick="btnAnadirMedicamento_Click" />
                    
                    </div>

                    <br />
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal"  align="center" >
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                        <div align="center">
                            <table>
                                 <tr>
                                     <td>
                                         <label>Cantidad</label>
                                         <asp:TextBox ID="txtCantidad" runat="server"  CssClass="form-control"></asp:TextBox>
                                     </td>
                                     <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                     <td>
                                         <label>Total</label>
                                         <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
                                     </td>
                                     
                                 </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                         <label>Descuento</label>
                                         <asp:TextBox ID="txtDescuento" runat="server" CssClass="form-control"></asp:TextBox>
                                     </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                        <label>Total Final</label>
                                         <asp:TextBox ID="txtTotalFinal" runat="server"  CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>


                     </div>
                </div>
            </div>


            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <table id="tbl_botones" class="table table-bordered table-hover text-center">
                                <tr>
                                    <th>
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Width="200px" OnClick="btnGuardar_Click"/>
                                    </th>
                                    <th>
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" Width="200px" OnClick="btnCancelar_Click" />
                                    </th>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <table id="tbl_button" class="table table-bordered table-hover text-center">
                                <tr>
                                    <th>
                                        <asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="btn btn-primary" Width="200px" OnClick="btnCargar_Click"/>
                                    </th>
                                    
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>


    </section>

</asp:Content>
