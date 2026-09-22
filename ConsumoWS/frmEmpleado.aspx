<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEmpleado.aspx.cs" Inherits="ConsumoWS.frmEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Mantenimiento de Empleado</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
</head>
<body>
    <div class="container-fluid">
        <h1 class="text-center">Mantenimiento de Empleado</h1>
        <form id="form1" runat="server">
            <%--Controlando el ajax--%>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%--Codigo de Empleado--%>
                    <asp:TextBox ID="txtCod" runat="server" Visible="false"></asp:TextBox>
                    <%--Nombre de Empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Nombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Apellido paterno de Empleado--%>
                    <div class="col-5">
                        <asp:Label ID="ApellidoPaterno" runat="server" Text="Apellido Paterno" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Apellido materno de Empleado--%>
                    <div class="col-5">
                        <asp:Label ID="ApellidoMaterno" runat="server" Text="Apellido Materno" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Documento de empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label4" runat="server" Text="Documento" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtDoc" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <%--Direccion  del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label2" runat="server" Text="Direccion" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtDir" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Fecha de nacimiento del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label8" runat="server" Text="Fecha de Nacimiento" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFecNac" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <%--Nacionalidad del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label9" runat="server" Text="Nacionalidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtNacionalidad" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--telefono fijo del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label10" runat="server" Text="Teléfono Fijo" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Celular del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label11" runat="server" Text="Celular" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtcel" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--correo del empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label12" runat="server" Text="Correo" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <%--Usuario empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label13" runat="server" Text="Usuario" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <%--Contraseña empleado--%>
                    <div class="col-5">
                        <asp:Label ID="Label14" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <%--Seleccionar Distrito--%>
                    <div class="col-5">
                        <asp:Label ID="Label6" runat="server" Text="Distrito" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="cboDistrito" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Seleccionar Rol--%>
                    <div class="col-5">
                        <asp:Label ID="Label7" runat="server" Text="Rol" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="cboRol" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Seleccionar tipo de documento --%>
                    <div class="col-5">
                        <asp:Label ID="Label5" runat="server" Text="Tipo de Documento" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Seleccionar sexo --%>
                    <div class="col-5">
                        <asp:Label ID="Label15" runat="server" Text="Sexo" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="cboSexo" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%--Seleccionar Estado Civil --%>
                    <div class="col-5">
                        <asp:Label ID="Label16" runat="server" Text="Estado Civil" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="cboEstadoCivil" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <%---Seleccionar estado ----%>
                    <div class="col-5">
                        <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
                        <div class="mb-3 form-check">
                            <asp:CheckBox ID="chkEst" runat="server" CssClass="form-check-input" />
                            <asp:Label ID="Label1" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
                        </div>

                    </div>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click"  />
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click"  />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnHabilitar" runat="server" Text="Habilitar" CssClass="btn btn-warning" OnClick="btnHabilitar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>


            <div class="mb-3"></div>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div id="scrollTop" style="overflow-x: auto; width: 100%;">
                         <div style="height: 1px; width: 2000px;"></div>
                    </div>

                    <div class="table-responsive" id="scrollBottom" >

                        <asp:GridView ID="grvEmpleado" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover  table-bordered"  OnRowCommand="grvEmpleado_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="codemp" HeaderText="Codigo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="nomemp" HeaderText="Nombre" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="apepemp" HeaderText="A.Paterno" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="apememp" HeaderText="A.Materno" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="docemp" HeaderText="Documento" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="diremp" HeaderText="Direccion" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="fecemp" HeaderText="Fecha de Nacimiento" HeaderStyle-CssClass="table-dark" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                                <asp:BoundField DataField="nacemp" HeaderText="Nacionalidad" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="telemp" HeaderText="Teléfono Fijo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="celemp" HeaderText="Celular" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="coremp" HeaderText="Correo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="usuemp" HeaderText="Usuario" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="claemp" HeaderText="Contraseña" HeaderStyle-CssClass="table-dark" />
                                
                                <asp:BoundField DataField="Distrito.nombre" HeaderText="Distrito" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Rol.nomrol" HeaderText="Rol" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Tipodocumento.nombre" HeaderText="Tipo de Documento" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Sexo.nombre" HeaderText="Sexo" HeaderStyle-CssClass="table-dark" />
                                <asp:BoundField DataField="Estadocivil.nomestc" HeaderText="Estado Civil" HeaderStyle-CssClass="table-dark" />
                                
                                
                                <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="table-dark">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("estemp"))? "Habilitado": "Deshabilitado" %>
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
   <script>
       function configurarScroll() {

           const scrollTop = document.getElementById("scrollTop");
           const scrollBottom = document.getElementById("scrollBottom");

           if (!scrollTop || !scrollBottom) return;

           scrollTop.onscroll = function () {
               scrollBottom.scrollLeft = scrollTop.scrollLeft;
           };

           scrollBottom.onscroll = function () {
               scrollTop.scrollLeft = scrollBottom.scrollLeft;
           };

           const tabla = scrollBottom.querySelector("table");

           if (tabla) {
               scrollTop.firstElementChild.style.width =
                   tabla.scrollWidth + "px";
           }
       }

       // Primera carga
       window.onload = configurarScroll;

       // Después de cada actualización del UpdatePanel mantiene el funcionamiento del segundo sccroll
       Sys.WebForms.PageRequestManager.getInstance()
           .add_endRequest(configurarScroll);
   </script>

</body>
</html>
