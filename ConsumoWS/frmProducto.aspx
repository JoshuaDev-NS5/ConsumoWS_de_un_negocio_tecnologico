<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProducto.aspx.cs" Inherits="ConsumoWS.frmProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Mantenimiento de Producto</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
</head>
<body>
    <div class="container-fluid">
        <h1 class="text-center">Mantenimiento de Producto</h1>
        <form id="form1" runat="server">
            <%--Controlando el ajax--%>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%--Codigo de Producto--%>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <%--Nombre de Producto--%>
                    <div class="col-5">
                        <asp:Label ID="Nombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Descripcion de Producto--%>
                    <div class="col-5">
                        <asp:Label ID="Descripcion" runat="server" Text="Descripcion" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtDes" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <%--Precio de producto--%>
                    <div class="col-5">
                        <asp:Label ID="Label4" runat="server" Text="Precio" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtPre" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <%--Cantidad del producto--%>
                    <div class="col-5">
                        <asp:Label ID="Label2" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCan" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <%--Seleccionar Marca--%>
                    <div class="col-5">
                        <asp:Label ID="Label6" runat="server" Text="Marca" CssClass="form-label"></asp:Label>
                         <asp:DropDownList ID="cboMarca" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Seleccionar Categoria--%>
                    <div class="col-5">
                        <asp:Label ID="Label7" runat="server" Text="Categoria" CssClass="form-label"></asp:Label>
                         <asp:DropDownList ID="cboCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Fecha de ingreso del producto--%>
                    <div class="col-5">
                        <asp:Label ID="Label5" runat="server" Text="Fecha de Ingreso" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFec" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>


                    <div class="col-5">
                        <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                        <div class="mb-3 form-check">
                            <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="Label1" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
                        </div>

                    </div>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click"  />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click"  />
                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click"  />
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="mb-3"></div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="table-responsive">
                        <asp:GridView ID="grvProducto" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover  table-bordered" OnRowCommand="grvProducto_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="codigo" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="fechaingreso" HeaderText="Fecha de Ingreso" HeaderStyle-CssClass="table-dark" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                                <asp:BoundField DataField="marca.nombre" HeaderText="Marca" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="categoria.nombre" HeaderText="Categoría" HeaderStyle-CssClass="table-dark" />
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("estado"))? "Habilitado": "Deshabilitado" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Seleccionar" CommandName="Seleccionar" HeaderStyle-CssClass="table-dark" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>



        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>
