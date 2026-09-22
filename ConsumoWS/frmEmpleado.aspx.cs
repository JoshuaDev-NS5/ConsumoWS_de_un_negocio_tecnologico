using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmEmpleado : System.Web.UI.Page
    {
        //Declaramos el servicio de forma global para poder usarlo en cualquier parte de la clase
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//Si no es un postback, es decir, si es la primera vez que se carga la página, entonces se ejecuta el código dentro del if
            {//Esto evita que se ejecuten repetidamente las funciones de carga de datos y combos cada vez que se hace un postback (por ejemplo, al hacer clic en un botón)
                MostrarProductos();
                CargarCombos();
            }

        }

        private void MostrarProductos()
        {
            try
            {
                var empleado = servicio.findAllEmpleado();
                grvEmpleado.DataSource = empleado;
                grvEmpleado.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        /*Cargas combos*/
        private void CargarCombos()
        {
            try
            {
                List<DistritoBO> distrito = servicio.findAllDistrito().ToList();
                List<RolBO> rol = servicio.findAllRol().ToList();
                List<TipodocumentoBO> tipodocumento = servicio.findAllTipodocumento().ToList();
                List<SexoBO> sexo = servicio.findAllSexo().ToList();
                List<EstadocivilBO> estadocivil = servicio.findAllEstadocivil().ToList();

                DistritoBO distritoSeleccionado = new DistritoBO
                {
                    codigo = 0,
                    nombre = "Seleccione un distrito",
                    estado = false
                };
                RolBO rolSeleccionado = new RolBO
                {
                    codrol = 0,
                    nomrol = "Seleccione un rol",
                    estrol = false
                };
                TipodocumentoBO tipodocumentoSeleccionado = new TipodocumentoBO
                {
                    codigo = 0,
                    nombre = "Seleccione un tipo de documento",
                    estado = false
                };
                SexoBO sexoSeleccionado = new SexoBO
                {
                    codigo = 0,
                    nombre = "Seleccione un sexo",
                    estado = false
                };
                EstadocivilBO estadocivilSeleccionado = new EstadocivilBO
                {
                    codestc = 0,
                    nomestc = "Seleccione un estado civil",
                    estestc = false
                };

                distrito.Insert(0, distritoSeleccionado);
                rol.Insert(0, rolSeleccionado);
                tipodocumento.Insert(0, tipodocumentoSeleccionado);
                sexo.Insert(0, sexoSeleccionado);
                estadocivil.Insert(0, estadocivilSeleccionado);

                cboDistrito.DataSource = distrito;
                cboDistrito.DataTextField = "nombre";
                cboDistrito.DataValueField = "codigo";
                cboDistrito.DataBind();

                cboRol.DataSource = rol;
                cboRol.DataTextField = "nomrol";
                cboRol.DataValueField = "codrol";
                cboRol.DataBind();

                cboTipoDocumento.DataSource = tipodocumento;
                cboTipoDocumento.DataTextField = "nombre";
                cboTipoDocumento.DataValueField = "codigo";
                cboTipoDocumento.DataBind();

                cboSexo.DataSource = sexo;
                cboSexo.DataTextField = "nombre";
                cboSexo.DataValueField = "codigo";
                cboSexo.DataBind();

                cboEstadoCivil.DataSource = estadocivil;
                cboEstadoCivil.DataTextField = "nomestc";
                cboEstadoCivil.DataValueField = "codestc";
                cboEstadoCivil.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarEmpleado();
        }


        private void RegistrarEmpleado()
        {
            try
            {
                EmpleadoBO empleado = new EmpleadoBO();
                DistritoBO distrito = new DistritoBO();
                RolBO rol = new RolBO();
                TipodocumentoBO tipodocumento = new TipodocumentoBO();
                SexoBO sexo = new SexoBO();
                EstadocivilBO estadocivil = new EstadocivilBO();
                empleado.nomemp = txtNombre.Text;
                empleado.apepemp = txtApellidoPaterno.Text;
                empleado.apememp = txtApellidoMaterno.Text;
                empleado.docemp = txtDoc.Text;
                empleado.diremp = txtDir.Text;
                empleado.fecemp = Convert.ToDateTime(txtFecNac.Text);
                empleado.nacemp = txtNacionalidad.Text;
                empleado.telemp = txtTelefono.Text;
                empleado.celemp = txtcel.Text;
                empleado.coremp = txtCorreo.Text;
                empleado.usuemp = txtUsuario.Text;
                empleado.claemp = txtContraseña.Text;

                distrito.codigo = Convert.ToInt32(cboDistrito.SelectedValue);
                empleado.Distrito = distrito;

                rol.codrol = Convert.ToInt32(cboRol.SelectedValue);
                empleado.Rol = rol;

                tipodocumento.codigo = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                empleado.Tipodocumento = tipodocumento;

                sexo.codigo = Convert.ToInt32(cboSexo.SelectedValue);
                empleado.Sexo = sexo;

                estadocivil.codestc = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                empleado.Estadocivil = estadocivil;


                empleado.estemp = chkEst.Checked;





                bool resultado = servicio.addEmpleado(empleado);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el empleado", "alert('Se registro el empleado');", true);
                    MostrarProductos();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el empleado", "alert(' No se registro el empleado');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellidoMaterno.Text = "";
            txtApellidoPaterno.Text = "";
            txtDoc.Text = "";
            txtDir.Text = "";
            txtFecNac.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
            txtcel.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            cboDistrito.SelectedIndex = 0;
            cboRol.SelectedIndex = 0;
            cboTipoDocumento.SelectedIndex = 0;
            cboSexo.SelectedIndex = 0;
            cboEstadoCivil.SelectedIndex = 0;
            chkEst.Checked = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarEmpleado();
        }

        private void ActualizarEmpleado()
        {
            try
            {
                EmpleadoBO empleado = new EmpleadoBO();
                DistritoBO distrito = new DistritoBO();
                RolBO rol = new RolBO();
                TipodocumentoBO tipodocumento = new TipodocumentoBO();
                SexoBO sexo = new SexoBO();
                EstadocivilBO estadocivil = new EstadocivilBO();
                empleado.codemp = Convert.ToInt32(txtCod.Text);
                empleado.nomemp = txtNombre.Text;
                empleado.apepemp = txtApellidoPaterno.Text;
                empleado.apememp = txtApellidoMaterno.Text;
                empleado.docemp = txtDoc.Text;
                empleado.diremp = txtDir.Text;
                empleado.fecemp = Convert.ToDateTime(txtFecNac.Text);
                empleado.nacemp = txtNacionalidad.Text;
                empleado.telemp = txtTelefono.Text;
                empleado.celemp = txtcel.Text;
                empleado.coremp = txtCorreo.Text;
                empleado.usuemp = txtUsuario.Text;
                empleado.claemp = txtContraseña.Text;
                distrito.codigo = Convert.ToInt32(cboDistrito.SelectedValue);
                empleado.Distrito = distrito;
                rol.codrol = Convert.ToInt32(cboRol.SelectedValue);
                empleado.Rol = rol;
                tipodocumento.codigo = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                empleado.Tipodocumento = tipodocumento;
                sexo.codigo = Convert.ToInt32(cboSexo.SelectedValue);
                empleado.Sexo = sexo;
                estadocivil.codestc = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                empleado.Estadocivil = estadocivil;

                empleado.estemp = chkEst.Checked;

                bool resultado = servicio.updateEmpleado(empleado);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el empleado", "alert('Se actualizo el empleado');", true);
                    MostrarProductos();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el empleado", "alert(' No se actualizo el empleado');", true);
                }

            }catch (Exception ex){
                    Response.Write(ex.ToString());

                
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void EliminarEmpleado()
        {
            try
            {
                EmpleadoBO empleado = new EmpleadoBO();
                empleado.codemp = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteEmpleado(empleado);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el empleado", "alert('Se elimino el empleado');", true);
                    MostrarProductos();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el empleado", "alert('No se elimino el empleado');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarEmpleado();
        }

        private void HabilitarEmpleado()
        {
            try
            {
                EmpleadoBO empleado = new EmpleadoBO();
                empleado.codemp = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableEmpleado(empleado);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el empleado", "alert('Se habilito el empleado');", true);
                    MostrarProductos();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el empleado", "alert('No se habilito el empleado');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void grvEmpleado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grvEmpleado.Rows[index];
                    txtCod.Text = row.Cells[0].Text;
                    txtNombre.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
                    txtApellidoPaterno.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
                    txtApellidoMaterno.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
                    txtDoc.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
                    txtDir.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
                    txtFecNac.Text = Convert.ToDateTime(row.Cells[6].Text).ToString("yyyy-MM-dd");
                    txtNacionalidad.Text = HttpUtility.HtmlDecode(row.Cells[7].Text);
                    txtTelefono.Text = row.Cells[8].Text;
                    txtcel.Text = HttpUtility.HtmlDecode(row.Cells[9].Text);
                    txtCorreo.Text = HttpUtility.HtmlDecode(row.Cells[10].Text);
                    txtUsuario.Text = HttpUtility.HtmlDecode(row.Cells[11].Text);
                    txtContraseña.Text = HttpUtility.HtmlDecode(row.Cells[12].Text);
                    cboDistrito.SelectedIndex = cboDistrito.Items.IndexOf(cboDistrito.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[13].Text)));
                    cboRol.SelectedIndex = cboRol.Items.IndexOf(cboRol.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[14].Text)));
                    cboTipoDocumento.SelectedIndex = cboTipoDocumento.Items.IndexOf(cboTipoDocumento.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[15].Text)));
                    cboSexo.SelectedIndex = cboSexo.Items.IndexOf(cboSexo.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[16].Text)));
                    cboEstadoCivil.SelectedIndex = cboEstadoCivil.Items.IndexOf(cboEstadoCivil.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[17].Text)));

                    if (((row.Cells[18].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                    {
                        chkEst.Checked = true;
                    }
                    else
                    {
                        chkEst.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    
    }
}