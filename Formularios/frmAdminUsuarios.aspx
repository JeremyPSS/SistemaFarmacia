<%@ Page Title="" Language="C#" MasterPageFile="~/Formularios/frmMenu.Master" AutoEventWireup="true" CodeBehind="frmAdminUsuarios.aspx.cs" Inherits="SistemaFarmaciaWeb.Formularios.frmAdminUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:center">Control de Usuarios</h1>
    </section>
    <section class="content">

        <div class="row">
            
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>CODIGO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtIdAdministrador" runat="server" placeholder="Digite el codigo..." CssClass="form-control" MaxLength="8" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"   > </asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>CEDULA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCedula" runat="server" placeholder="Digite su cedula.." CssClass="form-control"> </asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>CONTRASEÑA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtContrasena" runat="server" placeholder="Escriba la contraseña..." CssClass="form-control"> </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRES</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombres" runat="server" placeholder="Digite sus dos nombres..." CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>APELLIDOS</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApellidos" runat="server" placeholder="Digite sus dos apellidos..." CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>TELEFONO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTelefono" runat="server" placeholder="Digite su numero de telefono..." CssClass="form-control"> </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>ESTADO CIVIL</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                <asp:ListItem>Casado/a</asp:ListItem>
                                <asp:ListItem>Divorciado/a</asp:ListItem>
                                <asp:ListItem>Soltero/A</asp:ListItem>
                                <asp:ListItem>Union de Hecho</asp:ListItem>
                                <asp:ListItem>Viudo/a</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>E-MAIL</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Digite sus dos nombres..." CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>TIPO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                                <asp:ListItem>Invitado</asp:ListItem>
                                <asp:ListItem>Empleado/Trabajado</asp:ListItem>
                                <asp:ListItem>Socio</asp:ListItem>
                                <asp:ListItem>Tester</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
            </div>

            
           
        </div>

        <div align="center">
                <table>
                    <tr>
                        <td> 
                            <asp:Button ID="btnAceptarEdit" runat="server" Text="Guardar cambios" CssClass="btn-primary" Width="200px" OnClick="btnAceptarEdit_Click" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td> 
                            <asp:Button ID="Button1" runat="server" Text="Registrar" CssClass="btn-primary" Width="200px" OnClick="Button1_Click" />
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn-danger" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click"/>
                        </td>
                    </tr>
                </table>
            </div>

        <br />

        <div class="row" align="center">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title"> Listas de Usuarios</h3>
                    </div>
                </div>
                <div class="box-body table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
            </div>
        </div>

         <br />

        <section class="content-header">
        <h1 style="text-align:center">Editar Usuarios</h1>
        </section>

        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>Seleccion el Usuario a editar</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlEditar" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                        <asp:Button ID="Button2" runat="server" Text="Editar" CssClass="btn btn-primary" Width="200px" OnClick="Button2_Click"/>
                                    </th>
                                    <th>
                                        <asp:Button ID="Button3" runat="server" Text="Eliminar" CssClass="btn btn-danger" Width="200px" OnClick="Button3_Click"/>
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
