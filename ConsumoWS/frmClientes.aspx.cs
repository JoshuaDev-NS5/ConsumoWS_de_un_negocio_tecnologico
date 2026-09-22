using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmClientes : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarClientes();
                CargarCombos();
            }

        }

        private void MostrarClientes()
        {
            try
            {
                var cliente = servicio.findAllCliente();
                grvCliente.DataSource = cliente;
                grvCliente.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }


        private void CargarCombos()
        {
            try
            {
                List<DistritoBO> distrito = servicio.findAllDistrito().ToList();
                List<TipodocumentoBO> tipodocumento = servicio.findAllTipodocumento().ToList();
                List<SexoBO> sexo = servicio.findAllSexo().ToList();

                DistritoBO distritoSeleccionado = new DistritoBO
                {
                    codigo = 0,
                    nombre = "Seleccione un distrito",
                    estado = false
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

                distrito.Insert(0, distritoSeleccionado);
                tipodocumento.Insert(0, tipodocumentoSeleccionado);
                sexo.Insert(0, sexoSeleccionado);

                cboDistrito.DataSource = distrito;
                cboDistrito.DataTextField = "nombre";
                cboDistrito.DataValueField = "codigo";
                cboDistrito.DataBind();

                cboTipoDocumento.DataSource = tipodocumento;
                cboTipoDocumento.DataTextField = "nombre";
                cboTipoDocumento.DataValueField = "codigo";
                cboTipoDocumento.DataBind();

                cboSexo.DataSource = sexo;
                cboSexo.DataTextField = "nombre";
                cboSexo.DataValueField = "codigo";
                cboSexo.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }



        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarCliente();
        }


        private void RegistrarCliente()
        {
            try
            {
                ClienteBO cliente = new ClienteBO();
                DistritoBO distrito = new DistritoBO();
                TipodocumentoBO tipodocumento = new TipodocumentoBO();
                SexoBO sexo = new SexoBO();
                cliente.nombre = txtNombre.Text;
                cliente.apepcli = txtApellidoPaterno.Text;
                cliente.apemcli = txtApellidoMaterno.Text;
                cliente.doccli = txtDoc.Text;
                cliente.dircli = txtDir.Text;
                cliente.feccli = Convert.ToDateTime(txtFecNac.Text);
                cliente.naccli = txtNacionalidad.Text;
                cliente.telcli = txtTelefono.Text;
                cliente.celcli = txtcel.Text;
                cliente.corcli = txtCorreo.Text;

                distrito.codigo = Convert.ToInt32(cboDistrito.SelectedValue);
                cliente.Distrito = distrito;

                tipodocumento.codigo = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                cliente.Tipodocumento = tipodocumento;

                sexo.codigo = Convert.ToInt32(cboSexo.SelectedValue);
                cliente.Sexo = sexo;

                cliente.estado = chkEst.Checked;

                bool resultado = servicio.addCliente(cliente);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el cliente", "alert('Se registro el cliente');", true);
                    MostrarClientes();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el cliente", "alert('No se registro el cliente');", true);
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
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtDoc.Text = "";
            txtDir.Text = "";
            txtFecNac.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
            txtcel.Text = "";
            txtCorreo.Text = "";
            cboDistrito.SelectedIndex = 0;
            cboTipoDocumento.SelectedIndex = 0;
            cboSexo.SelectedIndex = 0;
            chkEst.Checked = false;
        }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCliente();
        }


        private void ActualizarCliente()
        {
            try
            {
                ClienteBO cliente = new ClienteBO();
                DistritoBO distrito = new DistritoBO();
                TipodocumentoBO tipodocumento = new TipodocumentoBO();
                SexoBO sexo = new SexoBO();
                cliente.codigo = Convert.ToInt32(txtCod.Text);
                cliente.nombre = txtNombre.Text;
                cliente.apepcli = txtApellidoPaterno.Text;
                cliente.apemcli = txtApellidoMaterno.Text;
                cliente.doccli = txtDoc.Text;
                cliente.dircli = txtDir.Text;
                cliente.feccli = Convert.ToDateTime(txtFecNac.Text);
                cliente.naccli = txtNacionalidad.Text;
                cliente.telcli = txtTelefono.Text;
                cliente.celcli = txtcel.Text;
                cliente.corcli = txtCorreo.Text;

                distrito.codigo = Convert.ToInt32(cboDistrito.SelectedValue);
                cliente.Distrito = distrito;

                tipodocumento.codigo = Convert.ToInt32(cboTipoDocumento.SelectedValue);
                cliente.Tipodocumento = tipodocumento;

                sexo.codigo = Convert.ToInt32(cboSexo.SelectedValue);
                cliente.Sexo = sexo;

                cliente.estado = chkEst.Checked;

                bool resultado = servicio.updateCliente(cliente);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el cliente", "alert('Se actualizo el cliente');", true);
                    MostrarClientes();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el cliente", "alert('No se actualizo el cliente');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }


        private void EliminarCliente()
        {
            try
            {
                ClienteBO cliente = new ClienteBO();
                cliente.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteCliente(cliente);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el cliente", "alert('Se elimino el cliente');", true);
                    MostrarClientes();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el cliente", "alert('No se elimino el cliente');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }



        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarCliente();
        }

        private void HabilitarCliente()
        {
            try
            {
                ClienteBO cliente = new ClienteBO();
                cliente.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableCliente(cliente);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el cliente", "alert('Se habilito el cliente');", true);
                    MostrarClientes();
                    LimpiarCampos();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el cliente", "alert('No se habilito el cliente');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void grvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Seleccionar")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = grvCliente.Rows[index];
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
                    cboDistrito.SelectedIndex = cboDistrito.Items.IndexOf(cboDistrito.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[11].Text)));
                    cboTipoDocumento.SelectedIndex = cboTipoDocumento.Items.IndexOf(cboTipoDocumento.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[12].Text)));
                    cboSexo.SelectedIndex = cboSexo.Items.IndexOf(cboSexo.Items.FindByText(HttpUtility.HtmlDecode(row.Cells[13].Text)));

                    if (((row.Cells[14].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
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
                    Response.Write(ex.ToString());
                }
            }


        }
    }
}